namespace GameAssetsStore.Web.ViewModels.Manage;

using System.ComponentModel.DataAnnotations;

public class ArtStyleFormModel
{
    public Guid Id { get; set; }

    [Required]
    public string Name { get; set; } = null!;
}
