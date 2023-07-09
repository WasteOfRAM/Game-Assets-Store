namespace GameAssetsStore.Data.Models;

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static Common.EntityValidationConstants.UserProfile;

public class UserProfile
{
    public UserProfile()
    {
        this.Id = Guid.NewGuid();
        this.Reviews = new HashSet<Review>();
    }

    [Key]
    public Guid Id { get; set; }

    public Guid UserId { get; set; }
    [ForeignKey(nameof(UserId))]
    public virtual ApplicationUser User { get; set; } = null!;

    public Guid? SocialsID { get; set; }

    [MaxLength(AboutMaxLength)]
    public string? About { get; set; }

    /// <summary>
    /// User reviews on purchased assets
    /// </summary>
    /// <param name="Reviews"></param>
    public virtual ICollection<Review> Reviews { get; set; }
}
