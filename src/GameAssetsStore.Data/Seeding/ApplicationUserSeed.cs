namespace GameAssetsStore.Data.Seeding;

using GameAssetsStore.Data.Models;
using Microsoft.AspNetCore.Identity;

public static class ApplicationUserSeed
{
    public static ApplicationUser[] GenerateApplicationUsers()
    {
        ICollection<ApplicationUser> users = new HashSet<ApplicationUser>();

        ApplicationUser user;

        user = new ApplicationUser
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

        users.Add(user);

        user = new ApplicationUser
        {
            Id = new Guid("AE3730FD-295E-4778-ABC4-8A636E9F645E"),
            UserName = "User2",
            NormalizedUserName = "USER2",
            Email = "User2@test.bg",
            NormalizedEmail = "USER2@TEST.BG",
            EmailConfirmed = true,
            PasswordHash = "AQAAAAEAACcQAAAAEFLGAbCRXD7VxA2lq/zj2ZkTVRzCPydB1knvRIK+6MdcUf935jnHbrd6v3fvcPdfPQ==",
            SecurityStamp = "Z2WL23KVK2KH5ILZ7XSDU6LFD7BSHQZ2",
            ConcurrencyStamp = "562f6d1b-889f-48ef-adcb-1ed2868c56ab",
            PhoneNumberConfirmed = true,
            TwoFactorEnabled = false,
            LockoutEnabled = false,
            AccessFailedCount = 0,
            PaymentMethodId = new Guid("4AB3226D-A16D-49E6-8D91-0BD99CC15D8F")
        };

        users.Add(user);

        user = new ApplicationUser
        {
            Id = new Guid("883E940E-E696-495C-A527-F4B497DE1995"),
            UserName = "user3",
            NormalizedUserName = "USER3",
            Email = "User3@test.bg",
            NormalizedEmail = "USER3@TEST.BG",
            EmailConfirmed = true,
            PasswordHash = "AQAAAAEAACcQAAAAEM3greQ70ALJUnEhOvFm6Yco8M6Qj7GPMwoV30FSPmvS0t/LxrsClsbJXSaRGA4mcQ==",
            SecurityStamp = "Q4VGRSPQVQROITNW7PRGFXCQT3YIZVLZ",
            ConcurrencyStamp = "17622983-1640-4665-9454-2e3fdf078329",
            PhoneNumberConfirmed = true,
            TwoFactorEnabled = false,
            LockoutEnabled = false,
            AccessFailedCount = 0
        };

        users.Add(user);


        return users.ToArray();
    }

    public static IdentityUserClaim<Guid>[] GenerateUserClaims()
    {
        ICollection<IdentityUserClaim<Guid>> claims = new HashSet<IdentityUserClaim<Guid>>();

        IdentityUserClaim<Guid> claim;

        claim = new IdentityUserClaim<Guid>
        {
            Id = 1,
            UserId = new Guid("37216E26-1916-41FB-B264-5D06F7872225"),
            ClaimType = "urn:shop:shopId",
            ClaimValue = "25c159f2-7159-4da5-a5e1-8d0081c6e2e1"
        };

        claims.Add(claim);

        claim = new IdentityUserClaim<Guid>
        {
            Id = 2,
            UserId = new Guid("AE3730FD-295E-4778-ABC4-8A636E9F645E"),
            ClaimType = "urn:shop:shopId",
            ClaimValue = "d83edc2e-d407-4411-b750-e7e55fb28fc4"
        };

        claims.Add(claim);

        return claims.ToArray();
    }
}
