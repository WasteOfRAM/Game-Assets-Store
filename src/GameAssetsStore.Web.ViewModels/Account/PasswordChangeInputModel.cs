namespace GameAssetsStore.Web.ViewModels.Account;

using System.ComponentModel.DataAnnotations;

public class PasswordChangeInputModel
{
    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Old Password")]
    public string OldPassword { get; set; } = null!;

    [Required]
    [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
    [DataType(DataType.Password)]
    [Display(Name = "New Password")]
    public string NewPassword { get; set; } = null!;

    [DataType(DataType.Password)]
    [Display(Name = "Confirm password")]
    [Compare("NewPassword", ErrorMessage = "The password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; } = null!;
}
