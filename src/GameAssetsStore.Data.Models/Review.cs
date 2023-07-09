namespace GameAssetsStore.Data.Models;

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static Common.EntityValidationConstants.Review;

public class Review
{
    public Review()
    {
        this.Id = Guid.NewGuid();
    }

    [Key]
    public Guid Id { get; set; }

    /// <summary>
    /// Profile that created the review.
    /// </summary>
    /// <param name="ReviewCreatorId"></param>
    [Comment("Review creator")]
    [Required]
    public Guid ReviewCreatorId { get; set; }
    [ForeignKey(nameof(ReviewCreatorId))]
    public virtual UserProfile ReviewCreator { get; set; } = null!;

    /// <summary>
    /// Reviewed asset.
    /// </summary>
    /// <param name="ReviewedAssetId"></param>
    [Comment("Reviewed asset")]
    [Required]
    public Guid ReviewedAssetId { get; set; }
    [ForeignKey(nameof(ReviewedAssetId))]
    public virtual Asset ReviewedAsset { get; set; } = null!;

    /// <summary>
    /// Review text content
    /// </summary>
    /// <param name="Content"></param>
    [Comment("Review text content")]
    [Required]
    [MaxLength(TextMaxLength)]
    public string Content { get; set; } = null!;

    /// <summary>
    /// Review likes
    /// </summary>
    /// <param name="Likes"></param>
    [Comment("Review likes")]
    [Required]
    public int Likes { get; set; }

    /// <summary>
    /// Review dislikes
    /// </summary>
    /// <param name="Dislikes"></param>
    [Comment("Review dislikes")]
    [Required]
    public int Dislikes { get; set; }

    [Comment("Date that the review was created")]
    [Required]
    public DateTime CreatedOn { get; set; }

    [Comment("Date that the review was last edited")]
    public DateTime? ModifiedOn { get; set; }
}
