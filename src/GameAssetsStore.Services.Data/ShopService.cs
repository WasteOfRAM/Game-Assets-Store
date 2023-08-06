namespace GameAssetsStore.Services.Data;

using GameAssetsStore.Data.Models;
using GameAssetsStore.Data.Repositories.Interfaces;
using GameAssetsStore.Services.Data.Interfaces;
using GameAssetsStore.Web.ViewModels.Shop;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

using static Common.GlobalConstants;

public class ShopService : IShopService
{
    private readonly IRepository<Asset> assetRepository;

    public ShopService(IRepository<Asset> assetRepository)
    {
        this.assetRepository = assetRepository;
    }

    public async Task<BrowsePageViewModel> GetAllAssetsAsync(AssetQueryModel queryModel)
    {
        var allAssetsQuery = this.assetRepository.GetAllAsNoTracking()
            .Where(a => a.IsPublic);

        BrowsePageViewModel viewModel = new BrowsePageViewModel();

        if (!string.IsNullOrWhiteSpace(queryModel.Search))
        {
            allAssetsQuery = allAssetsQuery
                .Where(a => a.AssetName.ToUpper().Contains(queryModel.Search.ToUpper()));
        }

        viewModel.FilteredAssets = await allAssetsQuery
            .Select(a => new AssetCardViewModel
            {
                Id = a.Id.ToString().ToLower(),
                AssetName = a.AssetName,
                Price = a.Price,
                ImageUrl = string.Format(AWSS3ImageUrl, AWSS3Region, a.Id.ToString().ToLower(), "cover")
            })
                .ToListAsync();

        return viewModel;
    }


    public async Task<ShopHomePageViewModel> GetHomePageAssetsAsync()
    {
        ShopHomePageViewModel model = new ShopHomePageViewModel();

        model.AssetsByUploadDate = await this.assetRepository.GetAllAsNoTracking()
            .Where(a => a.IsPublic)
            .OrderByDescending(a => a.CreatedOn)
            .Take(IndexPageAssetCountPerCategory)
            .Select(a => new AssetCardViewModel
            {
                Id = a.Id.ToString().ToLower(),
                AssetName = a.AssetName,
                Price = a.Price,
                ImageUrl = string.Format(AWSS3ImageUrl, AWSS3Region, a.Id.ToString().ToLower(), "cover")
            })
            .ToListAsync();

        model.FreeAssets = await this.assetRepository.GetAllAsNoTracking()
            .Where(a => a.IsPublic && a.Price == null)
            .Take(IndexPageAssetCountPerCategory)
            .Select(a => new AssetCardViewModel
            {
                Id = a.Id.ToString().ToLower(),
                AssetName = a.AssetName,
                Price = a.Price,
                ImageUrl = string.Format(AWSS3ImageUrl, AWSS3Region, a.Id.ToString().ToLower(), "cover")
            })
            .ToListAsync();

        return model;
    }
}
