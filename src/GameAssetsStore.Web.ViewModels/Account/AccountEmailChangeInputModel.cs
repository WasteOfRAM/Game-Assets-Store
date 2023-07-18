namespace GameAssetsStore.Web.ViewModels.Account;

using System.ComponentModel.DataAnnotations;

public class AccountEmailChangeInputModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;
}
