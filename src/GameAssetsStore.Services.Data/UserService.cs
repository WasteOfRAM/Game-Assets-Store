namespace GameAssetsStore.Services.Data;

using Microsoft.EntityFrameworkCore;
using Services.Data.Interfaces;
using System.Threading.Tasks;

using GameAssetsStore.Data.Models;
using GameAssetsStore.Data.Repositories.Interfaces;
using GameAssetsStore.Web.ViewModels.User;
using GameAssetsStore.Web.ViewModels.Settings;

public class UserService : IUserService
{
    private readonly IRepository<UserProfile> profileRepo;

    public UserService(IRepository<UserProfile> profileRepo)
    {
        this.profileRepo = profileRepo;
    }

    public Task<PublicProfileViewModel?> GetUserProfileAsync(string username)
    {
        return Task.FromResult(this.profileRepo.GetAll()
            .Where(up => up.User.UserName == username)
            .Include(up => up.SocialLinks)
            .AsNoTracking()
            .AsEnumerable()
            .Select(up => new PublicProfileViewModel
            {
                Id = up.Id,
                Username = username,
                About = up.About,
                PublicEmail = up.PublicEmail,
                Website = up.Website,
                SocialLinks = up.SocialLinks.ToDictionary(l => l.SocialType.ToString(), l => l.LinkUrl)
            }).FirstOrDefault());
    }

    public async Task<ProfileSettingsFormModel> GetUserPublicProfileAsync(string userId)
    {
        return await this.profileRepo.GetAll()
            .Where(p => p.UserId.ToString() == userId)
            .Select(p => new ProfileSettingsFormModel
            {
                Id = p.Id,
                About = p.About,
                PublicEmail = p.PublicEmail,
                Website = p.Website
            })
            .FirstAsync();
    }

    public async Task UpdateUserPublicProfileAsync(ProfileSettingsFormModel model, string userId)
    {
        var entity = await this.profileRepo.GetAll()
            .Where(p => p.UserId.ToString() == userId)
            .FirstAsync();

        entity.About = model.About;
        entity.PublicEmail = model.PublicEmail; 
        entity.Website = model.Website;

        this.profileRepo.Update(entity);

        await this.profileRepo.SaveChangesAsync();
    }
}
