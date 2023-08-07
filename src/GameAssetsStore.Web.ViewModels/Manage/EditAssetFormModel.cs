namespace GameAssetsStore.Web.ViewModels.Manage;

public class EditAssetFormModel
{
    public AssetInfoFormModel AssetInfoModel { get; set; } = null!;

    public EditAssetFileFormModel AssetFileModel { get; set; } = null!;

    public DeleteAssetFormModel DeleteModel { get; set; } = null!;
}
