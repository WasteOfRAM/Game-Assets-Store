namespace GameAssetsStore.Web.Controllers;

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

    [HttpGet("{action}")]
    public IActionResult SignUp()
    {
        if (User.Identity?.IsAuthenticated ?? false)
        {
            return RedirectToAction("Index", "Home");
        }

        SignUpInputModel model = new SignUpInputModel();

        return View(model);
    }

    [HttpPost("{action}")]
    public async Task<IActionResult> SignUp(SignUpInputModel signUpInputModel)
    {
        if (User.Identity?.IsAuthenticated ?? false)
        {
            return RedirectToAction("Index", "Home");
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

            return RedirectToAction("Index", "Home");
        }
        catch (Exception)
        {
            // TODO: Notify the user about the error. (Unexpected error try again later or .... etc)

            ModelState.AddModelError(string.Empty, "Unexpected error occurred please try again later.");

            return View(signUpInputModel);
        }
    }

    [HttpGet("{action}")]
    public IActionResult SignIn()
    {
        if (User.Identity?.IsAuthenticated ?? false)
        {
            return RedirectToAction("Index", "Home");
        }

        SignInInputModel inputModel = new SignInInputModel();

        return View(inputModel);
    }

    [HttpPost("{action}")]
    public async Task<IActionResult> SignIn(SignInInputModel inputModel)
    {
        if (User.Identity?.IsAuthenticated ?? false)
        {
            return RedirectToAction("Index", "Home");
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

            return RedirectToAction("Index", "Home");
        }
        catch (Exception)
        {
            // TODO: Notify the user about the error. (Unexpected error try again later or .... etc)
            ModelState.AddModelError(string.Empty, "Unexpected error occurred please try again later.");

            return View(inputModel);
        }
    }


    [HttpPost("{action}")]
    public async Task<IActionResult> SignOut()
    {
        if (User.Identity?.IsAuthenticated ?? false)
        {
            await this.accountService.SignOutAsync();
        }

        return RedirectToAction("Index", "Home");
    }
}
