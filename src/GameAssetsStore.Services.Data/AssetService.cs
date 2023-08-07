namespace GameAssetsStore.Services.Data;

using GameAssetsStore.Data.Models;
using GameAssetsStore.Data.Repositories.Interfaces;
using GameAssetsStore.Services.Data.Interfaces;
using GameAssetsStore.Services.Models.Asset;
using GameAssetsStore.Web.ViewModels.Manage;
using GameAssetsStore.Web.ViewModels.Shop;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using static Common.GlobalConstants;

public class AssetService : IAssetService
{
    private readonly IRepository<Asset> assetRepository;
    private readonly IRepository<Shop> shopRepository;
    private readonly IRepository<GeneralCategory> categoriesRepository;
    private readonly IRepository<SubCategory> subCategoriesRepository;
    private readonly IRepository<ArtStyle> artStyleRepository;
    private readonly IRepository<ApplicationUser> userRepository;
    private readonly IStorageService storageService;

    public AssetService(IRepository<Asset> assetRepository,
        IRepository<Shop> shopRepository,
        IRepository<GeneralCategory> categoriesRepository,
        IRepository<SubCategory> subCategoriesRepository,
        IRepository<ArtStyle> artStyleRepository,
        IRepository<ApplicationUser> userRepository,
        IStorageService storageService)
    {
        this.assetRepository = assetRepository;
        this.shopRepository = shopRepository;
        this.categoriesRepository = categoriesRepository;
        this.subCategoriesRepository = subCategoriesRepository;
        this.artStyleRepository = artStyleRepository;
        this.userRepository = userRepository;
        this.storageService = storageService;
    }

    public async Task ChangeAssetVisibilityAsync(string assetId)
    {
        var assetEntity = await this.assetRepository.GetAll().FirstAsync(a => a.Id.ToString() == assetId);

        assetEntity.IsPublic = !assetEntity.IsPublic;

        this.assetRepository.Update(assetEntity);

        await this.assetRepository.SaveChangesAsync();
    }

    public async Task<bool> CreateAssetAsync(CreateAssetFormModel model, string shopId)
    {
        var artStyleEntity = await this.artStyleRepository.GetAll().FirstAsync(a => a.Id == model.SelectedStyleId);

        var assetEntity = new Asset()
        {
            ShopId = Guid.Parse(shopId),
            AssetName = WebUtility.HtmlEncode(model.AssetTitle),
            FileName = WebUtility.HtmlEncode(model.AssetFile.FileName),
            Description = WebUtility.HtmlEncode(model.Description),
            ArtStyle = artStyleEntity,
            Version = WebUtility.HtmlEncode(model.Version),
            Price = model.Price
        };

        artStyleEntity.Assets.Add(assetEntity);

        await this.assetRepository.AddAsync(assetEntity);
        var shop = await this.shopRepository.GetAll().FirstAsync(s => s.Id == assetEntity.ShopId);

        var selectedCategories = model.Categories
            .Where(c => c.SubCategories.Any(sc => sc.IsChecked))
            .ToArray();

        foreach (var categoryModel in selectedCategories)
        {
            var category = await this.categoriesRepository.GetAll().FirstAsync(c => c.Id == categoryModel.Id);

            foreach (var subCategoryModel in categoryModel.SubCategories)
            {
                if (subCategoryModel.IsChecked)
                {
                    var subCategory = await this.subCategoriesRepository.GetAll().FirstAsync(sc => sc.Id == subCategoryModel.Id);

                    assetEntity.SubCategories.Add(subCategory);
                }
            }

            assetEntity.GeneralCategories.Add(category);
        }

        await this.storageService.UploadAsync(model.AssetFile, assetEntity.Id.ToString(), AWSS3AssetsBucketName, assetEntity.FileName);

        await this.assetRepository.SaveChangesAsync();

        await this.storageService.UploadAsync(model.CoverImage, assetEntity.Id.ToString(), AWSS3ImagesBucketName, "cover");

        for (int i = 0; i < model.Images.Count(); i++)
        {
            await this.storageService.UploadAsync(model.Images[i], assetEntity.Id.ToString(), AWSS3ImagesBucketName, $"media{i + 1}");
        }

        return true;
    }

    public async Task<DownloadAssetServiceModel> DownloadAsync(string assetId)
    {
        var assetEntity = await this.assetRepository.GetAllAsNoTracking().FirstAsync(a => a.Id.ToString() == assetId);

        var serviceModel = await this.storageService.DownloadAsync(AWSS3AssetsBucketName, assetEntity.FileName, assetId);

        serviceModel.FileName = assetEntity.FileName;

        return serviceModel;
    }

    public async Task EditAssetInfoAsync(AssetInfoFormModel model)
    {
        var assetEntity = await this.assetRepository.GetAll().FirstAsync(a => a.Id == model.AssetId);

        assetEntity.AssetName = model.AssetTitle;
        assetEntity.Description = model.Description;
        assetEntity.Version = model.Version;
        assetEntity.Price = model.Price;

        this.assetRepository.Update(assetEntity);

        await this.assetRepository.SaveChangesAsync();
    }

    public async Task<AssetPageViewModel> GetAssetPageViewModelAsync(string assetId)
    {
        var asset = await this.assetRepository.GetAllAsNoTracking().FirstAsync(a => a.Id.ToString() == assetId);

        var assetModel = new AssetPageViewModel
        {
            AssetTile = asset.AssetName,
            Description = asset.Description,
            Price = asset.Price
        };

         var imagesKeys = await this.storageService.GetAssetImagesKeysAsync(assetId, AWSS3ImagesBucketName);

        assetModel.ImagesUrl = imagesKeys
            .Select(key => string.Format(AWSS3ImageUrl, AWSS3Region, assetId.ToLower(), key))
            .ToArray();

        return assetModel;
    }

    public async Task<EditAssetFormModel> GetEditAssetFormModelAsync(string assetId)
    {
        var asset = await this.assetRepository.GetAll().FirstAsync(a => a.Id.ToString() == assetId);

        return new EditAssetFormModel
        {
            AssetInfo = new AssetInfoFormModel
            {
                AssetId = asset.Id,
                AssetTitle = asset.AssetName,
                Description = asset.Description,
                Version = asset.Version,
                Price = asset.Price,
                IsPublished = asset.IsPublic
            },
            AssetFile = new EditAssetFileFormModel
            {
                AssetId = asset.Id,
                CurrentlyUploadedFileName = asset.FileName
            }
        };
    }

    public Task<List<ManageAssetCardViewModel>> GetShopManagerAssetViewModelAsync(string shopId)
    {
        return this.assetRepository.GetAllAsNoTracking()
            .Where(a => a.ShopId.ToString() == shopId)
            .Select(a => new ManageAssetCardViewModel
            {
                Id = a.Id,
                AssetName = a.AssetName,
                FileName = a.FileName,
                Description = a.Description,
                CoverImageUrl = string.Format(AWSS3ImageUrl, AWSS3Region, a.Id.ToString().ToLower(), "cover"),
                ArtStyle = a.ArtStyle.Name,
                Price = a.Price,
                Version = a.Version,
                SalesCount = a.SalesCount,
                CreatedOn = a.CreatedOn,
                ModifiedOn = a.ModifiedOn,
                IsPublic = a.IsPublic
            })
            .ToListAsync();

    }

    public async Task<bool> IsUserAssetOwnerAsync(string? userShopId, string assetId)
    {
        if (userShopId != null)
        {
            var assetEntity = await this.assetRepository.GetAllAsNoTracking().FirstAsync(a => a.Id.ToString() == assetId);

            if (assetEntity.ShopId.ToString() == userShopId)
            {
                return true;
            }
        }

        return false;
    }

    public async Task<bool> IsUserPurchasedAssetAsync(string userId, string assetId)
    {
        var user = await this.userRepository.GetAllAsNoTracking().FirstAsync(u => u.Id.ToString() == userId);

        if (user.PurchasedAssets.Any(a => a.Id.ToString() == assetId))
        {
            return true;
        }

        return false;
    }

    public async Task UpdateAssetFileAsync(EditAssetFileFormModel model)
    {
        var newFileEncodedName = WebUtility.HtmlEncode(model.AssetFile.FileName);
        var currentFileName = model.CurrentlyUploadedFileName;

        if (currentFileName == newFileEncodedName)
        {
            await this.storageService.UploadAsync(model.AssetFile, model.AssetId.ToString().ToLower(), AWSS3AssetsBucketName, newFileEncodedName);
        }
        else
        {
            await this.storageService.UploadAsync(model.AssetFile, model.AssetId.ToString().ToLower(), AWSS3AssetsBucketName, newFileEncodedName);

            var assetEntity = await this.assetRepository.GetAll().FirstAsync(a => a.Id == model.AssetId);
            assetEntity.FileName = newFileEncodedName;

            await this.assetRepository.SaveChangesAsync();

            await this.storageService.DeleteAsync(AWSS3AssetsBucketName, currentFileName, model.AssetId.ToString().ToLower());
        }
    }
}
