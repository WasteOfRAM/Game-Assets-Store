namespace GameAssetsStore.Data.Configurations;

using GameAssetsStore.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using static Seeding.SubCategorySeed;

public class SubCategoryEntityConfiguration : IEntityTypeConfiguration<SubCategory>
{
    public void Configure(EntityTypeBuilder<SubCategory> builder)
    {
        builder
            .HasData(GenerateSubCategories());
    }
}
