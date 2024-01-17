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
    private readonly IUserProfileRepository profileRepository;
    private readonly IUserRepository userRepository;
    private readonly IAccountService accountService;
    private readonly IShopRepository shopRepository;
    private readonly IPaymentMethodRepository paymentMethodRepository;
    private readonly IAssetRepository assetRepository;

    public UserService(IUserProfileRepository profileRepository,
        IUserRepository userRepository,
        IAccountService accountService,
        IShopRepository shopRepository,
        IPaymentMethodRepository paymentMethodRepository,
        IAssetRepository assetRepository)
    {
        this.profileRepository = profileRepository;
        this.userRepository = userRepository;
        this.accountService = accountService;
        this.shopRepository = shopRepository;
        this.paymentMethodRepository = paymentMethodRepository;
        this.assetRepository = assetRepository;
    }

    public async Task<PublicProfileViewModel?> GetUserProfileAsync(string username)
    {
        var userProfile = await this.profileRepository.GetByUsername(username);

        if (userProfile is not null)
        {
            return new PublicProfileViewModel
            {
                Id = userProfile.Id,
                Username = username,
                About = userProfile.About,
                PublicEmail = userProfile.PublicEmail,
                Website = userProfile.Website,
                SocialLinks = userProfile.SocialLinks.ToDictionary(l => l.SocialType.ToString(), l => l.LinkUrl)
            };
        }

        return null;
    }

    public async Task<ProfileSettingsFormModel> GetUserPublicProfileAsync(string userId)
    {
        var userProfile = await this.profileRepository.GetByUserId(Guid.Parse(userId));

        return new ProfileSettingsFormModel
            {
                Id = userProfile!.Id,
                About = userProfile.About,
                PublicEmail = userProfile.PublicEmail,
                Website = userProfile.Website
            };
    }

    public async Task UpdateUserPublicProfileAsync(ProfileSettingsFormModel model, string userId)
    {
        var entity = await this.profileRepository.GetByUserId(Guid.Parse(userId));

        var aboutEncoded = WebUtility.HtmlEncode(model.About);

        if (entity!.About != aboutEncoded ||
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

        await this.paymentMethodRepository.Add(paymentMethod);
        await this.shopRepository.Add(shop);
        await this.shopRepository.Save();

        user.OwnedShopId = shop.Id;
        user.PaymentMethod = paymentMethod;

        await this.accountService.AddUserClaim(user, ShopOwnerClaimType, shop.Id.ToString());

        return shop.Id;
    }

    public async Task<bool> IsShopNameAvailableAsync(string? shopName)
    {
        if (shopName != null &&
            await this.userRepository.IsUsernameInUse(shopName) ||
            await this.shopRepository.IsShopNameInUse(shopName!))
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
        var purchasedAssets = await this.userRepository.GetPurchasedAssets(Guid.Parse(userId));

        return purchasedAssets
            .Select(a => new LibraryAssetCardViewModel
            {
                Id = a.Id.ToString(),
                AssetName = a.AssetName,
                ImageUrl = string.Format(AWSS3ImageUrl, AWSS3Region, a.Id.ToString().ToLower(), "cover")
            }).ToArray();
    }
}
