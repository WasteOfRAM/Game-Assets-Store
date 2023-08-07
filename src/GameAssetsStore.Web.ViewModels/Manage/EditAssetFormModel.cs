namespace GameAssetsStore.Web.ViewModels.Manage;

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

using static Common.EntityValidationConstants.Asset;

public class EditAssetFormModel
{
    public AssetInfoFormModel AssetInfo { get; set; } = null!;
}
