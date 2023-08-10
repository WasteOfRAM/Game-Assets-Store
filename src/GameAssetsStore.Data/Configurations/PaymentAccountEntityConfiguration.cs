namespace GameAssetsStore.Data.Configurations;

using GameAssetsStore.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class PaymentAccountEntityConfiguration : IEntityTypeConfiguration<PaymentAccount>
{
    public void Configure(EntityTypeBuilder<PaymentAccount> builder)
    {
        builder
            .Property(p => p.Balance)
            .HasDefaultValue(100.00m);
    }
}
