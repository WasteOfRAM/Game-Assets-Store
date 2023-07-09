namespace GameAssetsStore.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static Common.EntityValidationConstants.UserProfile;

public class UserProfile
{
    public UserProfile()
    {
        this.Id = Guid.NewGuid();
        this.ExternalLinks = new HashSet<ExternalLink>();
        this.Reviews = new HashSet<Review>();
    }

    [Key]
    public Guid Id { get; set; }

    public Guid UserId { get; set; }
    [ForeignKey(nameof(UserId))]
    public virtual ApplicationUser User { get; set; } = null!;

    [MaxLength(AboutMaxLength)]
    public string? About { get; set; }

    public virtual ICollection<ExternalLink> ExternalLinks { get; set; }

    /// <summary>
    /// User reviews on purchased assets
    /// </summary>
    /// <param name="Reviews"></param>
    public virtual ICollection<Review> Reviews { get; set; }
}
