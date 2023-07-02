namespace GameAssetsStore.Data.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public class ApplicationUser : IdentityUser<Guid>
{
    public ApplicationUser()
    {
        this.Id = Guid.NewGuid();
        this.PurchasedAssets = new HashSet<Asset>();
        this.Reviews = new HashSet<Review>();
    }


    /// <summary>
    /// User seller profile.
    /// </summary>
    [Comment("Seller profile if created")]
    public virtual Seller? OwnedSellerProfile { get; set; }

    /// <summary>
    /// Asset that the user have purchased
    /// </summary>
    /// <param name="PurchasedAssets"></param>
    public virtual ICollection<Asset> PurchasedAssets { get; set; }

    /// <summary>
    /// User reviews on purchased assets
    /// </summary>
    /// <param name="Reviews"></param>
    public virtual ICollection<Review> Reviews { get; set; }
}
