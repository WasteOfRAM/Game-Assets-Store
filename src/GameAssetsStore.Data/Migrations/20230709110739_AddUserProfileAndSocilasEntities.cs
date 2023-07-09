using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameAssetsStore.Data.Migrations
{
    public partial class AddUserProfileAndSocilasEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_AspNetUsers_ReviewCreatorId",
                table: "Reviews");

            migrationBuilder.AddColumn<Guid>(
                name: "SocialsID",
                table: "Shops",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SocialsID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    About = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profiles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Socials",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "User or shop owning the socials"),
                    PublicEmail = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                    Website = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                    Twitter = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                    Facebook = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                    Instagram = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                    ArtStation = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                    DeviantArt = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                    GitHub = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                    YouTube = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Socials", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_UserId",
                table: "Profiles",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Profiles_ReviewCreatorId",
                table: "Reviews",
                column: "ReviewCreatorId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Profiles_ReviewCreatorId",
                table: "Reviews");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "Socials");

            migrationBuilder.DropColumn(
                name: "SocialsID",
                table: "Shops");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_AspNetUsers_ReviewCreatorId",
                table: "Reviews",
                column: "ReviewCreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
