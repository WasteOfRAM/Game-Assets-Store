namespace GameAssetsStore.Data.Repositories;

using GameAssetsStore.Data.Models;
using GameAssetsStore.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class GeneralCategoryRepository : EfRepositoryBase<GeneralCategory>, IGeneralCategoryRepository
{
    public GeneralCategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IEnumerable<GeneralCategory>> GetAllWithSubCategories()
    {
        return await this.DbSet.Include(c => c.SubCategories).AsNoTracking().ToArrayAsync();
    }
}
