namespace GameAssetsStore.Services.Tests;

using GameAssetsStore.Data.Models;
using GameAssetsStore.Data.Repositories;
using GameAssetsStore.Data.Repositories.Interfaces;
using GameAssetsStore.Services.Data;
using GameAssetsStore.Web.ViewModels.Shop;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

public class CartServiceTests
{
    private IRepository<Asset> assetsRepository;
    private IRepository<ApplicationUser> applicationUserRepository;

    private ApplicationDbContext dbContext;

    [SetUp]
    public void TestSetup()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "InMemoryDb")
            .Options;

        this.dbContext = new ApplicationDbContext(options);

        this.assetsRepository = new EfRepositoryBase<Asset>(this.dbContext);
        this.applicationUserRepository = new EfRepositoryBase<ApplicationUser>(this.dbContext);
    }

    [TearDown]
    public void TearDown()
    {
        this.dbContext.Database.EnsureDeleted();
        this.dbContext.Dispose();
    }

    [Test]
    public async Task GetCheckoutCartAssets_WithValidCartAndAssetsInIt()
    {
        // Arrange

        string userId = "37216E26-1916-41FB-B264-5D06F7872225".ToLower();

        string? cartJson = JsonSerializer.Serialize(new[] { new { AssetId = "97501e8c-cc13-4123-b79d-b4ef776919aa", Title = "Gear", Price = "33.33" } });

        var expected = new CheckoutViewModel
        {
            CheckoutAssets = new[] { new CheckoutAssetViewModel { AssetId = "97501e8c-cc13-4123-b79d-b4ef776919aa", Title = "Gear" } },
            PriceTotal = 33.33m,
            PaymentMethodId = "11FC7D8E-9363-47AF-8D0C-E0EF73C471F7".ToLower(),
            PaymentMethodName = "Bank1"
        };

        this.dbContext.Add(new Asset
        {
            Id = new Guid("97501E8C-CC13-4123-B79D-B4EF776919AA"),
            ShopId = new Guid("25C159F2-7159-4DA5-A5E1-8D0081C6E2E1"),
            AssetName = "Gear",
            Description = "Cogwheel with a hole.",
            Price = 33.33m,
            Version = "43.5V",
            SalesCount = 0,
            CreatedOn = new DateTime(2023, 08, 03, 20, 31, 57),
            IsPublic = true,
            FileName = "gear.zip",
            ArtStyleId = new Guid("D5BC94DD-A06C-4744-BE19-4206A84AB96C")
        });

        this.dbContext.Add(new ApplicationUser
        {
            Id = new Guid("37216E26-1916-41FB-B264-5D06F7872225"),
            UserName = "user1",
            NormalizedUserName = "USER1",
            Email = "user1@test.bg",
            NormalizedEmail = "USER1@TEST.BG",
            EmailConfirmed = true,
            PasswordHash = "AQAAAAEAACcQAAAAEEnNe39P9D9blooFfyu/rirNk7a8Cw5ggIVuNauhHCXSprf5phaf6XuYNgBZiUq7UA==",
            SecurityStamp = "HNPD455OYW2GR6AGOIK7IWTPSCRJPVBX",
            ConcurrencyStamp = "021fa647-4713-4e6e-9649-c9e33242d45a",
            PhoneNumberConfirmed = true,
            TwoFactorEnabled = false,
            LockoutEnabled = false,
            AccessFailedCount = 0,
            PaymentMethodId = new Guid("11FC7D8E-9363-47AF-8D0C-E0EF73C471F7")
        });

        this.dbContext.Add(new PaymentMethod
        {
            Id = new Guid("11FC7D8E-9363-47AF-8D0C-E0EF73C471F7"),
            Name = "Bank1"
        });

        this.dbContext.SaveChanges();

        var cartService = new CartService(this.assetsRepository, this.applicationUserRepository);

        // Act

        var actual = await cartService.GetCheckoutCartAssetsAsync(userId, cartJson);

        // Assert

        Assert.That(actual.PriceTotal, Is.EqualTo(expected.PriceTotal));
        Assert.That(actual.PaymentMethodName, Is.EqualTo(expected.PaymentMethodName));
        Assert.That(actual.PaymentMethodId, Is.EqualTo(expected.PaymentMethodId));
        Assert.That(actual.CheckoutAssets.Count(), Is.EqualTo(expected.CheckoutAssets.Count()));
    }

    [Test]
    public async Task GetCheckoutCartAssets_WithValidEmptyCart()
    {
        // Arange

        string userId = "37216E26-1916-41FB-B264-5D06F7872225".ToLower();

        string? cartJson = "[]";


        var expected = new CheckoutViewModel
        {
            PriceTotal = 0.0m,
            PaymentMethodId = "11FC7D8E-9363-47AF-8D0C-E0EF73C471F7".ToLower(),
            PaymentMethodName = "Bank1"
        };

        this.dbContext.Add(new Asset
        {
            Id = new Guid("97501E8C-CC13-4123-B79D-B4EF776919AA"),
            ShopId = new Guid("25C159F2-7159-4DA5-A5E1-8D0081C6E2E1"),
            AssetName = "Gear",
            Description = "Cogwheel with a hole.",
            Price = 33.33m,
            Version = "43.5V",
            SalesCount = 0,
            CreatedOn = new DateTime(2023, 08, 03, 20, 31, 57),
            IsPublic = true,
            FileName = "gear.zip",
            ArtStyleId = new Guid("D5BC94DD-A06C-4744-BE19-4206A84AB96C")
        });

        this.dbContext.Add(new ApplicationUser
        {
            Id = new Guid("37216E26-1916-41FB-B264-5D06F7872225"),
            UserName = "user1",
            NormalizedUserName = "USER1",
            Email = "user1@test.bg",
            NormalizedEmail = "USER1@TEST.BG",
            EmailConfirmed = true,
            PasswordHash = "AQAAAAEAACcQAAAAEEnNe39P9D9blooFfyu/rirNk7a8Cw5ggIVuNauhHCXSprf5phaf6XuYNgBZiUq7UA==",
            SecurityStamp = "HNPD455OYW2GR6AGOIK7IWTPSCRJPVBX",
            ConcurrencyStamp = "021fa647-4713-4e6e-9649-c9e33242d45a",
            PhoneNumberConfirmed = true,
            TwoFactorEnabled = false,
            LockoutEnabled = false,
            AccessFailedCount = 0,
            PaymentMethodId = new Guid("11FC7D8E-9363-47AF-8D0C-E0EF73C471F7")
        });

        this.dbContext.Add(new PaymentMethod
        {
            Id = new Guid("11FC7D8E-9363-47AF-8D0C-E0EF73C471F7"),
            Name = "Bank1"
        });

        this.dbContext.SaveChanges();

        var cartService = new CartService(this.assetsRepository, this.applicationUserRepository);

        // Act

        var actual = await cartService.GetCheckoutCartAssetsAsync(userId, cartJson);

        // Assert

        Assert.That(actual.PriceTotal, Is.EqualTo(expected.PriceTotal));
        Assert.That(actual.PaymentMethodName, Is.EqualTo(expected.PaymentMethodName));
        Assert.That(actual.PaymentMethodId, Is.EqualTo(expected.PaymentMethodId));
        Assert.That(actual.CheckoutAssets.Count(), Is.EqualTo(expected.CheckoutAssets.Count()));
    }

    [Test]
    public void GetCheckoutCartAssets_WithNullCartThrowsException()
    {
        // Arrange

        string userId = "37216E26-1916-41FB-B264-5D06F7872225".ToLower();

        string? cartJson = null;

        var cartService = new CartService(this.assetsRepository, this.applicationUserRepository);

        // Act

        // Assert

        Assert.ThrowsAsync<NullReferenceException>(async () =>
        {
            await cartService.GetCheckoutCartAssetsAsync(userId, cartJson);
        }, "The cart was not retrieved.");
    }
}
