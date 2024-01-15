namespace GameAssetsStore.Data.Repositories;

using GameAssetsStore.Data.Models;
using GameAssetsStore.Data.Repositories.Interfaces;
using GameAssetsStore.Web.ViewModels.Shop;
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

    public async Task<IEnumerable<Asset>> GetAllFiltered(AssetQueryModel assetQueryModel)
    {
        var allAssetsQuery = this.DbSet.Where(a => a.IsPublic && a.IsDeleted == false);

        if (!string.IsNullOrWhiteSpace(assetQueryModel.Search))
        {
            allAssetsQuery = allAssetsQuery
                .Where(a => a.AssetName.Contains(assetQueryModel.Search, StringComparison.CurrentCultureIgnoreCase));
        }

        return await allAssetsQuery.ToArrayAsync();
    }
}
