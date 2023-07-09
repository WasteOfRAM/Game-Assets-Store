namespace GameAssetsStore.Data.Models;

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static Common.EntityValidationConstants.Shop;

public class Shop
{
    public Shop()
    {
        this.Id = Guid.NewGuid();
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
    /// Optional name fot the seller page. If not provided ApplicationUser UserName will be used
    /// </summary>
    /// <param name="ShopName"></param>
    [Comment("Optional name for the seller page.")]
    [MaxLength(ShopNameMaxLength)]
    public string? ShopName { get; set; }

    /// <summary>
    /// Optional email address for asset questions and support.
    /// This address will be shown on the public asset store page.
    /// </summary>
    [Comment("Optional email address for asset questions and support.")]
    [EmailAddress]
    public string? SupportEmail { get; set; }

    public Guid? SocialsID { get; set; }

    /// <summary>
    /// All assets uploaded by the seller profile
    /// </summary>
    /// <param name="ShopAssets"></param>
    public virtual ICollection<Asset> ShopAssets { get; set; }


    // TODO: Payout info (Where the shop will receive the earnings)
}
