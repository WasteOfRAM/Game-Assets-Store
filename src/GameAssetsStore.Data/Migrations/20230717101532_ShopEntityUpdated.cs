using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameAssetsStore.Data.Migrations
{
    public partial class ShopEntityUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopSocialLink_SocialLinks_ExternalLinksId",
                table: "ShopSocialLink");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShopSocialLink",
                table: "ShopSocialLink");

            migrationBuilder.DropIndex(
                name: "IX_ShopSocialLink_ShopsId",
                table: "ShopSocialLink");

            migrationBuilder.RenameColumn(
                name: "ExternalLinksId",
                table: "ShopSocialLink",
                newName: "SocialsId");

            migrationBuilder.AlterColumn<string>(
                name: "ShopName",
                table: "Shops",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "Optional name for the seller page.",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "Optional name for the seller page.");

            migrationBuilder.AddColumn<string>(
                name: "Website",
                table: "Shops",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "About",
                table: "Profiles",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1500)",
                oldMaxLength: 1500,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShopSocialLink",
                table: "ShopSocialLink",
                columns: new[] { "ShopsId", "SocialsId" });

            migrationBuilder.CreateIndex(
                name: "IX_ShopSocialLink_SocialsId",
                table: "ShopSocialLink",
                column: "SocialsId");

            migrationBuilder.CreateIndex(
                name: "IX_Shops_ShopName",
                table: "Shops",
                column: "ShopName",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ShopSocialLink_SocialLinks_SocialsId",
                table: "ShopSocialLink",
                column: "SocialsId",
                principalTable: "SocialLinks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopSocialLink_SocialLinks_SocialsId",
                table: "ShopSocialLink");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShopSocialLink",
                table: "ShopSocialLink");

            migrationBuilder.DropIndex(
                name: "IX_ShopSocialLink_SocialsId",
                table: "ShopSocialLink");

            migrationBuilder.DropIndex(
                name: "IX_Shops_ShopName",
                table: "Shops");

            migrationBuilder.DropColumn(
                name: "Website",
                table: "Shops");

            migrationBuilder.RenameColumn(
                name: "SocialsId",
                table: "ShopSocialLink",
                newName: "ExternalLinksId");

            migrationBuilder.AlterColumn<string>(
                name: "ShopName",
                table: "Shops",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "Optional name for the seller page.",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "Optional name for the seller page.");

            migrationBuilder.AlterColumn<string>(
                name: "About",
                table: "Profiles",
                type: "nvarchar(1500)",
                maxLength: 1500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShopSocialLink",
                table: "ShopSocialLink",
                columns: new[] { "ExternalLinksId", "ShopsId" });

            migrationBuilder.CreateIndex(
                name: "IX_ShopSocialLink_ShopsId",
                table: "ShopSocialLink",
                column: "ShopsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopSocialLink_SocialLinks_ExternalLinksId",
                table: "ShopSocialLink",
                column: "ExternalLinksId",
                principalTable: "SocialLinks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
