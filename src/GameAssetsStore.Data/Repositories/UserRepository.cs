namespace GameAssetsStore.Data.Repositories;

using Data.Models;
using Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class UserRepository : EfRepositoryBase<ApplicationUser>, IUserRepository
{
    public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<ApplicationUser?> GetByEmail(string email) => await this.DbSet.FirstOrDefaultAsync(u =>  u.Email == email);

    public async Task<ApplicationUser?> GetByUserName(string userName) => await this.DbSet.FirstOrDefaultAsync(u => u.UserName ==  userName);

    public async Task<IEnumerable<Asset>> GetPurchasedAssets(Guid userId)
    {
        var user = await this.DbSet.Include(u => u.PurchasedAssets).FirstOrDefaultAsync(u => u.Id == userId);

        return user!.PurchasedAssets;
    }

    public async Task<bool> IsUsernameInUse(string userName) => await this.DbSet.AnyAsync(u => u.UserName == userName);
}
