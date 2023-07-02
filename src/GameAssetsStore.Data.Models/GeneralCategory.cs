namespace GameAssetsStore.Data.Models;

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static Common.EntityValidationConstants.Categories;

[Table(name: "General Category")]
public class GeneralCategory
{
    public GeneralCategory()
    {
        this.Id = Guid.NewGuid();
        this.Assets = new HashSet<Asset>();
    }

    [Key]
    public Guid Id { get; set; }

    [Comment("Category name (e.g. 3D, Texture, Audio)")]
    [Required]
    [MaxLength(NameMaxLength)]
    public string Name { get; set; } = null!;

    public virtual ICollection<Asset> Assets { get; set; }
}
