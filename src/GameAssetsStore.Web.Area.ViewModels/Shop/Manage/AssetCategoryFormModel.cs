namespace GameAssetsStore.Web.Area.ViewModels.Shop.Manage;

public class AssetCategoryFormModel
{
    public AssetCategoryFormModel()
    {
        this.SubCategories = new List<SubCategoryFormModel>();
    }

    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public List<SubCategoryFormModel> SubCategories { get; set; }
}
