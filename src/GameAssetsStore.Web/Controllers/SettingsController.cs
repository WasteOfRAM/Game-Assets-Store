﻿namespace GameAssetsStore.Web.Controllers;

using GameAssetsStore.Services.Data.Interfaces;
using GameAssetsStore.Web.Infrastructure.Extensions;
using GameAssetsStore.Web.ViewModels.Settings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize]
public class SettingsController : Controller
{
    private readonly IUserService userService;

    public SettingsController(IUserService userService)
    {
        this.userService = userService;
    }

    [HttpGet("{controller}/{action}")]
    public async Task<IActionResult> Profile()
    {
        if (!User.Identity?.IsAuthenticated ?? true)
        {
            // TODO: Handel it for better UX
            return Unauthorized();
        }

        var model = await this.userService.GetUserPublicProfileAsync(User.GetId()!);

        return View(model);
    }

    [HttpPost("{controller}/{action}")]
    public async Task<IActionResult> Profile(ProfileSettingsFormModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        await this.userService.UpdateUserPublicProfileAsync(model, User.GetId()!);

        return View(model);
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
