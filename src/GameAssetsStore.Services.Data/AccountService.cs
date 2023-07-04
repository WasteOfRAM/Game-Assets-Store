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
    private readonly IUserStore<ApplicationUser> userStore;
    private readonly IUserEmailStore<ApplicationUser> emailStore;

    public AccountService(
        SignInManager<ApplicationUser> signInManager,
        UserManager<ApplicationUser> userManager,
        IUserStore<ApplicationUser> userStore,
        IUserEmailStore<ApplicationUser> emailStore)
    {
        this.signInManager = signInManager;
        this.userManager = userManager;
        this.userStore = userStore;
        this.emailStore = emailStore;
    }

    public async Task<IdentityResult> RegisterAsync(SignUpInputModel inputModel)
    {
        var user = Activator.CreateInstance<ApplicationUser?>();

        if (user == null)
        {
            throw new InvalidOperationException($"Can't create an instance of '{nameof(IdentityUser)}'. ");
        }

        await this.userStore.SetUserNameAsync(user, inputModel.Username, CancellationToken.None);
        await this.emailStore.SetEmailAsync(user, inputModel.Email, CancellationToken.None);

        return await this.userManager.CreateAsync(user, inputModel.Password);
    }

    public async Task<SignInResult> SignInAsync(SignInInputModel inputModel)
    {
        return await this.signInManager.PasswordSignInAsync(inputModel.Username, inputModel.Password, inputModel.RememberMe, lockoutOnFailure: false);
    }
}
