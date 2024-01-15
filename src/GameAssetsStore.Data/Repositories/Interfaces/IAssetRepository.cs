namespace GameAssetsStore.Data.Repositories.Interfaces;

using GameAssetsStore.Data.Models;
using GameAssetsStore.Web.ViewModels.Shop;

public interface IAssetRepository : IRepository<Asset>
{
    Task<IEnumerable<Asset>> GetAllByShop(string shopId);

    Task<IEnumerable<Asset>> GetAllFiltered(AssetQueryModel assetQueryModel);
}
