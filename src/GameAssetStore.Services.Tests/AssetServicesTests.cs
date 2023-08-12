namespace GameAssetsStore.Services.Tests;

using GameAssetsStore.Data.Models;
using GameAssetsStore.Data.Repositories;
using GameAssetsStore.Data.Repositories.Interfaces;
using GameAssetsStore.Services.Data;
using GameAssetsStore.Services.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

using static GameAssetsStore.Data.Seeding.AssetSeed;
using static GameAssetsStore.Data.Seeding.ShopsSeed;
using static GameAssetsStore.Data.Seeding.GeneralCategorySeed;
using static GameAssetsStore.Data.Seeding.SubCategorySeed;
using static GameAssetsStore.Data.Seeding.ArtStyleSeed;
using static GameAssetsStore.Data.Seeding.ApplicationUserSeed;

public class AssetServicesTests
{
    private IRepository<Asset> assetsRepository;
    private IRepository<Shop> shopRepository;
    private IRepository<GeneralCategory> generalCategoryRepository;
    private IRepository<SubCategory> subCategoryRepository;
    private IRepository<ArtStyle> artStyleRepository;
    private IRepository<ApplicationUser> applicationUserRepository;
    private Mock<IStorageService> mockStorageService;

    private ApplicationDbContext dbContext;

    [SetUp]
    public void TestSetup()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "InMemoryDb")
            .Options;

        this.dbContext = new ApplicationDbContext(options);
        //this.dbContext.AddRange(GenerateAssets());
        //this.dbContext.AddRange(GenerateShops());
        //this.dbContext.AddRange(GenerateApplicationUsers());
        //this.dbContext.AddRange(GenerateCategories());
        //this.dbContext.AddRange(GenerateSubCategories());
        //this.dbContext.AddRange(GenerateArtStyles());

        //this.dbContext.SaveChanges();

        this.assetsRepository = new EfRepository<Asset>(this.dbContext);
        this.shopRepository = new EfRepository<Shop>(this.dbContext);
        this.generalCategoryRepository = new EfRepository<GeneralCategory>(this.dbContext);
        this.subCategoryRepository = new EfRepository<SubCategory>(this.dbContext);
        this.artStyleRepository = new EfRepository<ArtStyle>(this.dbContext);
        this.applicationUserRepository = new EfRepository<ApplicationUser>(this.dbContext);

        this.mockStorageService = new Mock<IStorageService>();

    }

    [TearDown]
    public void TearDown()
    {
        this.dbContext.Database.EnsureDeleted();
    }

    [Test]
    public async Task IsUserAssetOwner_UserIsAssetOwner_ReturnsTrue()
    {
        // Arrange
        string assetId = "6A593E06-B76D-4FC8-97A9-1400C907F378".ToLower();
        string userShopId = "D83EDC2E-D407-4411-B750-E7E55FB28FC4".ToLower();

        this.dbContext.Add(new Shop
        {
            Id = new Guid("D83EDC2E-D407-4411-B750-E7E55FB28FC4"),
            OwningUserId = new Guid("AE3730FD-295E-4778-ABC4-8A636E9F645E"),
            ShopName = "User2"
        });

        this.dbContext.Add(new Asset
        {
            Id = new Guid("6A593E06-B76D-4FC8-97A9-1400C907F378"),
            ShopId = new Guid("D83EDC2E-D407-4411-B750-E7E55FB28FC4"),
            AssetName = "Stick man Animation Walk",
            Description = "Stick man animation series. Walk.\r\n\r\nSprite sheet 5 frames.",
            Price = 1.50m,
            Version = "A-3",
            SalesCount = 0,
            CreatedOn = new DateTime(2023, 08, 03, 21, 17, 41),
            IsPublic = true,
            FileName = "spritesheet.zip",
            ArtStyleId = new Guid("9239D5BA-E831-4B1D-9F4A-7016F096D2AD")
        });

        this.dbContext.SaveChanges();

        var assetService = new AssetService(this.assetsRepository,
            this.shopRepository,
            this.generalCategoryRepository,
            this.subCategoryRepository,
            this.artStyleRepository,
            this.applicationUserRepository,
            this.mockStorageService.Object);

        // Act
        var result = await assetService.IsUserAssetOwnerAsync(userShopId, assetId);

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public async Task IsUserAssetOwner_UserIsNotAssetOwner_ReturnsFalse()
    {
        // Arrange
        string assetId = "6A593E06-B76D-4FC8-97A9-1400C907F378".ToLower();
        string userShopId = "25C159F2-7159-4DA5-A5E1-8D0081C6E2E1".ToLower();

        this.dbContext.Add(new Shop
        {
            Id = new Guid("D83EDC2E-D407-4411-B750-E7E55FB28FC4"),
            OwningUserId = new Guid("AE3730FD-295E-4778-ABC4-8A636E9F645E"),
            ShopName = "User2"
        });

        this.dbContext.Add(new Asset
        {
            Id = new Guid("6A593E06-B76D-4FC8-97A9-1400C907F378"),
            ShopId = new Guid("D83EDC2E-D407-4411-B750-E7E55FB28FC4"),
            AssetName = "Stick man Animation Walk",
            Description = "Stick man animation series. Walk.\r\n\r\nSprite sheet 5 frames.",
            Price = 1.50m,
            Version = "A-3",
            SalesCount = 0,
            CreatedOn = new DateTime(2023, 08, 03, 21, 17, 41),
            IsPublic = true,
            FileName = "spritesheet.zip",
            ArtStyleId = new Guid("9239D5BA-E831-4B1D-9F4A-7016F096D2AD")
        });

        this.dbContext.SaveChanges();

        var assetService = new AssetService(this.assetsRepository,
            this.shopRepository,
            this.generalCategoryRepository,
            this.subCategoryRepository,
            this.artStyleRepository,
            this.applicationUserRepository,
            this.mockStorageService.Object);

        // Act
        var result = await assetService.IsUserAssetOwnerAsync(userShopId, assetId);

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public async Task IsAssetPurchasedByAnyUser_AssetIsPurchased_ReturnTrue()
    {
        // Arrange
        string assetId = "6A593E06-B76D-4FC8-97A9-1400C907F378".ToLower();

        this.dbContext.Add(new Shop
        {
            Id = new Guid("D83EDC2E-D407-4411-B750-E7E55FB28FC4"),
            OwningUserId = new Guid("AE3730FD-295E-4778-ABC4-8A636E9F645E"),
            ShopName = "User2"
        });

        this.dbContext.Add(new Asset
        {
            Id = new Guid("6A593E06-B76D-4FC8-97A9-1400C907F378"),
            ShopId = new Guid("D83EDC2E-D407-4411-B750-E7E55FB28FC4"),
            AssetName = "Stick man Animation Walk",
            Description = "Stick man animation series. Walk.\r\n\r\nSprite sheet 5 frames.",
            Price = 1.50m,
            Version = "A-3",
            SalesCount = 0,
            CreatedOn = new DateTime(2023, 08, 03, 21, 17, 41),
            IsPublic = true,
            FileName = "spritesheet.zip",
            ArtStyleId = new Guid("9239D5BA-E831-4B1D-9F4A-7016F096D2AD"),
            Users = new[] {new ApplicationUser
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
        }}
        });

        this.dbContext.SaveChanges();

        var assetService = new AssetService(this.assetsRepository,
            this.shopRepository,
            this.generalCategoryRepository,
            this.subCategoryRepository,
            this.artStyleRepository,
            this.applicationUserRepository,
            this.mockStorageService.Object);

        // Act
        var result = await assetService.IsAssetPurchasedByAnyUserAsync(assetId);

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public async Task IsAssetPurchasedByAnyUser_AssetIs_NOT_Purchased_ReturnFalse()
    {
        // Arrange
        string assetId = "6A593E06-B76D-4FC8-97A9-1400C907F378".ToLower();

        this.dbContext.Add(new Shop
        {
            Id = new Guid("D83EDC2E-D407-4411-B750-E7E55FB28FC4"),
            OwningUserId = new Guid("AE3730FD-295E-4778-ABC4-8A636E9F645E"),
            ShopName = "User2"
        });

        this.dbContext.Add(new Asset
        {
            Id = new Guid("6A593E06-B76D-4FC8-97A9-1400C907F378"),
            ShopId = new Guid("D83EDC2E-D407-4411-B750-E7E55FB28FC4"),
            AssetName = "Stick man Animation Walk",
            Description = "Stick man animation series. Walk.\r\n\r\nSprite sheet 5 frames.",
            Price = 1.50m,
            Version = "A-3",
            SalesCount = 0,
            CreatedOn = new DateTime(2023, 08, 03, 21, 17, 41),
            IsPublic = true,
            FileName = "spritesheet.zip",
            ArtStyleId = new Guid("9239D5BA-E831-4B1D-9F4A-7016F096D2AD"),
        });

        this.dbContext.SaveChanges();

        var assetService = new AssetService(this.assetsRepository,
            this.shopRepository,
            this.generalCategoryRepository,
            this.subCategoryRepository,
            this.artStyleRepository,
            this.applicationUserRepository,
            this.mockStorageService.Object);

        // Act
        var result = await assetService.IsAssetPurchasedByAnyUserAsync(assetId);

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public async Task IsUserPurchasedAsset_UserHavePurchasedAsset_ReturnTrue()
    {
        // Arrange
        string assetId = "6A593E06-B76D-4FC8-97A9-1400C907F378".ToLower();
        string userId = "37216E26-1916-41FB-B264-5D06F7872225".ToLower();

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
            PaymentMethodId = new Guid("11FC7D8E-9363-47AF-8D0C-E0EF73C471F7"),
            PurchasedAssets = new[] {new Asset
        {
            Id = new Guid("6A593E06-B76D-4FC8-97A9-1400C907F378"),
            ShopId = new Guid("D83EDC2E-D407-4411-B750-E7E55FB28FC4"),
            AssetName = "Stick man Animation Walk",
            Description = "Stick man animation series. Walk.\r\n\r\nSprite sheet 5 frames.",
            Price = 1.50m,
            Version = "A-3",
            SalesCount = 0,
            CreatedOn = new DateTime(2023, 08, 03, 21, 17, 41),
            IsPublic = true,
            FileName = "spritesheet.zip",
            ArtStyleId = new Guid("9239D5BA-E831-4B1D-9F4A-7016F096D2AD"),
        }}
        });

        this.dbContext.SaveChanges();

        var assetService = new AssetService(this.assetsRepository,
            this.shopRepository,
            this.generalCategoryRepository,
            this.subCategoryRepository,
            this.artStyleRepository,
            this.applicationUserRepository,
            this.mockStorageService.Object);

        // Act
        var result = await assetService.IsUserPurchasedAssetAsync(userId, assetId);

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public async Task IsUserPurchasedAsset_UserHave_NOT_PurchasedAsset_ReturnTrue()
    {
        // Arrange
        string assetId = "6A593E06-B76D-4FC8-97A9-1400C907F378".ToLower();
        string userId = "37216E26-1916-41FB-B264-5D06F7872225".ToLower();

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
            PaymentMethodId = new Guid("11FC7D8E-9363-47AF-8D0C-E0EF73C471F7")});

        this.dbContext.SaveChanges();

        var assetService = new AssetService(this.assetsRepository,
            this.shopRepository,
            this.generalCategoryRepository,
            this.subCategoryRepository,
            this.artStyleRepository,
            this.applicationUserRepository,
            this.mockStorageService.Object);

        // Act
        var result = await assetService.IsUserPurchasedAssetAsync(userId, assetId);

        // Assert
        Assert.IsFalse(result);
    }
}