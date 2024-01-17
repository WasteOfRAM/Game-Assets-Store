namespace GameAssetsStore.Data.Repositories.Interfaces;

using GameAssetsStore.Data.Models;

public interface IShopRepository : IRepository<Shop>
{
    Task<bool> IsShopNameInUse(string shopName);
}
