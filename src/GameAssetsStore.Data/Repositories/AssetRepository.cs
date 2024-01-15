namespace GameAssetsStore.Data.Repositories;

using GameAssetsStore.Data.Models;
using GameAssetsStore.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class AssetRepository : EfRepositoryBase<Asset>, IAssetRepository
{
    public AssetRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IEnumerable<Asset>> GetAllByShop(string shopId)
    {
        return await this.DbSet.Where(a => a.ShopId.ToString() == shopId).ToListAsync();
    }
}
