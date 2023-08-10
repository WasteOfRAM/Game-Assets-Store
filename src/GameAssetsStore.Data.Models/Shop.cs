namespace GameAssetsStore.Data.Models;

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static Common.EntityValidationConstants.Shop;


[Index(nameof(ShopName), IsUnique = true)]
public class Shop
{
    public Shop()
    {
        this.Id = Guid.NewGuid();
        this.Socials = new HashSet<SocialLink>();
        this.ShopAssets = new HashSet<Asset>();
    }

    [Key]
    public Guid Id { get; set; }
    
    /// <summary>
    /// ApplicationUser that is the owner of the shop profile
    /// </summary>
    [Comment("User owning the shop profile.")]
    [Required]
    public Guid OwningUserId { get; set; }
    [ForeignKey(nameof(OwningUserId))]
    public virtual ApplicationUser OwningUser { get; set; } = null!;

    /// <summary>
    /// Optional name fot the seller page. If not provided ApplicationUser UserName will be used.
    /// It is a Unique index.
    /// </summary>
    /// <param name="ShopName"></param>
    [Comment("Optional name for the seller page.")]
    [MaxLength(ShopNameMaxLength)]
    public string ShopName { get; set; } = null!;

    /// <summary>
    /// Optional email address for asset questions and support.
    /// This address will be shown on the public asset store page.
    /// </summary>
    [Comment("Optional email address for asset questions and support.")]
    [EmailAddress]
    public string? SupportEmail { get; set; }

    /// <summary>
    /// Shop company or personal website to be displayed on the public shop page. Optional.
    /// </summary>
    /// <param name="Website"></param>
    public string? Website { get; set; }


    public virtual ICollection<SocialLink> Socials { get; set; }

    /// <summary>
    /// All assets uploaded by the seller profile
    /// </summary>
    /// <param name="ShopAssets"></param>
    public virtual ICollection<Asset> ShopAssets { get; set; }
}
