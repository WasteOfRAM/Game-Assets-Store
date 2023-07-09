using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameAssetsStore.Data.Migrations
{
    public partial class SocialsToExternalLinksChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Socials");

            migrationBuilder.DropColumn(
                name: "SocialsID",
                table: "Shops");

            migrationBuilder.DropColumn(
                name: "SocialsID",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExternalLinkShop");

            migrationBuilder.DropTable(
                name: "ExternalLinkUserProfile");

            migrationBuilder.DropTable(
                name: "ExternalLinks");

            migrationBuilder.AddColumn<Guid>(
                name: "SocialsID",
                table: "Shops",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SocialsID",
                table: "Profiles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Socials",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ArtStation = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                    DeviantArt = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                    Facebook = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                    GitHub = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                    Instagram = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "User or shop owning the socials"),
                    PublicEmail = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                    Twitter = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                    Website = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                    YouTube = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Socials", x => x.Id);
                });
        }
    }
}
