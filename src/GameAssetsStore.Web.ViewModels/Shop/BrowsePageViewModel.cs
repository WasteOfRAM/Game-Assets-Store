namespace GameAssetsStore.Web.ViewModels.Shop;

public class BrowsePageViewModel
{
    public BrowsePageViewModel()
    {
        this.FilteredAssets = new HashSet<AssetCardViewModel>();
    }

    public ICollection<AssetCardViewModel> FilteredAssets { get; set; }
}
