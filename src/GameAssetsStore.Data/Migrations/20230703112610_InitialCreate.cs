using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameAssetsStore.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Art Style",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Style name (e.g. Fantasy, Retro, SciFi, Steampunk)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Art Style", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "General Category",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "Category name (e.g. 3D, Texture, Audio)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_General Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sub Category",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "SubCategory name (e.g. LowPoly, SFX, Music)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sub Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sellers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OwningUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "User owning the seller profile."),
                    SellerName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Optional name for the seller page."),
                    SupportEmail = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Optional email address for asset questions and support.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sellers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sellers_AspNetUsers_OwningUserId",
                        column: x => x.OwningUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Assets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SellerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Seller profile owning the asset."),
                    AssetName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false, comment: "Asset public display name."),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Asset asset description for the public store page."),
                    Price = table.Column<decimal>(type: "money", nullable: true, comment: "Price of the asset"),
                    Version = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true, comment: "User defined asset version identifier."),
                    SalesCount = table.Column<int>(type: "int", nullable: false, defaultValue: 0, comment: "Asset total sales."),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date that the asset was created"),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Date that the asset was last modified"),
                    IsPublic = table.Column<bool>(type: "bit", nullable: false, defaultValue: false, comment: "Is the asset page public and asset available for purchase")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assets_Sellers_SellerId",
                        column: x => x.SellerId,
                        principalTable: "Sellers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssetsCategories",
                columns: table => new
                {
                    AssetsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GeneralCategoriesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetsCategories", x => new { x.AssetsId, x.GeneralCategoriesId });
                    table.ForeignKey(
                        name: "FK_AssetsCategories_Assets_AssetsId",
                        column: x => x.AssetsId,
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssetsCategories_General Category_GeneralCategoriesId",
                        column: x => x.GeneralCategoriesId,
                        principalTable: "General Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AssetsStyles",
                columns: table => new
                {
                    ArtStylesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssetsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetsStyles", x => new { x.ArtStylesId, x.AssetsId });
                    table.ForeignKey(
                        name: "FK_AssetsStyles_Art Style_ArtStylesId",
                        column: x => x.ArtStylesId,
                        principalTable: "Art Style",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssetsStyles_Assets_AssetsId",
                        column: x => x.AssetsId,
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AssetsSubCategories",
                columns: table => new
                {
                    AssetsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubCategoriesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetsSubCategories", x => new { x.AssetsId, x.SubCategoriesId });
                    table.ForeignKey(
                        name: "FK_AssetsSubCategories_Assets_AssetsId",
                        column: x => x.AssetsId,
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssetsSubCategories_Sub Category_SubCategoriesId",
                        column: x => x.SubCategoriesId,
                        principalTable: "Sub Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReviewCreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Review creator"),
                    ReviewedAssetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Reviewed asset"),
                    Content = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "Review text content"),
                    Likes = table.Column<int>(type: "int", nullable: false, comment: "Review likes"),
                    Dislikes = table.Column<int>(type: "int", nullable: false, comment: "Review dislikes"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date that the review was created"),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Date that the review was last edited")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_AspNetUsers_ReviewCreatorId",
                        column: x => x.ReviewCreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reviews_Assets_ReviewedAssetId",
                        column: x => x.ReviewedAssetId,
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsersAssets",
                columns: table => new
                {
                    PurchasedAssetsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersAssets", x => new { x.PurchasedAssetsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_UsersAssets_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsersAssets_Assets_PurchasedAssetsId",
                        column: x => x.PurchasedAssetsId,
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_SellerId",
                table: "Assets",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetsCategories_GeneralCategoriesId",
                table: "AssetsCategories",
                column: "GeneralCategoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetsStyles_AssetsId",
                table: "AssetsStyles",
                column: "AssetsId");

            migrationBuilder.CreateIndex(
                name: "IX_AssetsSubCategories_SubCategoriesId",
                table: "AssetsSubCategories",
                column: "SubCategoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ReviewCreatorId",
                table: "Reviews",
                column: "ReviewCreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ReviewedAssetId",
                table: "Reviews",
                column: "ReviewedAssetId");

            migrationBuilder.CreateIndex(
                name: "IX_Sellers_OwningUserId",
                table: "Sellers",
                column: "OwningUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsersAssets_UsersId",
                table: "UsersAssets",
                column: "UsersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AssetsCategories");

            migrationBuilder.DropTable(
                name: "AssetsStyles");

            migrationBuilder.DropTable(
                name: "AssetsSubCategories");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "UsersAssets");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "General Category");

            migrationBuilder.DropTable(
                name: "Art Style");

            migrationBuilder.DropTable(
                name: "Sub Category");

            migrationBuilder.DropTable(
                name: "Assets");

            migrationBuilder.DropTable(
                name: "Sellers");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
