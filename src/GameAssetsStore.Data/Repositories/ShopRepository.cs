namespace GameAssetsStore.Data.Repositories;

using GameAssetsStore.Data.Models;
using GameAssetsStore.Data.Repositories.Interfaces;

public class ShopRepository : EfRepositoryBase<Shop>, IShopRepository
{
    public ShopRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
