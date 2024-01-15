namespace GameAssetsStore.Data.Repositories.Interfaces;

using GameAssetsStore.Data.Models;

public interface IAssetRepository : IRepository<Asset>
{
    Task<IEnumerable<Asset>> GetAllByShop(string shopId);
}
