namespace GameAssetsStore.Services.Data.Interfaces;

using GameAssetsStore.Services.Models.Asset;
using GameAssetsStore.Web.ViewModels.Manage;

public interface IAssetService
{
    Task<bool> CreateAssetAsync(CreateAssetFormModel model, string shopId);

    Task<DownloadAssetServiceModel> DownloadAsync(string assetId);

    Task<List<ManageAssetCardViewModel>> GetShopManagerAssetCardsAsync(string shopId);

    Task ChangeAssetVisibilityAsync(string assetId);

    Task<bool> IsUserAssetOwnerAsync(string? userShopId, string assetId);

    Task<bool> IsUserPurchasedAssetAsync(string userId, string assetId);
}