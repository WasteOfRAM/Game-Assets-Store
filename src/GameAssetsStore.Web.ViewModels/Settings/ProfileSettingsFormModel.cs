namespace GameAssetsStore.Web.ViewModels.Settings;

using System.ComponentModel.DataAnnotations;

using static Common.EntityValidationConstants.ApplicationUser;

public class ProfileSettingsFormModel
{
    public Guid Id { get; set; }

    [Required]
    [StringLength(UserNameMaxLength, MinimumLength = UserNameMinLength)]
    [RegularExpression(UserNameAllowedCharacters, ErrorMessage = "The {0} must contain only letter, number, \".\" or \"-\" characters.")]
    public string Username { get; set; } = null!;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;

    [EmailAddress]
    public string? PublicEmail { get; set; }

    public string? Website { get; set; }


}
