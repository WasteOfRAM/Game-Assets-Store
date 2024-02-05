namespace GameAssetsStore.Services.Data;

using GameAssetsStore.Data.Repositories.Interfaces;
using GameAssetsStore.Services.Data.Interfaces;
using GameAssetsStore.Web.ViewModels.Shop;
using System.Threading.Tasks;

using static Common.GlobalConstants;

public class ShopService : IShopService
{
    private readonly IAssetRepository assetRepository;

    public ShopService(IAssetRepository assetRepository)
    {
        this.assetRepository = assetRepository;
    }

    public async Task<BrowsePageViewModel> GetAllAssetsAsync(AssetQueryModel queryModel)
    {
        var filteredAssets = await this.assetRepository.GetAllFiltered(queryModel);

        BrowsePageViewModel viewModel = new()
        {
            FilteredAssets = filteredAssets
                .Select(a => new AssetCardViewModel
                {
                    Id = a.Id.ToString().ToLower(),
                    AssetName = a.AssetName,
                    Price = a.Price,
                    ImageUrl = string.Format(AWSS3ImageUrl, AWSS3Region, a.Id.ToString().ToLower(), "cover")
                })
                .ToList()
        };

        return viewModel;
    }

    public async Task<ShopHomePageViewModel> GetHomePageAssetsAsync()
    {
        // TODO: Change implementation when assetRepository.GetAllFiltered() is ready
        // with pagination and ordering.

        ShopHomePageViewModel model = new();

        var assetsByDate = await this.assetRepository.GetAllFiltered(new AssetQueryModel());

        model.AssetsByUploadDate = assetsByDate
            .Where(a => a.IsPublic && a.IsDeleted == false)
            .OrderByDescending(a => a.CreatedOn)
            .Take(IndexPageAssetCountPerCategory)
            .Select(a => new AssetCardViewModel
            {
                Id = a.Id.ToString().ToLower(),
                AssetName = a.AssetName,
                Price = a.Price,
                ImageUrl = string.Format(AWSS3ImageUrl, AWSS3Region, a.Id.ToString().ToLower(), "cover")
            })
            .ToList();

        var freeAssets = await this.assetRepository.GetAllFiltered(new AssetQueryModel());

        model.FreeAssets = freeAssets
            .Where(a => a.IsPublic && a.IsDeleted == false && a.Price == null)
            .Take(IndexPageAssetCountPerCategory)
            .Select(a => new AssetCardViewModel
            {
                Id = a.Id.ToString().ToLower(),
                AssetName = a.AssetName,
                Price = a.Price,
                ImageUrl = string.Format(AWSS3ImageUrl, AWSS3Region, a.Id.ToString().ToLower(), "cover")
            })
            .ToList();

        return model;
    }
}
