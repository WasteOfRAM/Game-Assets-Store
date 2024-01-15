namespace GameAssetsStore.Services.Data;

using GameAssetsStore.Data.Models;
using GameAssetsStore.Data.Repositories.Interfaces;
using GameAssetsStore.Web.ViewModels.Settings;
using GameAssetsStore.Web.ViewModels.Shop;
using GameAssetsStore.Web.ViewModels.User;
using Microsoft.EntityFrameworkCore;
using Services.Data.Interfaces;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

using static Common.GlobalConstants;

/// <summary>
/// Handling users public profile sections settings.
/// </summary>
public class UserService : IUserService
{
    private readonly IRepository<UserProfile> profileRepository;
    private readonly IRepository<ApplicationUser> userRepository;
    private readonly IAccountService accountService;
    private readonly IRepository<Shop> shopRepository;
    private readonly IRepository<PaymentMethod> paymentMethodRepository;
    private readonly IRepository<Asset> assetRepository;

    public UserService(IRepository<UserProfile> profileRepository,
        IRepository<ApplicationUser> userRepository,
        IAccountService accountService,
        IRepository<Shop> shopRepository,
        IRepository<PaymentMethod> paymentMethodRepository,
        IRepository<Asset> assetRepository)
    {
        this.profileRepository = profileRepository;
        this.userRepository = userRepository;
        this.accountService = accountService;
        this.shopRepository = shopRepository;
        this.paymentMethodRepository = paymentMethodRepository;
        this.assetRepository = assetRepository;
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
            .AsNoTracking()
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

            await this.profileRepository.Save();
        }
    }

    public async Task<Guid> CreateShopAsync(CreateShopInputModel model, string userId)
    {
        var user = await this.userRepository.GetById(Guid.Parse(userId));

        var shop = new Shop
        {
            OwningUser = user!,
            OwningUserId = user!.Id,
            ShopName = model.ShopName ?? user.UserName!
        };

        var paymentMethod = new PaymentMethod
        {
            Name = "Bank"
        };

        user.OwnedShop = shop;
        user.PaymentMethod = paymentMethod;

        await this.paymentMethodRepository.Add(paymentMethod);
        await this.shopRepository.Add(shop);
        await this.shopRepository.Save();

        await this.accountService.AddUserClaim(user, ShopOwnerClaimType, shop.Id.ToString());

        return shop.Id;
    }

    public async Task<bool> IsShopNameAvailableAsync(string? shopName)
    {
        if (shopName != null &&
            await this.userRepository.GetAll().AsNoTracking().AnyAsync(u => u.UserName == shopName) ||
            await this.shopRepository.GetAll().AsNoTracking().AnyAsync(s => s.ShopName == shopName))
        {
            return false;
        }

        return true;
    }

    public async Task AddPurchasedAssetsAsync(string userId, string? assetsJson)
    {
        if (assetsJson == null)
        {
            throw new NullReferenceException("The cart was not retrieved.");
        }

        List<ShoppingCartDto> cart = JsonSerializer.Deserialize<List<ShoppingCartDto>>(assetsJson)!;

        var user = await this.userRepository.GetById(Guid.Parse(userId));

        foreach (var asset in cart)
        {
            var assetEntity = await this.assetRepository.GetById(asset.AssetId);

            user!.PurchasedAssets.Add(assetEntity!);
        }

        await this.assetRepository.Save();
    }

    public async Task<IEnumerable<LibraryAssetCardViewModel>> GetUserLibraryAssetsAsync(string userId)
    {
        var user = await this.userRepository.GetAll()
            .Include(u => u.PurchasedAssets)
            .AsNoTracking()
            .FirstAsync(u => u.Id.ToString() == userId);

        return user.PurchasedAssets
            .Select(a => new LibraryAssetCardViewModel
            {
                Id = a.Id.ToString(),
                AssetName = a.AssetName,
                ImageUrl = string.Format(AWSS3ImageUrl, AWSS3Region, a.Id.ToString().ToLower(), "cover")
            }).ToArray();
    }
}
