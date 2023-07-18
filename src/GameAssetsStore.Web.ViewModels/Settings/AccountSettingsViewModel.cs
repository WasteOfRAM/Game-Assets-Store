namespace GameAssetsStore.Web.ViewModels.Settings;

using GameAssetsStore.Web.ViewModels.Account;

public class AccountSettingsViewModel
{
    public UsernameChangeInputModel UsernameChange { get; set; } = null!;

    public AccountEmailChangeInputModel EmailChange { get; set; } = null!;

    public PasswordChangeInputModel PasswordChange { get; set; } = null!;
}
