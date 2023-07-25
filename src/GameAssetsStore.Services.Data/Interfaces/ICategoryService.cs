namespace GameAssetsStore.Services.Data.Interfaces;

using GameAssetsStore.Web.Area.ViewModels.Shop.Manage;

public interface ICategoryService
{
    Task<List<AssetCategoryFormModel>> GetAllCategoriesWithSubCategoriesAsync();
}
