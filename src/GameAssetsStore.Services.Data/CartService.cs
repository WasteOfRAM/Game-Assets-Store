namespace GameAssetsStore.Services.Data;

using GameAssetsStore.Data.Models;
using GameAssetsStore.Data.Repositories.Interfaces;
using GameAssetsStore.Services.Data.Interfaces;
using GameAssetsStore.Web.ViewModels.Shop;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

public class CartService : ICartService
{
    private readonly IRepository<Asset> assetRepository;
    private readonly IRepository<ApplicationUser> userRepository;

    public CartService(
        IRepository<Asset> assetRepository,
        IRepository<ApplicationUser> userRepository)
    {
        this.assetRepository = assetRepository;
        this.userRepository = userRepository;

    }

    public async Task<CheckoutViewModel> GetCheckoutCartAssetsAsync(string userId, string? cartJson)
    {
        if (cartJson == null)
        {
            throw new NullReferenceException("The cart was not retrieved.");
        }

        List<ShoppingCartDto> cart = JsonSerializer.Deserialize<List<ShoppingCartDto>>(cartJson)!;

        var checkoutModel = new CheckoutViewModel();

        foreach (var asset in cart)
        {
            var assetEntity = await this.assetRepository.GetAllAsNoTracking().FirstAsync(a => a.Id.ToString() == asset.AssetId);

            checkoutModel.CheckoutAssets.Add(new CheckoutAssetViewModel { AssetId = assetEntity.Id.ToString(), Title = assetEntity.AssetName });

            checkoutModel.PriceTotal += assetEntity.Price ?? 0.0m;
        }

        var user = await this.userRepository.GetAllAsNoTracking().Include(e => e.PaymentMethod).FirstAsync(u => u.Id.ToString() == userId);

        checkoutModel.PaymentMethodId = user.PaymentMethodId?.ToString();
        checkoutModel.PaymentMethodName = user.PaymentMethod?.Name;

        return checkoutModel;
    }
}
