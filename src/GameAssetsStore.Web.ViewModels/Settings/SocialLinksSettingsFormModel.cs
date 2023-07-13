namespace GameAssetsStore.Web.ViewModels.Settings;

using System.ComponentModel.DataAnnotations;

using Common.Enumerators;
using static Common.EntityValidationConstants.SocialLink;

public class SocialLinksSettingsFormModel
{
    [Required]
    public SocialType SocialType { get; set; }

    [Required]
    [StringLength(LinkMaxLength, MinimumLength = LinkMinLength)]
    public string SocialUrl { get; set; } = null!;
}
