namespace GameAssetsStore.Data.Models;

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/// <summary>
/// Not a real payment methods just for testing
/// </summary>
[Comment("A fake payment method fo testing")]
public class PaymentMethod
{
    public PaymentMethod()
    {
        this.Id = Guid.NewGuid();
        this.ApplicationUsers = new HashSet<ApplicationUser>();
    }

    [Key]
    public Guid Id { get; set; }

    /// <summary>
    /// Name of the method
    /// </summary>
    /// <param name="Name"></param>
    [Required]
    [Comment("Name of the payment method")]
    public string Name { get; set; } = null!;

    /// <summary>
    /// A fake balance.
    /// </summary>
    /// <param name="Balance"></param>
    [Required]
    [Column(TypeName = "money")]
    [Comment("A fake balance.")]
    public decimal Balance { get; set; }

    public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }
}
