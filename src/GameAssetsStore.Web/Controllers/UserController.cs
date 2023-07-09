namespace GameAssetsStore.Web.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


[Authorize]
public class UserController : Controller
{
    [AllowAnonymous]
    [HttpGet("{controller}/{username}")]
    public IActionResult Profile(string username)
    {
        
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> Edit(Guid id)
    {
        

        return View();
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit()
    {


        return View();
    }
}
