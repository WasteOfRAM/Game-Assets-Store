namespace GameAssetsStore.Web.Controllers;

using GameAssetsStore.Services.Data.Interfaces;
using GameAssetsStore.Web.Infrastructure.Extensions;
using GameAssetsStore.Web.ViewModels.Settings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        

        return View();
    }

    [HttpGet]
    public IActionResult Socials()
    {
        

        return View();
    }

    [HttpGet]
    public IActionResult Shop()
    {
        if (!User.HasClaim(c => c.Type == "urn:shop:shopId"))
        {
            return RedirectToAction("CreateShop");
        }

        return View();
    }

    [HttpGet]
    public IActionResult CreateShop()
    {
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

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var shopId = await this.userService.CreateShopAsync(model, User.GetId()!);

            await this.accountService.SignOutAsync();

            return RedirectToAction("SignIn", "Account");
        }
        catch (Exception)
        {
            // TODO: Handle it properly

            ModelState.AddModelError(string.Empty, "Unexpected error occurred please try again later.");

            return RedirectToAction("PublicProfile", "User", new { username = User.Identity!.Name });
        }
    }
}
