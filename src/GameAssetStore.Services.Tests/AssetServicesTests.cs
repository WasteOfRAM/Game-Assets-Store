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
using GameAssetsStore.Web.ViewModels.Manage;

using static Common.GlobalConstants;

using static GameAssetsStore.Data.Seeding.AssetSeed;
using static GameAssetsStore.Data.Seeding.ShopsSeed;
using static GameAssetsStore.Data.Seeding.GeneralCategorySeed;
using static GameAssetsStore.Data.Seeding.SubCategorySeed;
using static GameAssetsStore.Data.Seeding.ArtStyleSeed;
using static GameAssetsStore.Data.Seeding.ApplicationUserSeed;

public class AssetServicesTests
{
    private IAssetRepository assetsRepository;
    private IShopRepository shopRepository;
    private IGeneralCategoryRepository generalCategoryRepository;
    private ISubCategoryRepository subCategoryRepository;
    private IArtStyleRepository artStyleRepository;
    private IUserRepository applicationUserRepository;
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

        this.assetsRepository = new AssetRepository(this.dbContext);
        this.shopRepository = new ShopRepository(this.dbContext);
        this.generalCategoryRepository = new GeneralCategoryRepository(this.dbContext);
        this.subCategoryRepository = new SubCategoryRepository(this.dbContext);
        this.artStyleRepository = new ArtStyleRepository(this.dbContext);
        this.applicationUserRepository = new UserRepository(this.dbContext);

        this.mockStorageService = new Mock<IStorageService>();

    }

    [TearDown]
    public void TearDown()
    {
        this.dbContext.Database.EnsureDeleted();
        this.dbContext.Dispose();
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
        Assert.That(result, Is.True);
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
        Assert.That(result, Is.False);
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
        Assert.That(result, Is.True);
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
        Assert.That(result, Is.False);
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
        Assert.That(result, Is.True);
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
        Assert.That(result, Is.False);
    }

    [Test]
    public async Task GetShopManagerAssetViewModel_ReturnsListOfViewModel()
    {
        // Arrange
        string shopId = "25C159F2-7159-4DA5-A5E1-8D0081C6E2E1".ToLower();

        List<ManageAssetCardViewModel> expected = new List<ManageAssetCardViewModel>
        {
            new ManageAssetCardViewModel
            {
                Id = new Guid("C017A10C-80F3-4184-AC8B-2B912C15D568"),
                AssetName = "Cylinder",
                FileName = "Cylinder.zip",
                Description = null,
                CoverImageUrl = string.Format(AWSS3ImageUrl, AWSS3Region, "C017A10C-80F3-4184-AC8B-2B912C15D568".ToLower(), "cover"),
                ArtStyle = "Futuristic",
                Price = 2.00m,
                Version = "A",
                SalesCount = 0,
                CreatedOn = new DateTime(2023, 08, 03, 20, 30, 1),
                ModifiedOn = null,
                IsPublic = false
            }
        };

        var asset = new Asset
        {
            Id = new Guid("C017A10C-80F3-4184-AC8B-2B912C15D568"),
            ShopId = new Guid("25C159F2-7159-4DA5-A5E1-8D0081C6E2E1"),
            AssetName = "Cylinder",
            Description = null,
            Price = 2.00m,
            Version = "A",
            SalesCount = 0,
            CreatedOn = new DateTime(2023, 08, 03, 20, 30, 1),
            IsPublic = false,
            FileName = "Cylinder.zip",
            ArtStyleId = new Guid("B8EC1523-E249-45CC-8C48-EF78915A5E52"),
            IsDeleted = false
        };

        var user = new ApplicationUser
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
        };

        this.dbContext.Add(user);

        this.dbContext.Add(new Shop
        {
            Id = new Guid("25C159F2-7159-4DA5-A5E1-8D0081C6E2E1"),
            OwningUserId = new Guid("37216E26-1916-41FB-B264-5D06F7872225"),
            ShopName = "Good Stuff",
            ShopAssets = new List<Asset> {  asset }
        });

        this.dbContext.AddRange( asset);

        var artStyle1 = new ArtStyle
        {
            Id = new Guid("B8EC1523-E249-45CC-8C48-EF78915A5E52"),
            Name = "Futuristic"
        };

        var artStyle2 = new ArtStyle
        {
            Id = new Guid("E7592028-354C-46CE-ADEC-B41525CCF712"),
            Name = "Sci-Fi"
        };

        this.dbContext.AddRange(artStyle1, artStyle2);

        this.dbContext.SaveChanges();

        var assetService = new AssetService(this.assetsRepository,
            this.shopRepository,
            this.generalCategoryRepository,
            this.subCategoryRepository,
            this.artStyleRepository,
            this.applicationUserRepository,
            this.mockStorageService.Object);

        // Act

        var actual = await assetService.GetShopManagerAssetViewModelAsync(shopId);

        // Assert
        Assert.That(expected[0].Id, Is.EqualTo(actual[0].Id));
    }

    [Test]
    public async Task GetShopManagerAssetViewModel_ReturnsEmptyListIfShopHasNoAssets()
    {
        // Arrange
        string shopId = "D83EDC2E-D407-4411-B750-E7E55FB28FC4".ToLower();

        int expected = 0;

        var asset = new Asset
        {
            Id = new Guid("C017A10C-80F3-4184-AC8B-2B912C15D568"),
            ShopId = new Guid("25C159F2-7159-4DA5-A5E1-8D0081C6E2E1"),
            AssetName = "Cylinder",
            Description = null,
            Price = 2.00m,
            Version = "A",
            SalesCount = 0,
            CreatedOn = new DateTime(2023, 08, 03, 20, 30, 1),
            IsPublic = false,
            FileName = "Cylinder.zip",
            ArtStyleId = new Guid("B8EC1523-E249-45CC-8C48-EF78915A5E52"),
            IsDeleted = false
        };

        var user = new ApplicationUser
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
        };

        this.dbContext.Add(user);

        this.dbContext.Add(new Shop
        {
            Id = new Guid("25C159F2-7159-4DA5-A5E1-8D0081C6E2E1"),
            OwningUserId = new Guid("37216E26-1916-41FB-B264-5D06F7872225"),
            ShopName = "Good Stuff",
            ShopAssets = new List<Asset> { asset }
        });

        this.dbContext.AddRange(asset);

        var artStyle1 = new ArtStyle
        {
            Id = new Guid("B8EC1523-E249-45CC-8C48-EF78915A5E52"),
            Name = "Futuristic"
        };

        var artStyle2 = new ArtStyle
        {
            Id = new Guid("E7592028-354C-46CE-ADEC-B41525CCF712"),
            Name = "Sci-Fi"
        };

        this.dbContext.AddRange(artStyle1, artStyle2);

        this.dbContext.SaveChanges();

        var assetService = new AssetService(this.assetsRepository,
            this.shopRepository,
            this.generalCategoryRepository,
            this.subCategoryRepository,
            this.artStyleRepository,
            this.applicationUserRepository,
            this.mockStorageService.Object);

        // Act

        var actual = await assetService.GetShopManagerAssetViewModelAsync(shopId);

        // Assert
        Assert.That(expected, Is.EqualTo(actual.Count()));
    }
}