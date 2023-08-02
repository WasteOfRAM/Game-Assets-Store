namespace GameAssetsStore.Web.Controllers;

using GameAssetsStore.Services.Data.Interfaces;
using GameAssetsStore.Web.Infrastructure.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize]
public class AssetController : Controller
{
    private readonly IAssetService assetService;

    public AssetController(IAssetService assetService)
    {
        this.assetService = assetService;
    }

    public async Task<IActionResult> Download(string assetId)
    {
        try
        {
            if (await this.assetService.IsUserAssetOwnerAsync(User.GetShopId(), assetId) ||
                await this.assetService.IsUserPurchasedAssetAsync(User.GetId()!, assetId))
            {
                var file = await assetService.DownloadAsync(assetId);

                return File(file.FileStream, file.ContentType, file.FileName);
            }

            return Unauthorized();
        }
        catch (Exception)
        {
            // TODO: Handle it properly

            throw;
        }
    }
}
