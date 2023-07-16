namespace GameAssetsStore.Services.Data;

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

using Interfaces;
using Web.ViewModels.Account;
using GameAssetsStore.Data.Models;
using GameAssetsStore.Data.Repositories.Interfaces;
using System.Security.Claims;

public class AccountService : IAccountService
{
    private readonly SignInManager<ApplicationUser> signInManager;
    private readonly UserManager<ApplicationUser> userManager;
    private readonly IRepository<UserProfile> profileRepository;

    public AccountService(
        SignInManager<ApplicationUser> signInManager,
        UserManager<ApplicationUser> userManager,
        IRepository<UserProfile> profileRepository)
    {
        this.signInManager = signInManager;
        this.userManager = userManager;
        this.profileRepository = profileRepository;
    }

    public async Task<bool> AddUserClaim(ApplicationUser user, string claimType, string claimValue)
    {
        var result = await userManager.AddClaimAsync(user, new Claim(claimType, claimValue));

        return result.Succeeded;
    }

    public async Task<IdentityResult> RegisterAsync(SignUpInputModel inputModel)
    {
        var user = await this.CreateUser();

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

    private async Task<ApplicationUser> CreateUser()
    {
        var user = Activator.CreateInstance<ApplicationUser?>();

        if (user == null)
        {
            throw new InvalidOperationException($"Can't create an instance of '{nameof(ApplicationUser)}'. ");
        }

        //TODO: Add some exception handling and validation for userProfile

        var userProfile = new UserProfile
        {
            UserId = user.Id,
            User = user
        };

        user.Profile = userProfile;

        await this.profileRepository.AddAsync(userProfile);

        return user;
    }
}
