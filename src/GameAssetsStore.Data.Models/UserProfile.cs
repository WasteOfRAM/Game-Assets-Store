namespace GameAssetsStore.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static Common.EntityValidationConstants.UserProfile;

public class UserProfile
{
    public UserProfile()
    {
        this.Id = Guid.NewGuid();
        this.SocialLinks = new HashSet<SocialLink>();
        this.Reviews = new HashSet<Review>();
    }

    [Key]
    public Guid Id { get; set; }


    /// <summary>
    /// The user that this profile belongs to
    /// </summary>
    /// <param name="User"></param>
    public Guid UserId { get; set; }
    [ForeignKey(nameof(UserId))]
    public virtual ApplicationUser User { get; set; } = null!;

    /// <summary>
    /// About info for the user. Optional.
    /// </summary>
    /// <param name="About"></param>
    [MaxLength(AboutMaxLength)]
    public string? About { get; set; }

    /// <summary>
    /// Email that will be visible to everyone in the public profile. Optional.
    /// </summary>
    /// <param name="PublicEmail"></param>
    [EmailAddress]
    public string? PublicEmail { get; set; }

    /// <summary>
    /// User personal website to be displayed on the public profile page. Optional.
    /// </summary>
    /// <param name="Website"></param>
    public string? Website { get; set; }


    public virtual ICollection<SocialLink> SocialLinks { get; set; }

    /// <summary>
    /// User reviews on purchased assets
    /// </summary>
    /// <param name="Reviews"></param>
    public virtual ICollection<Review> Reviews { get; set; }
}
