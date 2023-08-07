namespace GameAssetsStore.Services.Data.Interfaces;

using GameAssetsStore.Services.Models.Asset;
using GameAssetsStore.Web.ViewModels.Manage;
using GameAssetsStore.Web.ViewModels.Shop;

public interface IAssetService
{
    Task<bool> CreateAssetAsync(CreateAssetFormModel model, string shopId);

    Task<DownloadAssetServiceModel> DownloadAsync(string assetId);

    Task AssetSoftDeleteAsync(string assetId);

    Task<List<ManageAssetCardViewModel>> GetShopManagerAssetViewModelAsync(string shopId);

    Task<AssetPageViewModel> GetAssetPageViewModelAsync(string assetId);

    Task<EditAssetFormModel> GetEditAssetFormModelAsync(string assetId);

    Task ChangeAssetVisibilityAsync(string assetId);

    Task EditAssetInfoAsync(AssetInfoFormModel model);

    Task UpdateAssetFileAsync(EditAssetFileFormModel model);

    Task<bool> IsUserAssetOwnerAsync(string? userShopId, string assetId);

    Task<bool> IsUserPurchasedAssetAsync(string userId, string assetId);

    Task<bool> IsAssetPurchasedByAnyUserAsync(string assetId);
}