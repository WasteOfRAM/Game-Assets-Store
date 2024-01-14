namespace GameAssetsStore.Data.Repositories;

using GameAssetsStore.Data.Models;
using GameAssetsStore.Data.Repositories.Interfaces;

public class UserProfileRepository : EfRepositoryBase<UserProfile>, IUserProfileRepository
{
    public UserProfileRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
