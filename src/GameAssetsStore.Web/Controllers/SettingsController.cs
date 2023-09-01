namespace GameAssetsStore.Web.Controllers;

using GameAssetsStore.Services.Data.Interfaces;
using GameAssetsStore.Web.Infrastructure.Extensions;
using GameAssetsStore.Web.ViewModels.Account;
using GameAssetsStore.Web.ViewModels.Settings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using static Common.GlobalConstants;

[Authorize]
public class SettingsController : Controller
{
    private readonly IUserService userService;
    private readonly IAccountService accountService;

    public SettingsController(IUserService userService, IAccountService accountService)
    {
        this.userService = userService;
        this.accountService = accountService;
    }

    [HttpGet("{controller}/{action}")]
    public async Task<IActionResult> Profile()
    {
        if (!User.Identity?.IsAuthenticated ?? true)
        {
            // TODO: Handel it for better UX
            return Unauthorized();
        }

        try
        {
            var model = await this.userService.GetUserPublicProfileAsync(User.GetId()!);

            return View(model);
        }
        catch (Exception)
        {
            // TODO: Handle it properly

            ModelState.AddModelError(string.Empty, "Unexpected error occurred please try again later.");

            return RedirectToAction("PublicProfile", "User", new { username = User.Identity!.Name });
        }
    }

    [HttpPost("{controller}/{action}")]
    public async Task<IActionResult> Profile(ProfileSettingsFormModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        try
        {
            await this.userService.UpdateUserPublicProfileAsync(model, User.GetId()!);
        }
        catch (Exception)
        {
            // TODO: Handle it properly

            ModelState.AddModelError(string.Empty, "Unexpected error occurred please try again later.");

            return RedirectToAction("PublicProfile", "User", new { username = User.Identity!.Name });
        }
        

        return View(model);
    }

    [HttpGet]
    public IActionResult Account()
    {
        AccountSettingsViewModel model = new AccountSettingsViewModel
        {
            UsernameChange = new UsernameChangeInputModel(),
            EmailChange = new AccountEmailChangeInputModel(),
            PasswordChange = new PasswordChangeInputModel()
        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> ChangeUsername(UsernameChangeInputModel model)
    {
        try
        {
            // TODO: Notify the user about success.

            if (await this.accountService.IsUsernameInUseAsync(model.Username))
            {
                ModelState.AddModelError("", "Username is already in use");
            }

            AccountSettingsViewModel viewModel = new AccountSettingsViewModel
            {
                UsernameChange = model,
                EmailChange = new AccountEmailChangeInputModel(),
                PasswordChange = new PasswordChangeInputModel()
            };

            if (!ModelState.IsValid)
            {
                return View("Account", viewModel);
            }

            var result = await this.accountService.ChangeUsernameAsync(User, model.Username);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                //TODO: not sure if i like this.

                return View("Account", viewModel);
            }

            await this.accountService.SignOutAsync();

            return RedirectToAction("SignIn", "Account");
        }
        catch (Exception)
        {

            // TODO: Notify the user about the error. (Unexpected error try again later or .... etc)
            ModelState.AddModelError(string.Empty, "Unexpected error occurred please try again later.");

            return RedirectToAction("Account", "Settings");
        }
    }

    [HttpPost]
    public async Task<IActionResult> ChangeEmail(AccountEmailChangeInputModel model)
    {
        try
        {
            // TODO: Notify the user about success.

            if (await this.accountService.IsEmailInUseAsync(model.Email))
            {
                ModelState.AddModelError("", "Email is already in use");
            }

            AccountSettingsViewModel viewModel = new AccountSettingsViewModel
            {
                UsernameChange = new UsernameChangeInputModel(),
                EmailChange = model,
                PasswordChange = new PasswordChangeInputModel()
            };

            if (!ModelState.IsValid)
            {
                return View("Account", viewModel);
            }

            var result = await this.accountService.ChangeEmailAsync(User, model.Email);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                //TODO: not sure if i like this.

               
                return View("Account", viewModel);
            }

            return View("Account", viewModel);
        }
        catch (Exception)
        {

            // TODO: Notify the user about the error. (Unexpected error try again later or .... etc)
            ModelState.AddModelError(string.Empty, "Unexpected error occurred please try again later.");

            return View("Account");
        }
    }

    [HttpPost]
    public async Task<IActionResult> ChangePassword(PasswordChangeInputModel model)
    {
        try
        {
            // TODO: Notify the user about success.

            AccountSettingsViewModel viewModel = new AccountSettingsViewModel
            {
                UsernameChange = new UsernameChangeInputModel(),
                EmailChange = new AccountEmailChangeInputModel(),
                PasswordChange = model
            };

            if (!ModelState.IsValid)
            {
                return View("Account", viewModel);
            }

            var result = await this.accountService.ChangePasswordAsync(User, model.OldPassword, model.NewPassword);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                //TODO: not sure if i like this.

                

                return View("Account", viewModel);
            }

            return View("Account", viewModel);
        }
        catch (Exception)
        {

            // TODO: Notify the user about the error. (Unexpected error try again later or .... etc)
            ModelState.AddModelError(string.Empty, "Unexpected error occurred please try again later.");

            return View("Account");
        }
    }

    [HttpGet]
    public IActionResult Shop()
    {
        if (!User.HasClaim(c => c.Type == ShopOwnerClaimType))
        {
            return RedirectToAction("CreateShop");
        }

        return View();
    }

    [HttpGet]
    public IActionResult CreateShop()
    {
        if (User.HasClaim(c => c.Type == ShopOwnerClaimType))
        {
            return RedirectToAction("Shop");
        }

        var model = new CreateShopInputModel();

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> CreateShop(CreateShopInputModel model)
    {
        try
        {
            if (!await this.userService.IsShopNameAvailableAsync(model.ShopName))
            {
                ModelState.AddModelError("", "Shop name already in use. Please chose another one.");
            }

            if (!model.AcceptTerms)
            {
                // TODO: better user notification
                ModelState.AddModelError("", "Terms and conditions must be accepted.");
                return View(model);
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // TODO: Save what version of the terms is accepted.

            var shopId = await this.userService.CreateShopAsync(model, User.GetId()!);

            await this.accountService.SignOutAsync();

            return RedirectToAction("SignIn", "Account", new { returnUrl = "/Settings/Shop" });
        }
        catch (Exception)
        {
            // TODO: Handle it properly

            ModelState.AddModelError(string.Empty, "Unexpected error occurred please try again later.");

            return RedirectToAction("PublicProfile", "User", new { username = User.Identity!.Name });
        }
    }
}
