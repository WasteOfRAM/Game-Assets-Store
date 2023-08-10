namespace GameAssetsStore.Data.Models;

using System.ComponentModel.DataAnnotations;

public class PaymentMethod
{
    public PaymentMethod()
    {
        this.Id = Guid.NewGuid();
        this.ApplicationUsers = new HashSet<ApplicationUser>();
        this.PaymentAccounts = new HashSet<PaymentAccount>();
    }

    [Key]
    public Guid Id { get; set; }

    [Required]
    public string Name { get; set; } = null!;

    public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }

    public virtual ICollection<PaymentAccount> PaymentAccounts { get; set; }
}
