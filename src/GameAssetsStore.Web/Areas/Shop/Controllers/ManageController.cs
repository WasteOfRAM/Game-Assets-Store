namespace GameAssetsStore.Web.Areas.Shop.Controllers;

using GameAssetsStore.Services.Data.Interfaces;
using GameAssetsStore.Web.Infrastructure.Extensions;
using GameAssetsStore.Web.ViewModels.Manage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Common.GlobalConstants;

[Area("Shop")]
[Authorize(Policy = "ShopOwner")]
public class ManageController : Controller
{
    private readonly IAssetService assetService;
    private readonly ICategoryService categoryService;
    private readonly IObjectStoreService objectStoreService;
    private readonly IArtStyleService artStyleService;

    public ManageController(IAssetService assetService,
        IObjectStoreService objectStoreService,
        ICategoryService categoryService,
        IArtStyleService artStyleService)
    {
        this.assetService = assetService;
        this.objectStoreService = objectStoreService;
        this.categoryService = categoryService;
        this.artStyleService = artStyleService;
    }

    public async Task<IActionResult> Assets()
    {
        var model = new ManageAssetsViewModel
        {
            ShopAssets = await this.assetService.GetShopManagerAssetCarsAsync(User.GetShopId()!)
        };

        return View(model);
    }

    [HttpGet("{area}/{controller}/Assets/{action}")]
    public async Task<IActionResult> Create()
    {
        var model = new CreateAssetFormModel
        {
            Categories = await this.categoryService.GetAllCategoriesWithSubCategoriesAsync(),
            ArtStyles = await this.artStyleService.GetArtStylesAsync()
        };

        return View(model);
    }

    [HttpPost("{area}/{controller}/Assets/{action}")]
    public async Task<IActionResult> Create(CreateAssetFormModel model)
    {
        try
        {
            if (model.Images.Count() > AssetImagesMaxCount)
            {
                ModelState.AddModelError(string.Empty, "Exceeded maximum allowed asset images.");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            
            var isUploadSuccessful = await this.assetService.CreateAssetAsync(model, User.GetShopId()!);

            if (!isUploadSuccessful)
            {
                ModelState.AddModelError(string.Empty, "Asset creation failed. Pleas try again later.");
                return View(model);
            }

            return View(nameof(Assets));
        }
        catch (Exception)
        {
            // TODO: Handle it properly

            ModelState.AddModelError(string.Empty, "Unexpected error occurred please try again later.");

            return View(model);
        }
    }
}
