namespace GameAssetsStore.Data.Repositories.Interfaces;

using GameAssetsStore.Data.Models;

public interface IUserRepository : IRepository<ApplicationUser>
{
    Task<ApplicationUser?> GetByEmail(string email);

    Task<ApplicationUser?> GetByUserName(string userName);

    Task<IEnumerable<Asset>> GetPurchasedAssets(Guid userId);

    Task<bool> IsUsernameInUse(string userName);
}
