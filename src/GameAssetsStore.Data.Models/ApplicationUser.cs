namespace GameAssetsStore.Data.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using Interfaces;

public class ApplicationUser : IdentityUser<Guid>
{
    public ApplicationUser()
    {
        this.Id = Guid.NewGuid();
        this.PurchasedAssets = new HashSet<Asset>();
        this.Reviews = new HashSet<Review>();
    }

    /// <summary>
    /// User shop profile.
    /// </summary>
    /// <param name="OwnedShop"></param>
    [Comment("Shop profile if created")]
    public virtual Shop? OwnedShop { get; set; }

    /// <summary>
    /// Asset that the user have purchased
    /// </summary>
    /// <param name="PurchasedAssets"></param>
    public virtual ICollection<Asset> PurchasedAssets { get; set; }

    //// TODO: Add summary
    //public bool IsDeleted { get; set; }
    //public DateTime? DeletedOn { get; set; }

    /// <summary>
    /// User reviews on purchased assets
    /// </summary>
    /// <param name="Reviews"></param>
    public virtual ICollection<Review> Reviews { get; set; }
    
}
