﻿namespace GameAssetsStore.Services.Data;

using GameAssetsStore.Data.Models;
using GameAssetsStore.Data.Repositories.Interfaces;
using GameAssetsStore.Services.Data.Interfaces;
using GameAssetsStore.Services.Models.Asset;
using GameAssetsStore.Web.ViewModels.Manage;
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

    public Task<List<ManageAssetCardViewModel>> GetShopManagerAssetCardsAsync(string shopId)
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
}
