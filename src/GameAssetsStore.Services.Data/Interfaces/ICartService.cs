namespace GameAssetsStore.Services.Data.Interfaces;

using GameAssetsStore.Web.ViewModels.Shop;

public interface ICartService
{
    Task<CheckoutViewModel> GetCheckoutCartAssetsAsync(string userId, string? cartJson);
}
