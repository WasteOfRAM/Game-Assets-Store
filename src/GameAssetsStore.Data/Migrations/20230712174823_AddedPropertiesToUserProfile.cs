using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameAssetsStore.Data.Migrations
{
    public partial class AddedPropertiesToUserProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExternalLinkShop");

            migrationBuilder.DropTable(
                name: "ExternalLinkUserProfile");

            migrationBuilder.DropTable(
                name: "ExternalLinks");

            migrationBuilder.AddColumn<string>(
                name: "PublicEmail",
                table: "Profiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Website",
                table: "Profiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SocialLinks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SocialType = table.Column<int>(type: "int", nullable: false),
                    LinkUrl = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialLinks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShopSocialLink",
                columns: table => new
                {
                    ExternalLinksId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShopsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopSocialLink", x => new { x.ExternalLinksId, x.ShopsId });
                    table.ForeignKey(
                        name: "FK_ShopSocialLink_Shops_ShopsId",
                        column: x => x.ShopsId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShopSocialLink_SocialLinks_ExternalLinksId",
                        column: x => x.ExternalLinksId,
                        principalTable: "SocialLinks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SocialLinkUserProfile",
                columns: table => new
                {
                    SocialLinksId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserProfilesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialLinkUserProfile", x => new { x.SocialLinksId, x.UserProfilesId });
                    table.ForeignKey(
                        name: "FK_SocialLinkUserProfile_Profiles_UserProfilesId",
                        column: x => x.UserProfilesId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SocialLinkUserProfile_SocialLinks_SocialLinksId",
                        column: x => x.SocialLinksId,
                        principalTable: "SocialLinks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShopSocialLink_ShopsId",
                table: "ShopSocialLink",
                column: "ShopsId");

            migrationBuilder.CreateIndex(
                name: "IX_SocialLinkUserProfile_UserProfilesId",
                table: "SocialLinkUserProfile",
                column: "UserProfilesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShopSocialLink");

            migrationBuilder.DropTable(
                name: "SocialLinkUserProfile");

            migrationBuilder.DropTable(
                name: "SocialLinks");

            migrationBuilder.DropColumn(
                name: "PublicEmail",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "Website",
                table: "Profiles");

            migrationBuilder.CreateTable(
                name: "ExternalLinks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LinkType = table.Column<int>(type: "int", nullable: false),
                    LinkUrl = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalLinks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExternalLinkShop",
                columns: table => new
                {
                    ExternalLinksId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShopsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalLinkShop", x => new { x.ExternalLinksId, x.ShopsId });
                    table.ForeignKey(
                        name: "FK_ExternalLinkShop_ExternalLinks_ExternalLinksId",
                        column: x => x.ExternalLinksId,
                        principalTable: "ExternalLinks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExternalLinkShop_Shops_ShopsId",
                        column: x => x.ShopsId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExternalLinkUserProfile",
                columns: table => new
                {
                    ExternalLinksId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserProfilesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalLinkUserProfile", x => new { x.ExternalLinksId, x.UserProfilesId });
                    table.ForeignKey(
                        name: "FK_ExternalLinkUserProfile_ExternalLinks_ExternalLinksId",
                        column: x => x.ExternalLinksId,
                        principalTable: "ExternalLinks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExternalLinkUserProfile_Profiles_UserProfilesId",
                        column: x => x.UserProfilesId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExternalLinkShop_ShopsId",
                table: "ExternalLinkShop",
                column: "ShopsId");

            migrationBuilder.CreateIndex(
                name: "IX_ExternalLinkUserProfile_UserProfilesId",
                table: "ExternalLinkUserProfile",
                column: "UserProfilesId");
        }
    }
}
