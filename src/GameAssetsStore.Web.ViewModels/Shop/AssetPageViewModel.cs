namespace GameAssetsStore.Web.ViewModels.Shop;

public class AssetPageViewModel
{
    public AssetPageViewModel()
    {
        this.ImagesUrl = new HashSet<string>();
    }

    public string AssetTile { get; set; } = null!;

    public decimal? Price { get; set; }

    public string? Description { get; set; }

    public IEnumerable<string> ImagesUrl { get; set; }
}
