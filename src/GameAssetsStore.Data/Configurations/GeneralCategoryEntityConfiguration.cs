namespace GameAssetsStore.Data.Configurations;

using GameAssetsStore.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class GeneralCategoryEntityConfiguration : IEntityTypeConfiguration<GeneralCategory>
{
    public void Configure(EntityTypeBuilder<GeneralCategory> builder)
    {
        builder
            .HasMany(c => c.SubCategories)
            .WithOne(sc => sc.Category)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
