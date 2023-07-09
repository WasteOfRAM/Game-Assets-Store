﻿// <auto-generated />
using System;
using GameAssetsStore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GameAssetsStore.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230709225312_SocialsToExternalLinksChange")]
    partial class SocialsToExternalLinksChange
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AssetsCategories", b =>
                {
                    b.Property<Guid>("AssetsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GeneralCategoriesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AssetsId", "GeneralCategoriesId");

                    b.HasIndex("GeneralCategoriesId");

                    b.ToTable("AssetsCategories");
                });

            modelBuilder.Entity("AssetsStyles", b =>
                {
                    b.Property<Guid>("ArtStylesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AssetsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ArtStylesId", "AssetsId");

                    b.HasIndex("AssetsId");

                    b.ToTable("AssetsStyles");
                });

            modelBuilder.Entity("AssetsSubCategories", b =>
                {
                    b.Property<Guid>("AssetsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SubCategoriesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AssetsId", "SubCategoriesId");

                    b.HasIndex("SubCategoriesId");

                    b.ToTable("AssetsSubCategories");
                });

            modelBuilder.Entity("ExternalLinkShop", b =>
                {
                    b.Property<Guid>("ExternalLinksId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ShopsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ExternalLinksId", "ShopsId");

                    b.HasIndex("ShopsId");

                    b.ToTable("ExternalLinkShop");
                });

            modelBuilder.Entity("ExternalLinkUserProfile", b =>
                {
                    b.Property<Guid>("ExternalLinksId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserProfilesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ExternalLinksId", "UserProfilesId");

                    b.HasIndex("UserProfilesId");

                    b.ToTable("ExternalLinkUserProfile");
                });

            modelBuilder.Entity("GameAssetsStore.Data.Models.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("GameAssetsStore.Data.Models.ArtStyle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasComment("Style name (e.g. Fantasy, Retro, SciFi, Steampunk)");

                    b.HasKey("Id");

                    b.ToTable("Art Style");
                });

            modelBuilder.Entity("GameAssetsStore.Data.Models.Asset", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AssetName")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasComment("Asset public display name.");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2")
                        .HasComment("Date that the asset was created");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Asset asset description for the public store page.");

                    b.Property<bool>("IsPublic")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false)
                        .HasComment("Is the asset page public and asset available for purchase");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2")
                        .HasComment("Date that the asset was last modified");

                    b.Property<decimal?>("Price")
                        .HasColumnType("money")
                        .HasComment("Price of the asset");

                    b.Property<int>("SalesCount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0)
                        .HasComment("Asset total sales.");

                    b.Property<Guid>("ShopId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Seller profile owning the asset.");

                    b.Property<string>("Version")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasComment("User defined asset version identifier.");

                    b.HasKey("Id");

                    b.HasIndex("ShopId");

                    b.ToTable("Assets");
                });

            modelBuilder.Entity("GameAssetsStore.Data.Models.ExternalLink", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("LinkType")
                        .HasColumnType("int");

                    b.Property<string>("LinkUrl")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.HasKey("Id");

                    b.ToTable("ExternalLinks");
                });

            modelBuilder.Entity("GameAssetsStore.Data.Models.GeneralCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasComment("Category name (e.g. 3D, Texture, Audio)");

                    b.HasKey("Id");

                    b.ToTable("General Category");
                });

            modelBuilder.Entity("GameAssetsStore.Data.Models.Review", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasComment("Review text content");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2")
                        .HasComment("Date that the review was created");

                    b.Property<int>("Dislikes")
                        .HasColumnType("int")
                        .HasComment("Review dislikes");

                    b.Property<int>("Likes")
                        .HasColumnType("int")
                        .HasComment("Review likes");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2")
                        .HasComment("Date that the review was last edited");

                    b.Property<Guid>("ReviewCreatorId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Review creator");

                    b.Property<Guid>("ReviewedAssetId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("Reviewed asset");

                    b.HasKey("Id");

                    b.HasIndex("ReviewCreatorId");

                    b.HasIndex("ReviewedAssetId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("GameAssetsStore.Data.Models.Shop", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OwningUserId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("User owning the shop profile.");

                    b.Property<string>("ShopName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Optional name for the seller page.");

                    b.Property<string>("SupportEmail")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Optional email address for asset questions and support.");

                    b.HasKey("Id");

                    b.HasIndex("OwningUserId")
                        .IsUnique();

                    b.ToTable("Shops");
                });

            modelBuilder.Entity("GameAssetsStore.Data.Models.SubCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasComment("SubCategory name (e.g. LowPoly, SFX, Music)");

                    b.HasKey("Id");

                    b.ToTable("Sub Category");
                });

            modelBuilder.Entity("GameAssetsStore.Data.Models.UserProfile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("About")
                        .HasMaxLength(1500)
                        .HasColumnType("nvarchar(1500)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("UsersAssets", b =>
                {
                    b.Property<Guid>("PurchasedAssetsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsersId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PurchasedAssetsId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("UsersAssets");
                });

            modelBuilder.Entity("AssetsCategories", b =>
                {
                    b.HasOne("GameAssetsStore.Data.Models.Asset", null)
                        .WithMany()
                        .HasForeignKey("AssetsId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("GameAssetsStore.Data.Models.GeneralCategory", null)
                        .WithMany()
                        .HasForeignKey("GeneralCategoriesId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("AssetsStyles", b =>
                {
                    b.HasOne("GameAssetsStore.Data.Models.ArtStyle", null)
                        .WithMany()
                        .HasForeignKey("ArtStylesId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("GameAssetsStore.Data.Models.Asset", null)
                        .WithMany()
                        .HasForeignKey("AssetsId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("AssetsSubCategories", b =>
                {
                    b.HasOne("GameAssetsStore.Data.Models.Asset", null)
                        .WithMany()
                        .HasForeignKey("AssetsId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("GameAssetsStore.Data.Models.SubCategory", null)
                        .WithMany()
                        .HasForeignKey("SubCategoriesId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("ExternalLinkShop", b =>
                {
                    b.HasOne("GameAssetsStore.Data.Models.ExternalLink", null)
                        .WithMany()
                        .HasForeignKey("ExternalLinksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameAssetsStore.Data.Models.Shop", null)
                        .WithMany()
                        .HasForeignKey("ShopsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ExternalLinkUserProfile", b =>
                {
                    b.HasOne("GameAssetsStore.Data.Models.ExternalLink", null)
                        .WithMany()
                        .HasForeignKey("ExternalLinksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameAssetsStore.Data.Models.UserProfile", null)
                        .WithMany()
                        .HasForeignKey("UserProfilesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GameAssetsStore.Data.Models.Asset", b =>
                {
                    b.HasOne("GameAssetsStore.Data.Models.Shop", "Shop")
                        .WithMany("ShopAssets")
                        .HasForeignKey("ShopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Shop");
                });

            modelBuilder.Entity("GameAssetsStore.Data.Models.Review", b =>
                {
                    b.HasOne("GameAssetsStore.Data.Models.UserProfile", "ReviewCreator")
                        .WithMany("Reviews")
                        .HasForeignKey("ReviewCreatorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("GameAssetsStore.Data.Models.Asset", "ReviewedAsset")
                        .WithMany("Reviews")
                        .HasForeignKey("ReviewedAssetId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ReviewCreator");

                    b.Navigation("ReviewedAsset");
                });

            modelBuilder.Entity("GameAssetsStore.Data.Models.Shop", b =>
                {
                    b.HasOne("GameAssetsStore.Data.Models.ApplicationUser", "OwningUser")
                        .WithOne("OwnedShop")
                        .HasForeignKey("GameAssetsStore.Data.Models.Shop", "OwningUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OwningUser");
                });

            modelBuilder.Entity("GameAssetsStore.Data.Models.UserProfile", b =>
                {
                    b.HasOne("GameAssetsStore.Data.Models.ApplicationUser", "User")
                        .WithOne("Profile")
                        .HasForeignKey("GameAssetsStore.Data.Models.UserProfile", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("GameAssetsStore.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("GameAssetsStore.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameAssetsStore.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("GameAssetsStore.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UsersAssets", b =>
                {
                    b.HasOne("GameAssetsStore.Data.Models.Asset", null)
                        .WithMany()
                        .HasForeignKey("PurchasedAssetsId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("GameAssetsStore.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("GameAssetsStore.Data.Models.ApplicationUser", b =>
                {
                    b.Navigation("OwnedShop");

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("GameAssetsStore.Data.Models.Asset", b =>
                {
                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("GameAssetsStore.Data.Models.Shop", b =>
                {
                    b.Navigation("ShopAssets");
                });

            modelBuilder.Entity("GameAssetsStore.Data.Models.UserProfile", b =>
                {
                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
