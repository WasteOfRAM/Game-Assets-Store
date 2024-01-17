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
        return await this.DbSet
            .Include(a => a.ArtStyle)
            .Where(a => a.ShopId.ToString() == shopId && a.IsDeleted == false)
            .ToListAsync();
    }

    public async Task<IEnumerable<Asset>> GetAllFiltered(AssetQueryModel assetQueryModel)
    {
        var allAssetsQuery = this.DbSet.Where(a => a.IsPublic && a.IsDeleted == false);

        if (!string.IsNullOrWhiteSpace(assetQueryModel.Search))
        {
            allAssetsQuery = allAssetsQuery
                .Where(a => a.AssetName.ToUpper().Contains(assetQueryModel.Search.ToUpper()));
        }

        return await allAssetsQuery.ToArrayAsync();
    }

    public override void Delete(Asset entity)
    {
        entity.AssetName = "DELETED";
        entity.FileName = "DELETED";
        entity.Description = "DELETED";
        entity.Version = "DELETED";
        entity.IsDeleted = true;
        entity.IsPublic = false;
        entity.DeletedOn = DateTime.UtcNow;

        var entry = this.DbSet.Entry(entity);

        if (entry.State == EntityState.Detached)
        {
            this.DbSet.Attach(entity);
        }

        entry.State = EntityState.Modified;
    }
}
