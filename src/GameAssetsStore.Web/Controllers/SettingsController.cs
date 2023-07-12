namespace GameAssetsStore.Web.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize]
[AutoValidateAntiforgeryToken]
public class SettingsController : Controller
{
    [HttpGet]
    public IActionResult Profile()
    {


        return View();
    }

    public IActionResult Account()
    {


        return View();
    }
}
