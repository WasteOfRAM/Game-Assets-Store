namespace GameAssetsStore.Services.Data;

using GameAssetsStore.Data.Repositories.Interfaces;
using GameAssetsStore.Services.Data.Interfaces;
using GameAssetsStore.Web.ViewModels.Shop;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

public class CartService : ICartService
{
    private readonly IAssetRepository assetRepository;
    private readonly IUserRepository userRepository;

    public CartService(
        IAssetRepository assetRepository,
        IUserRepository userRepository)
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
            var assetEntity = await this.assetRepository.GetById(asset.AssetId);

            checkoutModel.CheckoutAssets.Add(new CheckoutAssetViewModel { AssetId = assetEntity!.Id.ToString(), Title = assetEntity.AssetName });

            checkoutModel.PriceTotal += assetEntity.Price ?? 0.0m;
        }

        var user = await this.userRepository.GetById(Guid.Parse(userId));

        checkoutModel.PaymentMethodId = user!.PaymentMethodId?.ToString();
        checkoutModel.PaymentMethodName = user.PaymentMethod?.Name;

        return checkoutModel;
    }
}
