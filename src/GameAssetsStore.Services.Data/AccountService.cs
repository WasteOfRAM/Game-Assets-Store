namespace GameAssetsStore.Services.Data;

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

using Interfaces;
using Web.ViewModels.Account;
using GameAssetsStore.Data.Models;

public class AccountService : IAccountService
{
    private readonly SignInManager<ApplicationUser> signInManager;
    private readonly UserManager<ApplicationUser> userManager;

    public AccountService(
        SignInManager<ApplicationUser> signInManager,
        UserManager<ApplicationUser> userManager)
    {
        this.signInManager = signInManager;
        this.userManager = userManager;
    }

    public async Task<IdentityResult> RegisterAsync(SignUpInputModel inputModel)
    {
        var user = Activator.CreateInstance<ApplicationUser?>();

        if (user == null)
        {
            throw new InvalidOperationException($"Can't create an instance of '{nameof(IdentityUser)}'. ");
        }

        await this.userManager.SetUserNameAsync(user, inputModel.Username);
        await this.userManager.SetEmailAsync(user, inputModel.Email);

        return await this.userManager.CreateAsync(user, inputModel.Password);
    }

    public async Task<SignInResult> SignInAsync(string userName, string password, bool isPersistent)
    {
        return await this.signInManager.PasswordSignInAsync(userName, password, isPersistent, lockoutOnFailure: false);
    }

    public async Task SignOutAsync()
    {
        await this.signInManager.SignOutAsync();
    }
}
