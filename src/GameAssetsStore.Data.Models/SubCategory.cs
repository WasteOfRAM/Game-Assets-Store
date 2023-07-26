namespace GameAssetsStore.Data.Models;

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static Common.EntityValidationConstants.Categories;

[Table(name: "Sub Category")]
public class SubCategory
{
    public SubCategory()
    {
        this.Id = Guid.NewGuid();
        this.Assets = new HashSet<Asset>();
    }

    [Key]
    public Guid Id { get; set; }

    /// <summary>
    /// SubCategory name (e.g. LowPoly, SFX, Music)
    /// </summary>
    /// <param name="Name"></param>
    [Comment("SubCategory name (e.g. LowPoly, SFX, Music)")]
    [Required]
    [MaxLength(NameMaxLength)]
    public string Name { get; set; } = null!;

    public Guid CategoryId { get; set; }
    [ForeignKey(nameof(CategoryId))]
    public virtual GeneralCategory Category { get; set; } = null!;

    /// <summary>
    /// All assets in this sub category
    /// </summary>
    /// <param name="Assets"></param>
    public virtual ICollection<Asset> Assets { get; set; }
}
