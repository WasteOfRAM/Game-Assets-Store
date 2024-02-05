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

        if (assetQueryModel.Category is not null)
        {
            allAssetsQuery = allAssetsQuery
                .Where(a => a.GeneralCategories.Any(c => c.Name.ToUpper() == assetQueryModel.Category.ToUpper()));
        }

        if (assetQueryModel.SubCategories is not null &&
            assetQueryModel.SubCategories.Length > 0)
        {
            allAssetsQuery = allAssetsQuery
                .Where(a => a.SubCategories.Any(c => assetQueryModel.SubCategories.Select(c => c.ToUpper()).Contains(c.Name.ToUpper())));
        }

        if (assetQueryModel.ArtStyles is not null)
        {
            allAssetsQuery = allAssetsQuery
                .Where(a => assetQueryModel.ArtStyles.Select(a => a.ToUpper()).Contains(a.ArtStyle.Name.ToUpper()));
        }

        if (!string.IsNullOrWhiteSpace(assetQueryModel.Search))
        {
            allAssetsQuery = allAssetsQuery
                .Where(a => a.AssetName.ToUpper().Contains(assetQueryModel.Search.ToUpper()));
        }

        // TODO: Include methods added only for testing remove it when done.

        return await allAssetsQuery.AsNoTracking().Include(a => a.GeneralCategories).Include(a => a.SubCategories).Include(a => a.ArtStyle).ToListAsync();
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
