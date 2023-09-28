namespace GameAssetsStore.Web.ViewModels.Shop;

public class ShoppingCartDto
{
    public Guid AssetId { get; set; }

    public string Title { get; set; } = null!;

    public string Price { get; set; } = null!;
}
