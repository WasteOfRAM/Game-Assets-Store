namespace GameAssetsStore.Web.ViewModels.Account;

using System.ComponentModel.DataAnnotations;

using static Common.EntityValidationConstants.ApplicationUser;

public class SignUpInputModel
{
    [Required]
    [StringLength(UserNameMaxLength, MinimumLength = UserNameMinLength)]
    [RegularExpression(UserNameAllowedCharacters, ErrorMessage = "The {0} must contain only letter, number, \".\", \"-\" or \"_\" characters.")]
    [Display(Name = "Username")]
    public string Username { get; set; } = null!;

    [Required]
    [EmailAddress]
    [Display(Name = "Email")]
    public string Email { get; set; } = null!;

    [Required]
    [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; } = null!;

    [DataType(DataType.Password)]
    [Display(Name = "Confirm password")]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; } = null!;
}
