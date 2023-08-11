namespace GameAssetsStore.Web.Controllers;

using GameAssetsStore.Services.Data.Interfaces;
using GameAssetsStore.Web.Infrastructure.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;


[Authorize]
public class UserController : Controller
{
    private readonly IUserService userService;
    private readonly ITransactionService transactionService;

    public UserController(
        IUserService userService,
        ITransactionService transactionService)
    {
        this.userService = userService;
        this.transactionService = transactionService;
    }

    [AllowAnonymous]
    [HttpGet("{username}")]
    public async Task<IActionResult> PublicProfile(string username)
    {
        var viewModel = await this.userService.GetUserProfileAsync(username);

        if (viewModel == null)
        {
            return NotFound();
        }

        return View(viewModel);
    }

    [HttpGet]
    public async Task<IActionResult> Order(string status, decimal amount)
    {
        try
        {
            if (status == "Succeeded")
            {
                await this.userService.AddPurchasedAssetsAsync(User.GetId()!, TempData["ShoppingCart"]?.ToString());

                await this.transactionService.AddTransactionAsync(User.GetId()!, status, amount);

                string username = User.Identity!.Name!;

                return RedirectToAction($"Library");
            }


            // TODO: Redirect with error
            return RedirectToAction("Index");
        }
        catch (Exception)
        {

            throw;
        }
    }

    [HttpGet]
    public async Task<IActionResult> Library()
    {
        try
        {
            var model = await this.userService.GetUserLibraryAssetsAsync(User.GetId()!);

            return View(model);
        }
        catch (Exception)
        {

            throw;
        }
    }
}
