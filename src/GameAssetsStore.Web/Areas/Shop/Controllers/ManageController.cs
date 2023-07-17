namespace GameAssetsStore.Web.Areas.Shop.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Area("Shop")]
[Authorize(Policy = "ShopOwner")]
public class ManageController : Controller
{
    public IActionResult Assets()
    {
        return View();
    }
}
