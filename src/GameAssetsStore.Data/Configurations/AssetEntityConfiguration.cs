namespace GameAssetsStore.Data.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Data.Models;

public class AssetEntityConfiguration : IEntityTypeConfiguration<Asset>
{
    public void Configure(EntityTypeBuilder<Asset> builder)
    {
        builder
            .Property(e => e.SalesCount)
            .HasDefaultValue(0);

        builder
            .Property(e => e.IsPublic)
            .HasDefaultValue(false);

        builder
            .HasMany(e => e.Users)
            .WithMany(e => e.PurchasedAssets)
            .UsingEntity("UsersAssets");

        builder
            .HasMany(e => e.GeneralCategories)
            .WithMany(e => e.Assets)
            .UsingEntity("AssetsCategories");

        builder
            .HasMany(e => e.SubCategories)
            .WithMany(e => e.Assets)
            .UsingEntity("AssetsSubCategories");

        builder
            .HasMany(e => e.ArtStyles)
            .WithMany(e => e.Assets)
            .UsingEntity("AssetsStyles");
    }
}
