namespace GameAssetsStore.Services.Data.Interfaces;

using GameAssetsStore.Data.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Web.ViewModels.Account;

public interface IAccountService
{
    Task<IdentityResult> RegisterAsync(SignUpInputModel inputModel);

    Task<SignInResult> SignInAsync(string userName, string password, bool isPersistent);

    Task SignOutAsync();

    Task<bool> AddUserClaim(ApplicationUser user, string claimType, string claimValue);

    Task<bool> IsUsernameInUseAsync(string userName);

    Task<bool> IsEmailInUseAsync(string email);

    Task<IdentityResult> ChangeUsernameAsync(ClaimsPrincipal userPrincipal, string username);

    Task<IdentityResult> ChangeEmailAsync(ClaimsPrincipal userPrincipal, string email);

    Task<IdentityResult> ChangePasswordAsync(ClaimsPrincipal userPrincipal, string oldPassword, string newPassword);

    Task AddPaymentMethodAsync(string userId);
}
