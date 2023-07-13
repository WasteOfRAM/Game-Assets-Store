namespace GameAssetsStore.Web.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize]
[AutoValidateAntiforgeryToken]
public class SettingsController : Controller
{

    [HttpGet]
    public IActionResult Profile(string username)
    {
        if ((!User.Identity?.IsAuthenticated ?? true) || User.Identity!.Name != username)
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
