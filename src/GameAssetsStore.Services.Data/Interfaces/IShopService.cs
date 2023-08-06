namespace GameAssetsStore.Services.Data.Interfaces;

using GameAssetsStore.Web.ViewModels.Shop;

public interface IShopService
{
    Task<BrowsePageViewModel> GetAllAssetsAsync(AssetQueryModel queryModel);

    Task<ShopHomePageViewModel> GetHomePageAssetsAsync();
}
