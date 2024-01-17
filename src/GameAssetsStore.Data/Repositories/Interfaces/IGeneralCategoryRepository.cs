namespace GameAssetsStore.Data.Repositories.Interfaces;

using GameAssetsStore.Data.Models;

public interface IGeneralCategoryRepository : IRepository<GeneralCategory>
{
    Task<IEnumerable<GeneralCategory>> GetAllWithSubCategories();
}
