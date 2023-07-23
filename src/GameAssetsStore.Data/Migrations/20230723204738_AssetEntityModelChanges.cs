using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameAssetsStore.Data.Migrations
{
    public partial class AssetEntityModelChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Assets",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                comment: "Asset asset description for the public store page.",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Asset asset description for the public store page.");

            migrationBuilder.AlterColumn<string>(
                name: "AssetName",
                table: "Assets",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                comment: "Asset public display name.",
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15,
                oldComment: "Asset public display name.");

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Assets",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                comment: "Encoded name of the user uploaded asset file.");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Assets");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Assets",
                type: "nvarchar(max)",
                nullable: false,
                comment: "Asset asset description for the public store page.",
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldComment: "Asset asset description for the public store page.");

            migrationBuilder.AlterColumn<string>(
                name: "AssetName",
                table: "Assets",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                comment: "Asset public display name.",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldComment: "Asset public display name.");
        }
    }
}
