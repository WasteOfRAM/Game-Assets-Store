namespace GameAssetsStore.Data.Repositories;

using GameAssetsStore.Data.Models;
using GameAssetsStore.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

public class UserProfileRepository : EfRepositoryBase<UserProfile>, IUserProfileRepository
{
    public UserProfileRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<UserProfile?> GetByUserId(Guid userId)
    {
        return await this.DbSet.FirstOrDefaultAsync(p => p.UserId == userId);
    }

    public async Task<UserProfile?> GetByUsername(string username)
    {
        return await this.DbSet.Include(p => p.User).FirstOrDefaultAsync(p => p.User.UserName == username);
    }
}
