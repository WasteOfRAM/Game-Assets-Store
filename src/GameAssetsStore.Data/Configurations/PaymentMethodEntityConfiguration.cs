namespace GameAssetsStore.Data.Configurations;

using GameAssetsStore.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using static Seeding.PaymentMethodSeed;

public class PaymentMethodEntityConfiguration : IEntityTypeConfiguration<PaymentMethod>
{
    public void Configure(EntityTypeBuilder<PaymentMethod> builder)
    {
        builder
            .Property(e => e.Balance)
            .HasDefaultValue(100.00m);

        builder
            .HasData(GeneratePaymentMethods());
    }
}
