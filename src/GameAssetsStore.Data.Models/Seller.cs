namespace GameAssetsStore.Data.Models;

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static Common.EntityValidationConstants.Seller;

public class Seller
{
    public Seller()
    {
        this.Id = Guid.NewGuid();
        this.SellerAssets = new HashSet<Asset>();
    }

    [Key]
    public Guid Id { get; set; }
    
    /// <summary>
    /// ApplicationUser that is the owner of the seller profile
    /// </summary>
    [Comment("User owning the seller profile.")]
    [Required]
    public Guid OwningUserId { get; set; }
    [ForeignKey(nameof(OwningUserId))]
    public virtual ApplicationUser OwningUser { get; set; } = null!;

    /// <summary>
    /// Optional name fot the seller page. If not provided ApplicationUser UserName will be used
    /// </summary>
    /// <param name="SellerName"></param>
    [Comment("Optional name for the seller page.")]
    [MaxLength(SellerNameMaxLength)]
    public string? SellerName { get; set; }

    /// <summary>
    /// Optional email address for asset questions and support.
    /// This address will be shown on the public asset store page.
    /// </summary>
    [Comment("Optional email address for asset questions and support.")]
    [EmailAddress]
    public string? SupportEmail { get; set; }

    /// <summary>
    /// All assets uploaded by the seller profile
    /// </summary>
    /// <param name="SellerAssets"></param>
    public virtual ICollection<Asset> SellerAssets { get; set; }


    // TODO: Payout info (Where the seller will receive the earnings)
}
