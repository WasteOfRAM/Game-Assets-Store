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
            .HasOne(e => e.ArtStyle)
            .WithMany(e => e.Assets)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasMany(e => e.Users)
            .WithMany(e => e.PurchasedAssets)
            .UsingEntity(
                "UsersAssets", 
                e => e.HasOne(typeof(ApplicationUser)).WithMany().HasForeignKey("UserId").OnDelete(DeleteBehavior.Restrict),
                e => e.HasOne(typeof(Asset)).WithMany().HasForeignKey("AssetId").OnDelete(DeleteBehavior.Restrict));

        builder
            .HasMany(e => e.GeneralCategories)
            .WithMany(e => e.Assets)
            .UsingEntity(
                "AssetsCategories", 
                e => e.HasOne(typeof(GeneralCategory)).WithMany().HasForeignKey("CategoryId").OnDelete(DeleteBehavior.Restrict), 
                e => e.HasOne(typeof(Asset)).WithMany().HasForeignKey("UserId").OnDelete(DeleteBehavior.Restrict));


        builder
            .HasMany(e => e.SubCategories)
            .WithMany(e => e.Assets)
            .UsingEntity(
                "AssetsSubCategories", 
                e => e.HasOne(typeof(SubCategory)).WithMany().HasForeignKey("SubCategoryId").OnDelete(DeleteBehavior.Restrict), 
                e => e.HasOne(typeof(Asset)).WithMany().HasForeignKey("AssetId").OnDelete(DeleteBehavior.Restrict));
    }
}
