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
using System.Text.Json;
using System.Threading.Tasks;

using static Common.GlobalConstants;

public class AssetService : IAssetService
{
    private readonly IAssetRepository assetRepository;
    private readonly IRepository<Shop> shopRepository;
    private readonly IRepository<GeneralCategory> categoriesRepository;
    private readonly IRepository<SubCategory> subCategoriesRepository;
    private readonly IArtStyleRepository artStyleRepository;
    private readonly IUserRepository userRepository;
    private readonly IStorageService storageService;

    public AssetService(IAssetRepository assetRepository,
        IRepository<Shop> shopRepository,
        IRepository<GeneralCategory> categoriesRepository,
        IRepository<SubCategory> subCategoriesRepository,
        IArtStyleRepository artStyleRepository,
        IUserRepository userRepository,
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
        var assetEntity = await this.assetRepository.GetById(Guid.Parse(assetId));

        assetEntity!.IsPublic = !assetEntity.IsPublic;

        this.assetRepository.Update(assetEntity);

        await this.assetRepository.Save();
    }

    public async Task<bool> CreateAssetAsync(CreateAssetFormModel model, string shopId)
    {
        var artStyleEntity = await this.artStyleRepository.GetById(model.SelectedStyleId);

        var assetEntity = new Asset()
        {
            ShopId = Guid.Parse(shopId),
            AssetName = WebUtility.HtmlEncode(model.AssetTitle),
            FileName = WebUtility.HtmlEncode(model.AssetFile.FileName),
            Description = WebUtility.HtmlEncode(model.Description),
            ArtStyle = artStyleEntity!,
            Version = WebUtility.HtmlEncode(model.Version),
            Price = model.Price
        };

        artStyleEntity!.Assets.Add(assetEntity);

        await this.assetRepository.Add(assetEntity);
        var shop = await this.shopRepository.GetById(assetEntity.ShopId);

        var selectedCategories = model.Categories
            .Where(c => c.SubCategories.Any(sc => sc.IsChecked))
            .ToArray();

        foreach (var categoryModel in selectedCategories)
        {
            var category = await this.categoriesRepository.GetById(categoryModel.Id);

            foreach (var subCategoryModel in categoryModel.SubCategories)
            {
                if (subCategoryModel.IsChecked)
                {
                    var subCategory = await this.subCategoriesRepository.GetById(subCategoryModel.Id);

                    assetEntity.SubCategories.Add(subCategory!);
                }
            }

            assetEntity.GeneralCategories.Add(category!);
        }

        await this.storageService.UploadAsync(model.AssetFile, assetEntity.Id.ToString(), AWSS3AssetsBucketName, assetEntity.FileName);

        await this.assetRepository.Save();

        await this.storageService.UploadAsync(model.CoverImage, assetEntity.Id.ToString(), AWSS3ImagesBucketName, "cover");

        for (int i = 0; i < model.Images.Count; i++)
        {
            await this.storageService.UploadAsync(model.Images[i], assetEntity.Id.ToString(), AWSS3ImagesBucketName, $"media{i + 1}");
        }

        return true;
    }

    // TODO: Override the delete in the repository to perform the soft delete.
    public async Task AssetSoftDeleteAsync(string assetId)
    {
        var assetEntity = await this.assetRepository.GetById(Guid.Parse(assetId));

        await this.DeleteAllAssetFilesFromStorageAsync(assetEntity!.Id.ToString().ToLower(), assetEntity.FileName);

        assetEntity.AssetName = "DELETED";
        assetEntity.FileName = "DELETED";
        assetEntity.Description = "DELETED";
        assetEntity.Version = "DELETED";
        assetEntity.IsDeleted = true;
        assetEntity.DeletedOn = DateTime.UtcNow;

        this.assetRepository.Update(assetEntity);

        await this.assetRepository.Save();
    }

    public async Task<DownloadAssetServiceModel> DownloadAsync(string assetId)
    {
        var assetEntity = await this.assetRepository.GetById(Guid.Parse(assetId));

        var serviceModel = await this.storageService.DownloadAsync(AWSS3AssetsBucketName, assetEntity!.FileName, assetId);

        serviceModel.FileName = assetEntity.FileName;

        return serviceModel;
    }

    public async Task EditAssetInfoAsync(AssetInfoFormModel model)
    {
        var assetEntity = await this.assetRepository.GetById(model.AssetId);

        assetEntity!.AssetName = model.AssetTitle;
        assetEntity.Description = model.Description;
        assetEntity.Version = model.Version;
        assetEntity.Price = model.Price;
        assetEntity.ModifiedOn = DateTime.UtcNow;

        this.assetRepository.Update(assetEntity);

        await this.assetRepository.Save();
    }

    public async Task<AssetPageViewModel> GetAssetPageViewModelAsync(string assetId, string? userId, string? cartJson)
    {
        ApplicationUser? user;

        var asset = await this.assetRepository.GetById(Guid.Parse(assetId));

        var assetModel = new AssetPageViewModel
        {
            AssetId = asset!.Id.ToString().ToLower(),
            AssetTile = asset.AssetName,
            Description = asset.Description,
            Price = asset.Price,
            IsAssetPurchasedByUser = false,
            IsAssetInCart = false
        };

        if (userId is not null)
        {
            user = await this.userRepository.GetById(Guid.Parse(userId));

            if (await this.IsUserPurchasedAssetAsync(user!.Id.ToString(), asset.Id.ToString()) ||
                await this.IsUserAssetOwnerAsync(user.OwnedShopId.ToString(), assetId))
            {
                assetModel.IsAssetPurchasedByUser = true;
            }
        }

        if (cartJson != null)
        {
            List<ShoppingCartDto> cart = JsonSerializer.Deserialize<List<ShoppingCartDto>>(cartJson)!;

            assetModel.IsAssetInCart = cart.Any(a => a.AssetId.ToString() == assetId);
        }

        var imagesKeys = await this.storageService.GetAssetImagesKeysAsync(assetId, AWSS3ImagesBucketName);

        assetModel.ImagesUrl = imagesKeys
            .Select(key => string.Format(AWSS3ImageUrl, AWSS3Region, assetId.ToLower(), key))
            .ToArray();

        return assetModel;
    }

    public async Task<EditAssetFormModel> GetEditAssetFormModelAsync(string assetId)
    {
        var asset = await this.assetRepository.GetById(Guid.Parse(assetId));

        return new EditAssetFormModel
        {
            AssetInfoModel = new AssetInfoFormModel
            {
                AssetId = asset!.Id,
                AssetTitle = asset.AssetName,
                Description = asset.Description,
                Version = asset.Version,
                Price = asset.Price,
                IsPublished = asset.IsPublic
            },
            AssetFileModel = new EditAssetFileFormModel
            {
                AssetId = asset.Id,
                CurrentlyUploadedFileName = asset.FileName
            },
            DeleteModel = new DeleteAssetFormModel
            {
                AssetId = asset.Id,
                ConfirmTitle = asset.AssetName
            }
        };
    }

    public Task<List<ManageAssetCardViewModel>> GetShopManagerAssetViewModelAsync(string shopId)
    {
        return this.assetRepository.GetAll()
            .Where(a => a.ShopId.ToString() == shopId && a.IsDeleted == false)
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
            var assetEntity = await this.assetRepository.GetAll().Include(a => a.Shop).AsNoTracking().FirstAsync(a => a.Id.ToString() == assetId);

            if (assetEntity.ShopId.ToString() == userShopId)
            {
                return true;
            }
        }

        return false;
    }

    public async Task<bool> IsUserPurchasedAssetAsync(string userId, string assetId)
    {
        var user = await this.userRepository.GetAll().Include(a => a.PurchasedAssets).AsNoTracking().FirstAsync(u => u.Id.ToString() == userId);

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

            var assetEntity = await this.assetRepository.GetById(model.AssetId);
            assetEntity!.FileName = newFileEncodedName;
            assetEntity.ModifiedOn = DateTime.UtcNow;

            await this.assetRepository.Save();

            await this.storageService.DeleteAsync(AWSS3AssetsBucketName, currentFileName, model.AssetId.ToString().ToLower());
        }
    }

    private async Task DeleteAllAssetFilesFromStorageAsync(string assetId, string assetFileName)
    {
        await this.storageService.DeleteAsync(AWSS3AssetsBucketName, assetFileName, assetId);

        var mediaKeys = await this.storageService.GetAssetImagesKeysAsync(assetId, AWSS3ImagesBucketName);

        foreach (var fileName in mediaKeys)
        {
            await this.storageService.DeleteAsync(AWSS3ImagesBucketName, fileName, assetId);
        }
    }

    public async Task<bool> IsAssetPurchasedByAnyUserAsync(string assetId)
    {
        var assetEntity = await this.assetRepository.GetById(Guid.Parse(assetId));

        if (assetEntity!.Users.Count > 0)
        {
            return true;
        }

        return false;
    }
}
