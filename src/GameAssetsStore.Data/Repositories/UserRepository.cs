namespace GameAssetsStore.Data.Repositories;

using Data.Models;
using Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class UserRepository : EfRepositoryBase<ApplicationUser>, IUserRepository
{
    public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<ApplicationUser?> GetByEmail(string email) => await this.DbSet.FirstOrDefaultAsync(u =>  u.Email == email);

    public async Task<ApplicationUser?> GetByUserName(string userName) => await this.DbSet.FirstOrDefaultAsync(u => u.UserName ==  userName);
}
