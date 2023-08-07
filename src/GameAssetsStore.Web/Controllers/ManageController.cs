namespace GameAssetsStore.Web.Controllers;

using GameAssetsStore.Services.Data.Interfaces;
using GameAssetsStore.Utilities;
using GameAssetsStore.Web.Infrastructure.Extensions;
using GameAssetsStore.Web.ViewModels.Manage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Common.GlobalConstants;

[Authorize(Policy = "ShopOwner")]
public class ManageController : Controller
{
    private readonly IAssetService assetService;
    private readonly ICategoryService categoryService;
    private readonly IArtStyleService artStyleService;

    public ManageController(IAssetService assetService,
        ICategoryService categoryService,
        IArtStyleService artStyleService)
    {
        this.assetService = assetService;
        this.categoryService = categoryService;
        this.artStyleService = artStyleService;
    }

    public async Task<IActionResult> Assets()
    {
        var model = new ManageAssetsViewModel
        {
            ShopAssets = await assetService.GetShopManagerAssetViewModelAsync(User.GetShopId()!)
        };

        return View(model);
    }

    [HttpGet("{controller}/Assets/{action}")]
    public async Task<IActionResult> Create()
    {
        var model = new CreateAssetFormModel
        {
            Categories = await categoryService.GetAllCategoriesWithSubCategoriesAsync(),
            ArtStyles = await artStyleService.GetArtStylesAsync()
        };

        return View(model);
    }

    [HttpPost("{controller}/Assets/{action}")]
    public async Task<IActionResult> Create(CreateAssetFormModel model)
    {
        try
        {
            if (model.Images.Count() > AssetImagesMaxCount)
            {
                ModelState.AddModelError(string.Empty, "Exceeded maximum allowed asset images.");
            }

            FileHelpers.FileValidation(model.AssetFile, ModelState, MaxFileUploadSize);
            FileHelpers.FileValidation(model.CoverImage, ModelState, MaxImageUploadSize);

            foreach (var file in model.Images)
            {
                FileHelpers.FileValidation(file, ModelState, MaxImageUploadSize);
            }

            if (!model.Categories.Any(c => c.SubCategories.Any(sc => sc.IsChecked)))
            {
                ModelState.AddModelError(string.Empty, "Atleast one category must be selected.");
            }

            if (!ModelState.IsValid)
            {
                model.Categories = await categoryService.GetAllCategoriesWithSubCategoriesAsync();
                model.ArtStyles = await artStyleService.GetArtStylesAsync();

                return View(model);
            }

            var isUploadSuccessful = await assetService.CreateAssetAsync(model, User.GetShopId()!);

            if (!isUploadSuccessful)
            {
                ModelState.AddModelError(string.Empty, "Asset creation failed. Pleas try again later.");
                return View(model);
            }

            return RedirectToAction(nameof(Assets));
        }
        catch (Exception e)
        {
            // TODO: Handle it properly

            ModelState.AddModelError(string.Empty, "Unexpected error occurred please try again later.");

            return View(model);
        }
    }

    [HttpGet("{controller}/Assets/{action}")]
    public async Task<IActionResult> Edit(string assetId)
    {
        var model = await this.assetService.GetEditAssetFormModelAsync(assetId);

        return View(model);
    }

    //[HttpPost("{controller}/Assets/{action}")]
    //public async Task<IActionResult> Edit(EditAssetFormModel model)
    //{
    //    try
    //    {
    //        if (!ModelState.IsValid)
    //        {
    //            return View(model.Id);
    //        }

    //        return View(model.Id);
    //    }
    //    catch (Exception)
    //    {

    //        throw;
    //    }
    //}

    [HttpPost("{controller}/Assets/{action}")]
    public async Task<IActionResult> EditAssetInfo(AssetInfoFormModel model)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Edit), "Manage", new { assetId = model.AssetId });
            }

            await this.assetService.EditAssetInfoAsync(model);

            return RedirectToAction(nameof(Edit), "Manage", new { assetId = model.AssetId });
        }
        catch (Exception)
        {

            return RedirectToAction(nameof(Edit), "Manage", new { assetId = model.AssetId });
        }
    }

    [HttpPost("{controller}/Assets/{action}")]
    public async Task<IActionResult> Publish(string assetId)
    {
        try
        {
            if (await assetService.IsUserAssetOwnerAsync(User.GetShopId(), assetId))
            {
                await assetService.ChangeAssetVisibilityAsync(assetId);
            }

            var model = await this.assetService.GetEditAssetFormModelAsync(assetId);

            return RedirectToAction(nameof(Edit), "Manage", new { AssetId = assetId});
        }
        catch (Exception)
        {
            // TODO: Handle it properly

            var model = await this.assetService.GetEditAssetFormModelAsync(assetId);

            return RedirectToAction(nameof(Edit), "Manage", new { AssetId = assetId });
        }
    }
}
