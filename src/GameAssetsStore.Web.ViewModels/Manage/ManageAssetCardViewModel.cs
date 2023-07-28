namespace GameAssetsStore.Web.ViewModels.Manage;

public class ManageAssetCardViewModel
{
    public Guid Id { get; set; }

    public string AssetName { get; set; } = null!;

    public string FileName { get; set; } = null!;

    public string CoverImageUrl { get; set; } = null!;

    public string? Description { get; set; }

    public string ArtStyle { get; set; } = null!;

    public decimal? Price { get; set; }

    public string? Version { get; set; }

    public int SalesCount { get; set; }

    public DateTime CreatedOn { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public bool IsPublic { get; set; }
}
