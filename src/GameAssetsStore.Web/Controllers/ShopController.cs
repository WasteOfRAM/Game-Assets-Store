namespace GameAssetsStore.Web.Controllers;

using GameAssetsStore.Services.Data.Interfaces;
using GameAssetsStore.Web.ViewModels;
using GameAssetsStore.Web.ViewModels.Shop;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

[Authorize]
public class ShopController : Controller
{
    private readonly IAssetService assetService;
    private readonly IShopService shopService;

    public ShopController(
        IAssetService assetService,
        IShopService shopService)
    {
        this.assetService = assetService;
        this.shopService = shopService;
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var model = await this.shopService.GetHomePageAssetsAsync();

        return View(model);
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> Browse([FromQuery] AssetQueryModel queryModel)
    {
        var model = await this.shopService.GetAllAssetsAsync(queryModel);


        return View(model);
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> Asset(string id) 
    {
        try
        {
            var model = await this.assetService.GetAssetPageViewModelAsync(id);

            return View(model);
        }
        catch (Exception)
        {
            // TODO: 

            throw;
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
