namespace GameAssetsStore.Services.Data.Interfaces;

using GameAssetsStore.Web.Area.ViewModels.Shop.Manage;

public interface IAssetService
{
    Task<bool> CreateAssetAsync(CreateAssetFormModel model, string shopId);
}
