namespace GameAssetsStore.Data.Models;

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static Common.EntityValidationConstants.ArtStyle;

[Table(name: "Art Style")]
public class ArtStyle
{
    public ArtStyle()
    {
        this.Id = Guid.NewGuid();
        this.Assets = new HashSet<Asset>();
    }

    [Key]
    public Guid Id { get; set; }

    /// <summary>
    /// Style name (e.g. Fantasy, Retro, SciFi, Steampunk)
    /// </summary>
    /// <param name="Name"></param>
    [Comment("Style name (e.g. Fantasy, Retro, SciFi, Steampunk)")]
    [Required]
    [MaxLength(NameMaxLength)]
    public string Name { get; set; } = null!;

    /// <summary>
    /// All assets in this style
    /// </summary>
    /// <param name="Assets"></param>
    public virtual ICollection<Asset> Assets { get; set; }
}
