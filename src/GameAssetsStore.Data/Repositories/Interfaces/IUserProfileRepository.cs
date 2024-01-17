namespace GameAssetsStore.Data.Repositories.Interfaces;

using GameAssetsStore.Data.Models;

public interface IUserProfileRepository : IRepository<UserProfile>
{
    Task<UserProfile?> GetByUsername(string username);

    Task<UserProfile?> GetByUserId(Guid userId);
}
