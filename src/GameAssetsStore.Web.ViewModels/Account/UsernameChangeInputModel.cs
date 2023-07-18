namespace GameAssetsStore.Web.ViewModels.Account;

using System.ComponentModel.DataAnnotations;

using static Common.EntityValidationConstants.ApplicationUser;

public class UsernameChangeInputModel
{
    [Required]
    [StringLength(UserNameMaxLength, MinimumLength = UserNameMinLength)]
    [RegularExpression(UserNameAllowedCharacters, ErrorMessage = "The {0} must contain only letter, number, \".\", \"-\" or \"_\" characters.")]
    public string Username { get; set; } = null!;
}
