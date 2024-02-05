namespace GameAssetsStore.Web.ViewModels.Shop;

public class AssetQueryModel
{
    public string? Search { get; set; }

    public string[]? ArtStyles { get; set; }

    public string? Category { get; set; }

    public string[]? SubCategories { get; set; }
}
