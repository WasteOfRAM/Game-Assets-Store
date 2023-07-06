namespace GameAssetsStore.Web.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


[Authorize]
public class UserController : Controller
{
    [HttpGet]
    public IActionResult Profile(Guid id)
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
    public async Task<IActionResult> Edit(Guid id, )
    {


        return View();
    }
}
