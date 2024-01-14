namespace GameAssetsStore.Services.Data;

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

using Interfaces;
using Web.ViewModels.Account;
using GameAssetsStore.Data.Models;
using GameAssetsStore.Data.Repositories.Interfaces;
using System.Security.Claims;


/// <summary>
/// Responsible for the users account management e.g. register, log in, log out, adding claims and roles
/// </summary>
public class AccountService : IAccountService
{
    private readonly SignInManager<ApplicationUser> signInManager;
    private readonly UserManager<ApplicationUser> userManager;
    private readonly IUserProfileRepository profileRepository;
    private readonly IUserRepository userRepository;
    private readonly IRepository<PaymentMethod> paymentMethodRepository;

    public AccountService(
        SignInManager<ApplicationUser> signInManager,
        UserManager<ApplicationUser> userManager,
        IUserProfileRepository profileRepository,
        IUserRepository userRepository,
        IRepository<PaymentMethod> paymentMethodRepository)
    {
        this.signInManager = signInManager;
        this.userManager = userManager;
        this.profileRepository = profileRepository;
        this.userRepository = userRepository;
        this.paymentMethodRepository = paymentMethodRepository;
    }

    public async Task AddPaymentMethodAsync(string userId)
    {
        var user = await this.userRepository.GetById(Guid.Parse(userId));

        var paymentMethod = new PaymentMethod { Name = "Bank" };

        await this.paymentMethodRepository.Add(paymentMethod);
        user!.PaymentMethod = paymentMethod;

        await this.userRepository.Save();
    }

    public async Task<bool> AddUserClaim(ApplicationUser user, string claimType, string claimValue)
    {
        var result = await this.userManager.AddClaimAsync(user, new Claim(claimType, claimValue));
        
        return result.Succeeded;
    }

    public async Task<IdentityResult> ChangeEmailAsync(ClaimsPrincipal userPrincipal, string email)
    {
        var user = await this.userManager.GetUserAsync(userPrincipal);
        var securityToken = await this.userManager.GenerateChangeEmailTokenAsync(user!, email);

        return await this.userManager.ChangeEmailAsync(user!, email, securityToken);
    }

    public async Task<IdentityResult> ChangePasswordAsync(ClaimsPrincipal userPrincipal, string oldPassword, string newPassword)
    {
        var user = await this.userManager.GetUserAsync(userPrincipal);

        return await this.userManager.ChangePasswordAsync(user!, oldPassword, newPassword);
    }

    public async Task<IdentityResult> ChangeUsernameAsync(ClaimsPrincipal userPrincipal, string username)
    {
        var user = await this.userManager.GetUserAsync(userPrincipal);

        return await this.userManager.SetUserNameAsync(user!, username);
    }

    public async Task<bool> IsEmailInUseAsync(string email)
    {
        var user = await userRepository.GetByEmail(email);

        return user is not null;
    }

    public async Task<bool> IsUsernameInUseAsync(string userName)
    {
        var user = await userRepository.GetByUserName(userName);

        return user is not null;
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

    /// <summary>
    /// Creating the ApplicationUser entity and creating the user profile entity and adding it to the user
    /// </summary>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
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

        await this.profileRepository.Add(userProfile);

        return user;
    }
}
