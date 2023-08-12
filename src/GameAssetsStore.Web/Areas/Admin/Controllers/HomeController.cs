namespace GameAssetsStore.Web.Areas.Admin.Controllers;

using GameAssetsStore.Services.Data.Interfaces;
using GameAssetsStore.Web.Areas.Admin.Services.Interfaces;
using GameAssetsStore.Web.Areas.Admin.ViewModels;
using GameAssetsStore.Web.ViewModels.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using static Common.GlobalConstants;

[Area("Admin")]
[Authorize(Roles = AdminRole)]
public class HomeController : Controller
{
    private readonly IAdminServices adminService;

    public HomeController(IAdminServices adminService)
    {
        this.adminService = adminService;
    }

    [AllowAnonymous]
    [HttpGet("{area}")]
    public IActionResult Index()
    {
        if (User.Identity?.IsAuthenticated ?? false)
        {
            return RedirectToAction("Panel", "Home", new { area = "Admin" });
        }

        AdminSignInFormModel model = new AdminSignInFormModel();

        return View(model);
    }

    [AllowAnonymous]
    [HttpPost("{area}")]
    public async Task<IActionResult> Index(AdminSignInFormModel model)
    {
        if (User.Identity?.IsAuthenticated ?? false)
        {
            return RedirectToAction("Panel", "Home", new { area = "Admin" });
        }

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        try
        {
            var result = await this.adminService.SignInAsync(model.Username, model.Password, model.RememberMe);

            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Invalid SignIn.");

                return View(model);
            }

            return RedirectToAction("Panel", "Home", new { area = "Admin" });
        }
        catch (Exception)
        {
            // TODO: Notify the user about the error. (Unexpected error try again later or .... etc)
            ModelState.AddModelError(string.Empty, "Unexpected error occurred please try again later.");

            return View(model);
        }
    }

    [HttpGet("{action}")]
    public IActionResult AddAdmin()
    {
        AdminSignUpFormModel model = new AdminSignUpFormModel();

        return View(model);
    }

    [HttpPost("{action}")]
    public async Task<IActionResult> AddAdmin(AdminSignUpFormModel signUpInputModel)
    {
        if (!ModelState.IsValid)
        {
            return View(signUpInputModel);
        }

        try
        {
            var signUpResult = await this.adminService.RegisterAsync(signUpInputModel);

            if (!signUpResult.Succeeded)
            {
                foreach (var error in signUpResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);

                    return View(signUpInputModel);
                }
            }

            return RedirectToAction("Index", "Panel", new { area = "Admin" });
        }
        catch (Exception)
        {
            // TODO: Notify the user about the error. (Unexpected error try again later or .... etc)

            ModelState.AddModelError(string.Empty, "Unexpected error occurred please try again later.");

            return View(signUpInputModel);
        }
    }

    public async Task<IActionResult> SignOut()
    {
        if (User.Identity?.IsAuthenticated ?? false)
        {
            await this.adminService.SignOutAsync();
        }

        return RedirectToAction("Index", "Home", new { area = "Admin" });
    }

    [HttpGet("{area}/{action}")]
    public IActionResult Panel()
    {
        return View();
    }
}
