using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameAssetsStore.Data.Migrations
{
    public partial class SellerNameChangeToShop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assets_Sellers_SellerId",
                table: "Assets");

            migrationBuilder.DropTable(
                name: "Sellers");

            migrationBuilder.RenameColumn(
                name: "SellerId",
                table: "Assets",
                newName: "ShopId");

            migrationBuilder.RenameIndex(
                name: "IX_Assets_SellerId",
                table: "Assets",
                newName: "IX_Assets_ShopId");

            migrationBuilder.CreateTable(
                name: "Shops",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OwningUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "User owning the shop profile."),
                    ShopName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "Optional name for the seller page."),
                    SupportEmail = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Optional email address for asset questions and support.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shops_AspNetUsers_OwningUserId",
                        column: x => x.OwningUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shops_OwningUserId",
                table: "Shops",
                column: "OwningUserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_Shops_ShopId",
                table: "Assets",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assets_Shops_ShopId",
                table: "Assets");

            migrationBuilder.DropTable(
                name: "Shops");

            migrationBuilder.RenameColumn(
                name: "ShopId",
                table: "Assets",
                newName: "SellerId");

            migrationBuilder.RenameIndex(
                name: "IX_Assets_ShopId",
                table: "Assets",
                newName: "IX_Assets_SellerId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Sellers_OwningUserId",
                table: "Sellers",
                column: "OwningUserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_Sellers_SellerId",
                table: "Assets",
                column: "SellerId",
                principalTable: "Sellers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
