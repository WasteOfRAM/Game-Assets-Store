namespace GameAssetsStore.Data.Models;

using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Transactions;

public class Transaction
{
    public Transaction()
    {
        this.Id = Guid.NewGuid();
    }

    [Key]
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public TransactionStatus Status { get; set; }

    [Column(TypeName = "money")]
    public double Value { get; set; }
}
