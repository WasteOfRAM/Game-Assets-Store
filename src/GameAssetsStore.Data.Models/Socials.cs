namespace GameAssetsStore.Data.Models;

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

using static Common.EntityValidationConstants.Socials;

public class Socials
{
    public Socials()
    {
        this.Id = Guid.NewGuid();
    }

    public Guid Id { get; set; }

    [Comment("User or shop owning the socials")]
    public Guid OwnerId { get; set; }

    [MaxLength(LinksMaxLength)]
    public string? PublicEmail { get; set; }

    [MaxLength(LinksMaxLength)]
    public string? Website { get; set; }

    [MaxLength(LinksMaxLength)]
    public string? LinkedIn { get; set; }

    [MaxLength(LinksMaxLength)]
    public string? Twitter { get; set; }

    [MaxLength(LinksMaxLength)]
    public string? Facebook { get; set; }

    [MaxLength(LinksMaxLength)]
    public string? Instagram { get; set; }

    [MaxLength(LinksMaxLength)]
    public string? ArtStation { get; set; }

    [MaxLength(LinksMaxLength)]
    public string? DeviantArt { get; set; }

    [MaxLength(LinksMaxLength)]
    public string? GitHub { get; set;}

    [MaxLength(LinksMaxLength)]
    public string? YouTube { get; set; }
}
