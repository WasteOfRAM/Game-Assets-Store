namespace GameAssetsStore.Web.Controllers;

using GameAssetsStore.Services.Data.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


[Authorize]
public class UserController : Controller
{
    private readonly IUserService userService;

    public UserController(IUserService userService)
    {
        this.userService = userService;
    }

    [AllowAnonymous]
    [HttpGet("{username}")]
    public async Task<IActionResult> Profile(string username)
    {
        var viewModel = await this.userService.GetUserProfileAsync(username);

        if (viewModel == null)
        {
            return NotFound();
        }

        return View(viewModel);
    }
}
