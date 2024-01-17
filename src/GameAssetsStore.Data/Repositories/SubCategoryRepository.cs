namespace GameAssetsStore.Data.Repositories;

using GameAssetsStore.Data.Models;
using GameAssetsStore.Data.Repositories.Interfaces;

public class SubCategoryRepository : EfRepositoryBase<SubCategory>, ISubCategoryRepository
{
    public SubCategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
