namespace GameAssetsStore.Services.Data.Interfaces;

using GameAssetsStore.Data.Models;
using Microsoft.AspNetCore.Identity;
using Web.ViewModels.Account;

public interface IAccountService
{
    Task<IdentityResult> RegisterAsync(SignUpInputModel inputModel);

    Task<SignInResult> SignInAsync(string userName, string password, bool isPersistent);

    Task SignOutAsync();

    Task<bool> AddUserClaim(ApplicationUser user, string claimType, string claimValue);
}
