namespace GameAssetsStore.Web.ViewModels.Home;

public class AssetCardViewModel
{
    public Guid Id { get; set; }

    public string AssetName { get; set; } = null!;

    public decimal? Price { get; set; }
}
