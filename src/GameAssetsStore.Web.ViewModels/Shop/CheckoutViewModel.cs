namespace GameAssetsStore.Web.ViewModels.Shop;

public class CheckoutViewModel
{
    public CheckoutViewModel()
    {
        this.CheckoutAssets = new HashSet<CheckoutAssetViewModel>();
    }

    public ICollection<CheckoutAssetViewModel> CheckoutAssets { get; set; }

    public decimal PriceTotal { get; set; }

    public string? PaymentMethodName { get; set; }

    public string? PaymentMethodId { get; set; }
}
