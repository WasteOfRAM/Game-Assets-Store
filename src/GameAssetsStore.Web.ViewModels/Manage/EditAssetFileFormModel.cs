namespace GameAssetsStore.Web.ViewModels.Manage;

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

public class EditAssetFileFormModel
{
    [Required]
    public Guid AssetId { get; set; }

    [Required]
    [Display(Name = "Asset file")]
    public IFormFile AssetFile { get; set; } = null!;

    public string CurrentlyUploadedFileName { get; set; } = null!;
}
