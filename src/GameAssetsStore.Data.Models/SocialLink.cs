namespace GameAssetsStore.Data.Models;

using GameAssetsStore.Common.Enumerators;
using System.ComponentModel.DataAnnotations;
using static Common.EntityValidationConstants.SocialLink;

public class SocialLink
{
    public SocialLink()
    {
        this.Id = Guid.NewGuid();
        this.UserProfiles = new HashSet<UserProfile>();
        this.Shops = new HashSet<Shop>();
    }

    public Guid Id { get; set; }

    [Required]
    public SocialType SocialType { get; set; }

    [Required]
    [MaxLength(LinkMaxLength)]
    public string LinkUrl { get; set; } = null!;

    public virtual ICollection<UserProfile> UserProfiles { get; set; }

    public virtual ICollection<Shop> Shops { get; set; }
}
