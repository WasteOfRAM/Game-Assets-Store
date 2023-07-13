namespace GameAssetsStore.Web.Controllers;

using GameAssetsStore.Services.Data.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize]
public class SettingsController : Controller
{
    private readonly IUserService userService;

    public SettingsController(IUserService userService)
    {
        this.userService = userService;
    }

    [HttpGet("{controller}/{action}")]
    public async Task<IActionResult> Profile()
    {
        if (!User.Identity?.IsAuthenticated ?? true)
        {
            // TODO: Handel it for better UX
            return Unauthorized();
        }

           

        return View();
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
}
