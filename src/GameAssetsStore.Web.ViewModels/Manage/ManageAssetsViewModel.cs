namespace GameAssetsStore.Web.ViewModels.Manage;
public class ManageAssetsViewModel
{
    public ManageAssetsViewModel()
    {
        ShopAssets = new List<ManageAssetCardViewModel>();
    }

    public List<ManageAssetCardViewModel> ShopAssets { get; set; }
}
