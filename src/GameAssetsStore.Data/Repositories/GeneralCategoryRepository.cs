namespace GameAssetsStore.Data.Repositories;

using GameAssetsStore.Data.Models;
using GameAssetsStore.Data.Repositories.Interfaces;

public class GeneralCategoryRepository : EfRepositoryBase<GeneralCategory>, IGeneralCategoryRepository
{
    public GeneralCategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
