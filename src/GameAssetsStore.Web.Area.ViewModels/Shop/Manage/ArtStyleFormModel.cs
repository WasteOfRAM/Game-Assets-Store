namespace GameAssetsStore.Web.Area.ViewModels.Shop.Manage;

using System.ComponentModel.DataAnnotations;

public class ArtStyleFormModel
{
    public Guid Id { get; set; }

    [Required]
    public string Name { get; set; } = null!;
}
