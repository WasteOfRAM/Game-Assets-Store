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

    [HttpGet]
    public async Task<IActionResult> Assets()
    {
        var model = new ManageAssetsViewModel
        {
            ShopAssets = await assetService.GetShopManagerAssetViewModelAsync(User.GetShopId()!)
        };

        return View(model);
    }

    [HttpGet("Manage/Assets/Create")]
    public async Task<IActionResult> Create()
    {
        var model = new CreateAssetFormModel
        {
            Categories = await categoryService.GetAllCategoriesWithSubCategories(),
            ArtStyles = await artStyleService.GetArtStylesAsync()
        };

        return View(model);
    }

    [HttpPost("Manage/Assets/Create")]
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
                model.Categories = await categoryService.GetAllCategoriesWithSubCategories();
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
        catch (Exception)
        {
            // TODO: Handle it properly

            ModelState.AddModelError(string.Empty, "Unexpected error occurred please try again later.");

            return View(model);
        }
    }

    [HttpGet("Manage/Assets/Edit")]
    public async Task<IActionResult> Edit(string assetId)
    {
        try
        {
            if (!await assetService.IsUserAssetOwnerAsync(User.GetShopId(), assetId))
            {
                return Unauthorized();
            }

            var model = await this.assetService.GetEditAssetFormModelAsync(assetId);

            return View(model);
        }
        catch (Exception)
        {
            // TODO: Handle it properly
            throw;
        }

        
    }

    [HttpPost("Manage/Assets/EditAssetInfo")]
    public async Task<IActionResult> EditAssetInfo(AssetInfoFormModel model)
    {
        try
        {
            if (!await assetService.IsUserAssetOwnerAsync(User.GetShopId(), model.AssetId.ToString()))
            {
                return Unauthorized();
            }

            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Edit), "Manage", new { assetId = model.AssetId });
            }

            await this.assetService.EditAssetInfoAsync(model);

            return RedirectToAction(nameof(Edit), "Manage", new { assetId = model.AssetId });
        }
        catch (Exception)
        {
            // TODO: Handle it properly
            return RedirectToAction(nameof(Edit), "Manage", new { assetId = model.AssetId });
        }
    }

    [HttpPost("Manage/Assets/UpdateAssetFile")]
    public async Task<IActionResult> UpdateAssetFile(EditAssetFileFormModel model)
    {
        try
        {
            if (!await assetService.IsUserAssetOwnerAsync(User.GetShopId(), model.AssetId.ToString()))
            {
                return Unauthorized();
            }

            FileHelpers.FileValidation(model.AssetFile, ModelState, MaxFileUploadSize);

            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Edit), "Manage", new { assetId = model.AssetId });
            }

            await this.assetService.UpdateAssetFileAsync(model);

            return RedirectToAction(nameof(Edit), "Manage", new { assetId = model.AssetId });
        }
        catch (Exception)
        {
            // TODO: Handle it properly
            return RedirectToAction(nameof(Edit), "Manage", new { assetId = model.AssetId });
        }
    }

    [HttpPost("Manage/Assets/Publish")]
    public async Task<IActionResult> Publish(string assetId)
    {
        try
        {
            if (!await assetService.IsUserAssetOwnerAsync(User.GetShopId(), assetId))
            {
                return Unauthorized();
            }
            
            await assetService.ChangeAssetVisibilityAsync(assetId);

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

    [HttpPost("Manage/Assets/Delete")]
    public async Task<IActionResult> Delete(DeleteAssetFormModel model)
    {
        try
        {
            if (!await assetService.IsUserAssetOwnerAsync(User.GetShopId(), model.AssetId.ToString()))
            {
                return Unauthorized();
            }

            if (await assetService.IsAssetPurchasedByAnyUserAsync(model.AssetId.ToString()))
            {
                ModelState.AddModelError(string.Empty, "Asset have been purchased by one or more users and cannot be deleted");
            }

            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Edit), "Manage", new { assetId = model.AssetId });
            }

            await this.assetService.DeleteAssetAsync(model.AssetId.ToString());

            return RedirectToAction(nameof(Assets));
        }
        catch (Exception)
        {
            // TODO: Handle it properly

            return RedirectToAction(nameof(Edit), "Manage", new { assetId = model.AssetId });
        }
    }
}
