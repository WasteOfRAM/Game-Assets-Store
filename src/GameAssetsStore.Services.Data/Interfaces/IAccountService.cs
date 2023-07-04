﻿namespace GameAssetsStore.Services.Data.Interfaces;

using Microsoft.AspNetCore.Identity;

using Web.ViewModels.Account;

public interface IAccountService
{
    Task<IdentityResult> RegisterAsync(SignUpInputModel inputModel);

    Task<SignInResult> SignInAsync(SignInInputModel inputModel);
}