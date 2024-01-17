namespace GameAssetsStore.Data.Seeding;

using GameAssetsStore.Data.Models;
using Microsoft.AspNetCore.Identity;

using static Common.GlobalConstants;

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
            OwnedShopId = new Guid("25C159F2-7159-4DA5-A5E1-8D0081C6E2E1"),
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
            OwnedShopId = new Guid("D83EDC2E-D407-4411-B750-E7E55FB28FC4"),
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

        user = new ApplicationUser
        {
            Id = new Guid("3BD229CE-A8AD-4C29-A0E8-6F1CDB668076"),
            UserName = "superadmin",
            NormalizedUserName = "SUPERADMIN",
            Email = "superadmin@gameassetstore.com",
            NormalizedEmail = "SUPERADMIN@GAMEASSETSTORE.COM",
            EmailConfirmed = true,
            PasswordHash = "AQAAAAEAACcQAAAAEN3EmWZBaGmDR2XF/aYO+/Xmf7kRZWFBY1yD1ikL9R2wXkr1u8nNrut2EVrXqFTRMQ==",
            SecurityStamp = "BBRMPJ6KMXZG2JEHIXPFQ7QBH4XZ4324",
            ConcurrencyStamp = "52728f30-1e14-48d4-8549-2f571eb81c8c",
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

    public static IdentityRole<Guid>[] GenerateIdentityRoles()
    {
        ICollection<IdentityRole<Guid>> roles = new HashSet<IdentityRole<Guid>>();

        IdentityRole<Guid> role;

        role = new IdentityRole<Guid>
        {
            Id = new Guid("ca808a49-1993-4f34-bd87-5f05191a24e2"),
            Name = SuperAdminRole,
            NormalizedName = SuperAdminRole.ToUpper(),
        };

        roles.Add(role);

        role = new IdentityRole<Guid>
        {
            Id = new Guid("d1cfb3d4-72f7-4a38-9d52-fda32639e459"),
            Name = AdminRole,
            NormalizedName = AdminRole.ToUpper(),
        };

        roles.Add(role);

        return roles.ToArray();
    }

    public static IdentityUserRole<Guid>[] GenerateUserRoles()
    {
        ICollection<IdentityUserRole<Guid>> userRoles = new HashSet<IdentityUserRole<Guid>>();

        IdentityUserRole<Guid> userRole;

        userRole = new IdentityUserRole<Guid>
        {
            RoleId = new Guid("ca808a49-1993-4f34-bd87-5f05191a24e2"),
            UserId = new Guid("3BD229CE-A8AD-4C29-A0E8-6F1CDB668076")
        };

        userRoles.Add(userRole);

        userRole = new IdentityUserRole<Guid>
        {
            RoleId = new Guid("d1cfb3d4-72f7-4a38-9d52-fda32639e459"),
            UserId = new Guid("3BD229CE-A8AD-4C29-A0E8-6F1CDB668076")
        };

        userRoles.Add(userRole);

        return userRoles.ToArray();
    }
}
