namespace GameAssetsStore.Data.Configurations;

using GameAssetsStore.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using static Seeding.ArtStyleSeed;

public class ArtStyleEntityConfiguration : IEntityTypeConfiguration<ArtStyle>
{
    public void Configure(EntityTypeBuilder<ArtStyle> builder)
    {
        builder
            .HasData(GenerateArtStyles());
    }
}
