namespace GameAssetsStore.Data.Models;

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static Common.EntityValidationConstants.Categories;

[Table(name: "SubCategories")]
public class SubCategory
{
    public SubCategory()
    {
        this.Id = Guid.NewGuid();
        this.Assets = new HashSet<Asset>();
        this.GeneralCategories = new HashSet<GeneralCategory>();
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

    /// <summary>
    /// The General categories it belongs to.
    /// </summary>
    /// <param name="CategoryId"></param>
    public virtual ICollection<GeneralCategory> GeneralCategories { get; set; }

    /// <summary>
    /// All assets in this sub category
    /// </summary>
    /// <param name="Assets"></param>
    public virtual ICollection<Asset> Assets { get; set; }
}
