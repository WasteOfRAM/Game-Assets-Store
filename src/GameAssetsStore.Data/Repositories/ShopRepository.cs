namespace GameAssetsStore.Data.Repositories;

using GameAssetsStore.Data.Models;
using GameAssetsStore.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class ShopRepository : EfRepositoryBase<Shop>, IShopRepository
{
    public ShopRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<bool> IsShopNameInUse(string shopName) => await this.DbSet.AnyAsync(s => s.ShopName == shopName);
}
