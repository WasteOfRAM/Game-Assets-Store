using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameAssetsStore.Data.Migrations
{
    public partial class AssetArtstyleRelationChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssetsStyles");

            migrationBuilder.AddColumn<Guid>(
                name: "ArtStyleId",
                table: "Assets",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "Asset art style");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_ArtStyleId",
                table: "Assets",
                column: "ArtStyleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_Art Style_ArtStyleId",
                table: "Assets",
                column: "ArtStyleId",
                principalTable: "Art Style",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assets_Art Style_ArtStyleId",
                table: "Assets");

            migrationBuilder.DropIndex(
                name: "IX_Assets_ArtStyleId",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "ArtStyleId",
                table: "Assets");

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

            migrationBuilder.CreateIndex(
                name: "IX_AssetsStyles_AssetsId",
                table: "AssetsStyles",
                column: "AssetsId");
        }
    }
}
