namespace GameAssetsStore.Web.ViewModels.Shop;

public class ShopHomePageViewModel
{
    public ShopHomePageViewModel()
    {
        this.AssetsByUploadDate = new HashSet<AssetCardViewModel>();
        this.FreeAssets = new HashSet<AssetCardViewModel>();
    }

    public ICollection<AssetCardViewModel> AssetsByUploadDate { get; set; }

    public ICollection<AssetCardViewModel> FreeAssets { get; set; }
}
