namespace GameAssetsStore.Services.Data.Interfaces;

using GameAssetsStore.Web.ViewModels.Manage;

public interface ICategoryService
{
    Task<List<AssetCategoryFormModel>> GetAllCategoriesWithSubCategoriesAsync();
}
