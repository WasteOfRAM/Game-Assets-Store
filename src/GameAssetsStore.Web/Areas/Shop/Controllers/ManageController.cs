namespace GameAssetsStore.Web.Areas.Shop.Controllers;

using GameAssetsStore.Services.Data.Interfaces;
using GameAssetsStore.Web.Area.ViewModels.Shop.Manage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static Common.GlobalConstants;

[Area("Shop")]
[Authorize(Policy = "ShopOwner")]
public class ManageController : Controller
{
    private readonly IAssetService assetService;
    private readonly ICategoryService categoryService;
    private readonly IObjectStoreService objectStoreService;

    public ManageController(IAssetService assetService,
        IObjectStoreService objectStoreService,
        ICategoryService categoryService)
    {
        this.assetService = assetService;
        this.objectStoreService = objectStoreService;
        this.categoryService = categoryService;
    }

    public IActionResult Assets()
    {
        return View();
    }

    [HttpGet("{area}/{controller}/Assets/{action}")]
    public async Task<IActionResult> Create()
    {
        var model = new CreateAssetFormModel
        {
            Categories = await this.categoryService.GetAllCategoriesWithSubCategoriesAsync()
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
            
            var isUploadSuccessful = await this.assetService.CreateAssetAsync(model, User.Claims.FirstOrDefault(c => c.Type == "urn:shop:shopId")!.Value);

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
