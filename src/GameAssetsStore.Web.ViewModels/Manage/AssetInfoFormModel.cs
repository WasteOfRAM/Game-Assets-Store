namespace GameAssetsStore.Web.ViewModels.Manage;

using System.ComponentModel.DataAnnotations;

using static Common.EntityValidationConstants.Asset;

public class AssetInfoFormModel
{
    [Required]
    public Guid AssetId { get; set; }

    [Required]
    [StringLength(AssetNameMaxLength, MinimumLength = AssetNameMinLength)]
    [RegularExpression(AssetNameAllowedCharacters, ErrorMessage = "Special symbols are not allowed.")]
    [Display(Name = "Title")]
    public string AssetTitle { get; set; } = null!;

    [StringLength(DescriptionMaxLength)]
    public string? Description { get; set; }


    [MaxLength(VersionMaxLength)]
    public string? Version { get; set; }

    public decimal? Price { get; set; }

    public bool IsPublished { get; set; }
}
