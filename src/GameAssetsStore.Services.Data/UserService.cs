namespace GameAssetsStore.Services.Data;

using Microsoft.EntityFrameworkCore;
using Services.Data.Interfaces;
using System.Threading.Tasks;

using GameAssetsStore.Data.Models;
using GameAssetsStore.Data.Repositories.Interfaces;
using GameAssetsStore.Web.ViewModels.User;
using GameAssetsStore.Web.ViewModels.Settings;
using System.Net;

/// <summary>
/// Handling users public profile sections settings.
/// </summary>
public class UserService : IUserService
{
    private readonly IRepository<UserProfile> profileRepository;
    private readonly IRepository<ApplicationUser> userRepository;
    private readonly IAccountService accountService;
    private readonly IRepository<Shop> shopRepository;

    public UserService(IRepository<UserProfile> profileRepository, 
        IRepository<ApplicationUser> userRepository,
        IAccountService accountService,
        IRepository<Shop> shopRepository)
    {
        this.profileRepository = profileRepository;
        this.userRepository = userRepository;
        this.accountService = accountService;
        this.shopRepository = shopRepository;
    }

    public Task<PublicProfileViewModel?> GetUserProfileAsync(string username)
    {
        return Task.FromResult(this.profileRepository.GetAll()
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
        return await this.profileRepository.GetAll()
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
        var entity = await this.profileRepository.GetAll()
            .Where(p => p.UserId.ToString() == userId)
            .FirstAsync();

        var aboutEncoded = WebUtility.HtmlEncode(model.About);

        if (entity.About != aboutEncoded ||
            entity.PublicEmail != model.PublicEmail ||
            entity.Website != model.Website)
        {
            entity.About = aboutEncoded;
            entity.PublicEmail = model.PublicEmail;
            entity.Website = model.Website;

            this.profileRepository.Update(entity);

            await this.profileRepository.SaveChangesAsync();
        }
    }

    public async Task<Guid> CreateShopAsync(CreateShopInputModel model, string userId)
    {
        var user = await this.userRepository.GetAll().FirstAsync(u => u.Id.ToString() == userId);
        
        var shop = new Shop
        {
            OwningUser = user,
            OwningUserId = Guid.Parse(userId),
            ShopName = model.ShopName ?? user.UserName
        };

        user.OwnedShop = shop;

        await this.shopRepository.AddAsync(shop);
        await this.shopRepository.SaveChangesAsync();

        await this.accountService.AddUserClaim(user, "urn:shop:shopId", shop.Id.ToString());

        return shop.Id;
    }

    public async Task<bool> IsShopNameAvailableAsync(string? shopName)
    {
        if (shopName != null &&
            await this.userRepository.GetAll().AnyAsync(u => u.UserName == shopName) ||
            await this.shopRepository.GetAll().AnyAsync(s => s.ShopName == shopName))
        {
            return false;
        }

        return true;
    }
}
