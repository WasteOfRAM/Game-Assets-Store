namespace GameAssetsStore.Web.ViewModels.Settings;

using System.ComponentModel.DataAnnotations;

using static Common.EntityValidationConstants.Shop;

public class CreateShopInputModel
{
    [Display(Name = "Shop Name")]
    [StringLength(ShopNameMaxLength, MinimumLength = ShopNameMinLength)]
    [RegularExpression(ShopNameAllowedCharacters, ErrorMessage = "The {0} must contain only letter, number, space, \".\", \"-\" or \"_\" characters.")]
    public string? ShopName { get; set; }
}
