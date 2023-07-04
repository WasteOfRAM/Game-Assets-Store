namespace GameAssetsStore.Data.Models;

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static Common.EntityValidationConstants.Asset;

public class Asset
{
    public Asset()
    {
        this.Id = Guid.NewGuid();
        this.CreatedOn = DateTime.UtcNow;

        this.Users = new HashSet<ApplicationUser>();
        this.GeneralCategories = new HashSet<GeneralCategory>();
        this.SubCategories = new HashSet<SubCategory>();
        this.ArtStyles = new HashSet<ArtStyle>();
        this.Reviews = new HashSet<Review>();
    }

    [Key]
    public Guid Id { get; set; }

    /// <summary>
    /// Seller profile owning the asset.
    /// </summary>
    /// <param name="SellerId"></param>
    [Comment("Seller profile owning the asset.")]
    [Required]
    public Guid SellerId { get; set; }
    [ForeignKey(nameof(SellerId))]
    public virtual Seller Seller { get; set; } = null!;

    /// <summary>
    /// The name that will be displayed on the public pages.
    /// </summary>
    /// <param name="AssetName"></param>
    [Comment("Asset public display name.")]
    [Required]
    [MaxLength(AssetNameMaxLength)]
    public string AssetName { get; set; } = null!;

    /// <summary>
    /// Seller provided detailed description of the asset.
    /// Visible ont the asset public store page.
    /// </summary>
    /// <param name="Description"></param>
    [Comment("Asset asset description for the public store page.")]
    [Required]
    public string Description { get; set; } = null!;

    /// <summary>
    /// Price of the asset. NULL is possible to allow free assets.
    /// </summary>
    /// <param name="Price"></param>
    [Comment("Price of the asset")]
    [Column(TypeName = "money")]
    public decimal? Price { get; set; }

    /// <summary>
    /// User defined asset version identifier.
    /// </summary>
    /// <param name="Version"></param>
    [Comment("User defined asset version identifier.")]
    [MaxLength(VersionMaxLength)]
    public string? Version { get; set; }

    /// <summary>
    /// How many times the asset was sold
    /// </summary>
    /// <param name="SalesCount"
    [Comment("Asset total sales.")]
    public int SalesCount { get; set; }


    [Comment("Date that the asset was created")]
    [Required]
    public DateTime CreatedOn { get; set; }


    [Comment("Date that the asset was last modified")]
    public DateTime? ModifiedOn { get; set; }

    /// <summary>
    /// Is the asset page public and asset available for purchase
    /// </summary>
    /// <param name="IsPublic"></param>
    [Comment("Is the asset page public and asset available for purchase")]
    [Required]
    public bool IsPublic { get; set; }



    /// <summary>
    /// Users that purchased the product.
    /// </summary>
    /// <param name="Users"></param>
    public virtual ICollection<ApplicationUser> Users { get; set; }

    /// <summary>
    /// All categories that the asset belongs to.
    /// </summary>
    /// <param name="GeneralCategories"></param>
    public virtual ICollection<GeneralCategory> GeneralCategories { get; set; }

    /// <summary>
    /// All sub categories that the asset belongs to.
    /// </summary>
    /// <param name="SubCategories"></param>
    public virtual ICollection<SubCategory> SubCategories { get; set; }

    /// <summary>
    /// All art styles that the asset belongs to.
    /// </summary>
    /// <param name="ArtStyles"></param>
    public virtual ICollection<ArtStyle> ArtStyles { get; set; }

    /// <summary>
    /// All reviews for the asset.
    /// </summary>
    /// <param name="Reviews"></param>
    public virtual ICollection<Review> Reviews { get; set; }
}
