namespace GameAssetsStore.Data;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using Models;
using System.Reflection;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        
    }

    public DbSet<Asset> Assets { get; set; } = null!;

    public DbSet<UserProfile> Profiles { get; set; } = null!;


    public DbSet<Shop> Shops { get; set; } = null!;

    public DbSet<GeneralCategory> GeneralCategories { get; set; } = null!;

    public DbSet<SubCategory> SubCategories { get; set; } = null!;

    public DbSet<ArtStyle> ArtStyles { get; set; } = null!;

    public DbSet<PaymentMethod> PaymentMethods { get; set; } = null!;

    public DbSet<Review> Reviews { get; set; } = null!;

    public DbSet<SocialLink> SocialLinks { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        Assembly configAssembly = Assembly.GetAssembly(typeof(ApplicationDbContext)) ??
                                  Assembly.GetExecutingAssembly();

        builder.ApplyConfigurationsFromAssembly(configAssembly);

        base.OnModelCreating(builder);
    }
}