namespace GameAssetsStore.Web.Controllers;

using GameAssetsStore.Services.Data.Interfaces;
using GameAssetsStore.Web.ViewModels.Account;
using Microsoft.AspNetCore.Mvc;

public class AccountController : Controller
{
    private readonly IAccountService accountService;

    public AccountController(IAccountService accountService)
    {
        this.accountService = accountService;
    }

    [HttpGet]
    public IActionResult SignUp()
    {
        SignUpInputModel model = new SignUpInputModel();

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> SignUp(SignUpInputModel signUpInputModel)
    {
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
        catch (Exception io)
        {
            // TODO: Notify the user about the error. (Unexpected error try again later or .... etc)

            ModelState.AddModelError(string.Empty, "Unexpected error occurred please try again later.");

            return View(signUpInputModel);
        }
    }
}
