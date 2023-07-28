namespace GameAssetsStore.Services.Data.Interfaces;

using GameAssetsStore.Web.ViewModels.Manage;

public interface IAssetService
{
    Task<bool> CreateAssetAsync(CreateAssetFormModel model, string shopId);

    Task<List<ManageAssetCardViewModel>> GetShopManagerAssetCarsAsync(string shopId);

    Task ChangeAssetVisibilityAsync(string assetId);

    Task<bool> IsUserAssetOwnerAsync(string? userShopId, string assetId);
}