namespace GameAssetsStore.Web.Controllers;

using GameAssetsStore.Services.Data.Interfaces;
using GameAssetsStore.Web.Infrastructure.Extensions;
using GameAssetsStore.Web.ViewModels;
using GameAssetsStore.Web.ViewModels.Shop;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;

[Authorize]
public class ShopController : Controller
{
    private readonly IAssetService assetService;
    private readonly IShopService shopService;
    private readonly ICartService cartService;

    public ShopController(
        IAssetService assetService,
        IShopService shopService,
        ICartService cartService)
    {
        this.assetService = assetService;
        this.shopService = shopService;
        this.cartService = cartService;
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
            var tempDataCartJson = TempData.Peek("ShoppingCart")?.ToString();
            var model = await this.assetService.GetAssetPageViewModelAsync(id, User.GetId()!, tempDataCartJson);

            return View(model);
        }
        catch (Exception)
        {
            // TODO: 

            throw;
        }
    }

    [AllowAnonymous]
    [HttpGet]
    public IActionResult Cart()
    {
        var tempDataCartJson = TempData.Peek("ShoppingCart")!.ToString();
        List<ShoppingCartDto> cart = JsonSerializer.Deserialize<List<ShoppingCartDto>>(tempDataCartJson!)!;

        return View(cart);
    }

    [AllowAnonymous]
    [HttpPost]
    public IActionResult GetCart([FromBody] ShoppingCartDto[] cartItems)
    {
        TempData["ShoppingCart"] = JsonSerializer.Serialize(cartItems);

        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> Checkout()
    {
        try
        {
            var tempDataCart = TempData.Peek("ShoppingCart")!.ToString();
            var model = await this.cartService.GetCheckoutCartAssetsAsync(User.GetId()!, tempDataCart);

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
