﻿namespace GameAssetsStore.Web.Controllers;

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
        catch (Exception)
        {
            // TODO: Notify the user about the error. (Unexpected error try again later or .... etc)

            ModelState.AddModelError(string.Empty, "Unexpected error occurred please try again later.");

            return View(signUpInputModel);
        }
    }

    [HttpGet]
    public IActionResult SignIn()
    {
        SignInInputModel inputModel = new SignInInputModel();

        return View(inputModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> SignIn(SignInInputModel inputModel)
    {
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

    [HttpPost]
    public async Task<IActionResult> SignOut()
    {
        await this.accountService.SignOutAsync();

        return RedirectToAction("Index", "Home");
    }
}
