namespace GameAssetsStore.Web.ViewModels.Shop;

using GameAssetsStore.Web.ViewModels.Manage;

public class BrowsePageViewModel
{
    public BrowsePageViewModel()
    {
        this.FilteredAssets = new HashSet<AssetCardViewModel>();
        this.CategoriesList = new HashSet<AssetCategoryFormModel>();
    }

    public ICollection<AssetCardViewModel> FilteredAssets { get; set; }

    public IEnumerable<AssetCategoryFormModel> CategoriesList { get; set; }
}
