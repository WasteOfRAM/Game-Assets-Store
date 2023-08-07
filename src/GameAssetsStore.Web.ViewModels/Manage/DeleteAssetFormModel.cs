namespace GameAssetsStore.Web.ViewModels.Manage;

using System.ComponentModel.DataAnnotations;

public class DeleteAssetFormModel
{
    [Required]
    public Guid AssetId { get; set; }

    [Required]
    public string Title { get; set; } = null!;

    [Compare("Title", ErrorMessage = "Input does not match with asset title.")]
    public string ConfirmTitle { get; set; } = null!;
}
