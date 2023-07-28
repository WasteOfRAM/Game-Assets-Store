namespace GameAssetsStore.Services.Data;

using GameAssetsStore.Data.Models;
using GameAssetsStore.Data.Repositories.Interfaces;
using GameAssetsStore.Services.Data.Interfaces;
using GameAssetsStore.Web.ViewModels.Manage;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

public class AssetService : IAssetService
{
    private readonly IRepository<Asset> assetRepository;
    private readonly IRepository<Shop> shopRepository;
    private readonly IRepository<GeneralCategory> categoriesRepository;
    private readonly IRepository<SubCategory> subCategoriesRepository;
    private readonly IRepository<ArtStyle> artStyleRepository;
    private readonly IObjectStoreService objectStoreService;

    public AssetService(IRepository<Asset> assetRepository,
        IRepository<Shop> shopRepository,
        IObjectStoreService objectStoreService,
        IRepository<GeneralCategory> categoriesRepository,
        IRepository<SubCategory> subCategoriesRepository,
        IRepository<ArtStyle> artStyleRepository)
    {
        this.assetRepository = assetRepository;
        this.shopRepository = shopRepository;
        this.objectStoreService = objectStoreService;
        this.categoriesRepository = categoriesRepository;
        this.subCategoriesRepository = subCategoriesRepository;
        this.artStyleRepository = artStyleRepository;
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

        bool isUploadSuccessful = await this.objectStoreService.UploadAsync(model.AssetFile, assetEntity.Id.ToString(), "asset");

        if (!isUploadSuccessful)
        {
            return false;
        }

        await this.assetRepository.SaveChangesAsync();

        await this.objectStoreService.UploadAsync(model.CoverImage, assetEntity.Id.ToString(), "cover");

        for (int i = 0; i < model.Images.Count(); i++)
        {
            await this.objectStoreService.UploadAsync(model.Images[i], assetEntity.Id.ToString(), $"media{i + 1}");
        }

        return true;
    }

    public Task<List<ManageAssetCardViewModel>> GetShopManagerAssetCarsAsync(string shopId)
    {
        return this.assetRepository.GetAllAsNoTracking()
            .Where(a => a.ShopId.ToString() == shopId)
            .Select(a => new ManageAssetCardViewModel
            {
                Id = a.Id,
                AssetName = a.AssetName,
                FileName = a.FileName,
                Description = a.Description,
                CoverImageUrl = this.objectStoreService.GetAssetCoverImagePath(a.Id.ToString()),
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
}
