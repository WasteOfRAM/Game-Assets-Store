namespace GameAssetsStore.Web.ViewModels.Manage;

public class AssetCategoryFormModel
{
    public AssetCategoryFormModel()
    {
        SubCategories = new List<SubCategoryFormModel>();
    }

    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public List<SubCategoryFormModel> SubCategories { get; set; }
}
