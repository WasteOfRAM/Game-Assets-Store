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
            .UsingEntity<object> ("Users Assets", e => e.HasOne<ApplicationUser>().WithMany().OnDelete(DeleteBehavior.Restrict),
                                                  e => e.HasOne<Asset>().WithMany().OnDelete(DeleteBehavior.Restrict));

        builder
            .HasMany(e => e.GeneralCategories)
            .WithMany(e => e.Assets)
            .UsingEntity<object>("AssetsCategories", e => e.HasOne<GeneralCategory>().WithMany().OnDelete(DeleteBehavior.Restrict),
                                                     e => e.HasOne<Asset>().WithMany().OnDelete(DeleteBehavior.Restrict));


        builder
            .HasMany(e => e.SubCategories)
            .WithMany(e => e.Assets)
            .UsingEntity<object>("AssetsSubCategories", e => e.HasOne<SubCategory>().WithMany().OnDelete(DeleteBehavior.Restrict),
                                                        e => e.HasOne<Asset>().WithMany().OnDelete(DeleteBehavior.Restrict));

        builder
            .HasMany(e => e.ArtStyles)
            .WithMany(e => e.Assets)
            .UsingEntity<object>("AssetsStyles", e => e.HasOne<ArtStyle>().WithMany().OnDelete(DeleteBehavior.Restrict),
                                                 e => e.HasOne<Asset>().WithMany().OnDelete(DeleteBehavior.Restrict));
    }
}
