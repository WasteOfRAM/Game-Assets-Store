namespace GameAssetsStore.Data.Configurations;

using GameAssetsStore.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using static Seeding.GeneralCategorySeed;
using static Seeding.CategoriesSubCategoriesSeed;

public class GeneralCategoryEntityConfiguration : IEntityTypeConfiguration<GeneralCategory>
{
    public void Configure(EntityTypeBuilder<GeneralCategory> builder)
    {
        builder
            .HasMany(e => e.SubCategories)
            .WithMany(e => e.GeneralCategories)
            .UsingEntity("CategoriesSubCategories",
                sc => sc.HasOne(typeof(SubCategory)).WithMany().HasForeignKey("SubCategoryId"),
                c => c.HasOne(typeof(GeneralCategory)).WithMany().HasForeignKey("GeneralCategoryId"))
            .HasData(GenerateCategoriesSubCategories());

        builder
            .HasData(GenerateCategories());
    }
}
