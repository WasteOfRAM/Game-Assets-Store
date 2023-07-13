namespace GameAssetsStore.Web.ViewModels.Settings;

using System.ComponentModel.DataAnnotations;

using static Common.EntityValidationConstants.SocialLink;
using static Common.EntityValidationConstants.UserProfile;

public class ProfileSettingsFormModel
{
    public Guid Id { get; set; }

    // CREATE AccountSettingsFormModel and MOVE Username and Email there
    //[Required]
    //[StringLength(UserNameMaxLength, MinimumLength = UserNameMinLength)]
    //[RegularExpression(UserNameAllowedCharacters, ErrorMessage = "The {0} must contain only letter, number, \".\" or \"-\" characters.")]
    //public string Username { get; set; } = null!;

    //[Required]
    //[EmailAddress]
    //public string Email { get; set; } = null!;

    [MaxLength(AboutMaxLength)]
    public string? About { get; set; }

    [EmailAddress]
    public string? PublicEmail { get; set; }

    [StringLength(LinkMaxLength, MinimumLength = LinkMinLength)]
    public string? Website { get; set; }
}
