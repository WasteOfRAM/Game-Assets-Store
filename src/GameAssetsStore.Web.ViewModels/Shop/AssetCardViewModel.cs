namespace GameAssetsStore.Web.ViewModels.Shop;

public class AssetCardViewModel
{
    public string Id { get; set; } = null!;

    public string AssetName { get; set; } = null!;

    public decimal? Price { get; set; }

    public string ImageUrl { get; set; } = null!;
}
