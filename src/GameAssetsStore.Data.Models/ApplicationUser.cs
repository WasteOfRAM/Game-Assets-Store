namespace GameAssetsStore.Data.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public class ApplicationUser : IdentityUser<Guid>
{
    public ApplicationUser()
    {
        this.Id = Guid.NewGuid();
        this.PurchasedAssets = new HashSet<Asset>();
    }

    /// <summary>
    /// User profile with addition public information
    /// </summary>
    /// <param name="Profile"></param>
    [Comment("User profile")]
    public virtual UserProfile? Profile { get; set; }

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
}
