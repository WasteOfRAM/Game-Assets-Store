namespace GameAssetsStore.Web.Area.ViewModels.Shop.Manage;

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

using static Common.EntityValidationConstants.Asset;

public class CreateAssetFormModel
{
    public CreateAssetFormModel()
    {
        this.Categories = new List<AssetCategoryFormModel>();
    }

    [Required]
    [StringLength(AssetNameMaxLength, MinimumLength = AssetNameMinLength)]
    [RegularExpression(AssetNameAllowedCharacters)]
    [Display(Name = "Title")]
    public string AssetTitle { get; set; } = null!;

    [StringLength(DescriptionMaxLength)]
    public string? Description { get; set; }

    public decimal? Price { get; set; }

    [MaxLength(VersionMaxLength)]
    public string? Version { get; set; }

    [Required]
    public List<IFormFile> Images { get; set; } = null!;

    [Required]
    [Display(Name ="Asset file")]
    public IFormFile AssetFile { get; set; } = null!;

    [Required]
    [Display(Name = "Cover Image")]
    public IFormFile CoverImage { get; set; } = null!;

    public List<AssetCategoryFormModel> Categories { get; set; }
}
