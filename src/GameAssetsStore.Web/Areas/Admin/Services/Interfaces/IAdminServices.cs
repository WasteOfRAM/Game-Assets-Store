namespace GameAssetsStore.Web.Areas.Admin.Services.Interfaces;

using GameAssetsStore.Data.Models;
using GameAssetsStore.Web.Areas.Admin.ViewModels;
using Microsoft.AspNetCore.Identity;

public interface IAdminServices
{
    Task<IdentityResult> RegisterAsync(AdminSignUpFormModel inputModel);

    Task<SignInResult> SignInAsync(string userName, string password, bool isPersistent);

    Task SignOutAsync();
}
