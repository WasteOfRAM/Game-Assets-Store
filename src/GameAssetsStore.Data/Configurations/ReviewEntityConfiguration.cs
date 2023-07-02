namespace GameAssetsStore.Data.Configurations;

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using GameAssetsStore.Data.Models;

public class ReviewEntityConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder
            .HasOne(e => e.ReviewedAsset)
            .WithMany(e => e.Reviews)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
