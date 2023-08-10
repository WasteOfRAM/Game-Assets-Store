namespace GameAssetsStore.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class PaymentAccount
{
    public PaymentAccount()
    {
        this.Id = Guid.NewGuid();
    }

    [Key]
    public Guid Id { get; set; }

    [Required]
    public string AccountNumber { get; set; } = null!;

    [Column(TypeName = "money")]
    public decimal Balance { get; set; }

    [ForeignKey(nameof(PaymentMethodId))]
    public Guid PaymentMethodId { get; set; }
    public virtual PaymentMethod PaymentMethod { get; set; } = null!;
}
