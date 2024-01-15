namespace GameAssetsStore.Web.Areas.Admin.Services;

using GameAssetsStore.Data.Models;
using GameAssetsStore.Data.Repositories.Interfaces;
using GameAssetsStore.Web.Areas.Admin.Services.Interfaces;
using GameAssetsStore.Web.Areas.Admin.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

using static Common.GlobalConstants;

public class AdminServices : IAdminServices
{
    private readonly SignInManager<ApplicationUser> signInManager;
    private readonly UserManager<ApplicationUser> userManager;
    private readonly RoleManager<IdentityRole<Guid>> roleManager;

    public AdminServices(
        SignInManager<ApplicationUser> signInManager, 
        UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole<Guid>> roleManager)
    {
        this.signInManager = signInManager;
        this.userManager = userManager;
        this.roleManager = roleManager;
    }

    public async Task<IdentityResult> RegisterAsync(AdminSignUpFormModel inputModel)
    {
        var user = this.CreateUser();

        user.EmailConfirmed = true;

        await this.userManager.SetUserNameAsync(user, inputModel.Username);
        await this.userManager.SetEmailAsync(user, $"{inputModel.Username}@system.bg");

        var result = await this.userManager.CreateAsync(user, inputModel.Password);

        await this.userManager.AddToRoleAsync(user, AdminRole);

        return result;
    }

    public async Task<SignInResult> SignInAsync(string userName, string password, bool isPersistent)
    {
        return await this.signInManager.PasswordSignInAsync(userName, password, isPersistent, lockoutOnFailure: false);
    }

    public async Task SignOutAsync()
    {
        await this.signInManager.SignOutAsync();
    }

    private ApplicationUser CreateUser()
    {
        var user = Activator.CreateInstance<ApplicationUser?>();

        if (user == null)
        {
            throw new InvalidOperationException($"Can't create an instance of '{nameof(ApplicationUser)}'. ");
        }

        return user;
    }
}
