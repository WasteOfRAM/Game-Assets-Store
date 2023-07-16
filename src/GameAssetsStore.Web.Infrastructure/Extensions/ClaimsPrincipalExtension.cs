﻿namespace GameAssetsStore.Web.Infrastructure.Extensions;

using System.Security.Claims;

public static class ClaimsPrincipalExtension
{

    /// <summary>
    /// Returns ApplicationUser Id as string from the ClaimsPrincipal.
    /// </summary>
    /// <param name="user"></param>
    /// <returns>string</returns>
    public static string? GetId(this ClaimsPrincipal user)
    {
        return user.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}
