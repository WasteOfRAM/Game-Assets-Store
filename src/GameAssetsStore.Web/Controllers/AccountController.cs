namespace GameAssetsStore.Web.Controllers;

using GameAssetsStore.Web.Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;
using Services.Data.Interfaces;
using ViewModels.Account;

public class AccountController : Controller
{
    private readonly IAccountService accountService;

    public AccountController(IAccountService accountService)
    {
        this.accountService = accountService;
    }

    [HttpGet("SignUp")]
    public IActionResult SignUp(string? returnUrl = null)
    {
        if (User.Identity?.IsAuthenticated ?? false)
        {
            return RedirectToAction("Index", "Shop");
        }

        SignUpInputModel model = new()
        {
            ReturnUrl = returnUrl,
        };

        return View(model);
    }

    [HttpPost("SignUp")]
    public async Task<IActionResult> SignUp(SignUpInputModel signUpInputModel)
    {
        if (User.Identity?.IsAuthenticated ?? false)
        {
            return RedirectToAction("Index", "Shop");
        }

        if (!ModelState.IsValid)
        {
            return View(signUpInputModel);
        }

        try
        {
            var signUpResult =  await this.accountService.RegisterAsync(signUpInputModel);

            if (!signUpResult.Succeeded)
            {
                foreach (var error in signUpResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);

                    return View(signUpInputModel);
                }
            }

            var signInResult = await this.accountService.SignInAsync(signUpInputModel.Username, signUpInputModel.Password, true);

            if (!signInResult.Succeeded)
            {
                return RedirectToAction("SignIn", "Account");
            }

            return Redirect(signUpInputModel.ReturnUrl ?? "/Shop/Index");
        }
        catch (Exception)
        {
            // TODO: Notify the user about the error. (Unexpected error try again later or .... etc)

            ModelState.AddModelError(string.Empty, "Unexpected error occurred please try again later.");

            return View(signUpInputModel);
        }
    }

    [HttpGet("SignIn")]
    public IActionResult SignIn(string? returnUrl = null)
    {
        if (User.Identity?.IsAuthenticated ?? false)
        {
            return RedirectToAction("Index", "Shop");
        }

        SignInInputModel inputModel = new()
        {
            ReturnUrl = returnUrl
        };

        return View(inputModel);
    }

    [HttpPost("SignIn")]
    public async Task<IActionResult> SignIn(SignInInputModel inputModel)
    {
        if (User.Identity?.IsAuthenticated ?? false)
        {
            return RedirectToAction("Index", "Shop");
        }

        if (!ModelState.IsValid)
        {
            return View(inputModel);
        }

        try
        {
            var result = await this.accountService.SignInAsync(inputModel.Username, inputModel.Password, inputModel.RememberMe);

            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Invalid SignIn.");

                return View(inputModel);
            }

            return Redirect(inputModel.ReturnUrl ?? "/Shop/Index");
        }
        catch (Exception)
        {
            // TODO: Notify the user about the error. (Unexpected error try again later or .... etc)
            ModelState.AddModelError(string.Empty, "Unexpected error occurred please try again later.");

            return View(inputModel);
        }
    }


    [HttpPost("SignOut")]
    public async new Task<IActionResult> SignOut()
    {
        if (User.Identity?.IsAuthenticated ?? false)
        {
            await this.accountService.SignOutAsync();
        }

        return RedirectToAction("Index", "Shop");
    }

    [HttpGet]
    public async Task<IActionResult> AddPaymentMethod(string returnUrl)
    {
        try
        {
            await this.accountService.AddPaymentMethodAsync(User.GetId()!);
            
            return Redirect(returnUrl);
        }
        catch (Exception)
        {
            // TODO:
            throw;
        }
    }
}