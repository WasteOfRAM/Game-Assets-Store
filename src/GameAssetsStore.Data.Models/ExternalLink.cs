namespace GameAssetsStore.Data.Models;

using GameAssetsStore.Common.Enumerators;
using System.ComponentModel.DataAnnotations;
using static Common.EntityValidationConstants.ExternalLink;

public class ExternalLink
{
    public ExternalLink()
    {
        this.Id = Guid.NewGuid();
        this.UserProfiles = new HashSet<UserProfile>();
        this.Shops = new HashSet<Shop>();
    }

    public Guid Id { get; set; }

    [Required]
    public ExternalLinkType LinkType { get; set; }

    [Required]
    [MaxLength(LinksMaxLength)]
    public string LinkUrl { get; set; } = null!;

    public virtual ICollection<UserProfile> UserProfiles { get; set; }

    public virtual ICollection<Shop> Shops { get; set; }
}
