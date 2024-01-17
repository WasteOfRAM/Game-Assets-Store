using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameAssetsStore.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUserShopId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OwnedShopId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true,
                comment: "Shop profile if created");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ca808a49-1993-4f34-bd87-5f05191a24e2"),
                column: "ConcurrencyStamp",
                value: null);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d1cfb3d4-72f7-4a38-9d52-fda32639e459"),
                column: "ConcurrencyStamp",
                value: null);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("37216e26-1916-41fb-b264-5d06f7872225"),
                column: "OwnedShopId",
                value: new Guid("25c159f2-7159-4da5-a5e1-8d0081c6e2e1"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3bd229ce-a8ad-4c29-a0e8-6f1cdb668076"),
                column: "OwnedShopId",
                value: null);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("883e940e-e696-495c-a527-f4b497de1995"),
                column: "OwnedShopId",
                value: null);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ae3730fd-295e-4778-abc4-8a636e9f645e"),
                column: "OwnedShopId",
                value: new Guid("d83edc2e-d407-4411-b750-e7e55fb28fc4"));

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("33693985-9f7e-464f-9dee-2005a19a1865"),
                column: "IsPublic",
                value: true);

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("3a815a72-fc65-4a95-bcd1-f22583602817"),
                column: "IsPublic",
                value: true);

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("588f0697-ea69-42b5-a465-c49b2d381863"),
                column: "IsPublic",
                value: true);

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("6a593e06-b76d-4fc8-97a9-1400c907f378"),
                column: "IsPublic",
                value: true);

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("755dcf8a-be70-4351-8cd3-4ebd2765e520"),
                column: "IsPublic",
                value: true);

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("97501e8c-cc13-4123-b79d-b4ef776919aa"),
                column: "IsPublic",
                value: true);

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("9e7a3e53-ae65-4908-aa4c-9291dda70717"),
                column: "IsPublic",
                value: true);

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("b02d32fa-4ae8-4724-9586-c56683ff9dcd"),
                column: "IsPublic",
                value: true);

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("c7bc601f-c4a1-4569-8b6a-cdc57714e40d"),
                column: "IsPublic",
                value: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnedShopId",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ca808a49-1993-4f34-bd87-5f05191a24e2"),
                column: "ConcurrencyStamp",
                value: "10d9ce30-ee30-4b29-a165-13d1ea274e4c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d1cfb3d4-72f7-4a38-9d52-fda32639e459"),
                column: "ConcurrencyStamp",
                value: "f58f19e9-c031-4606-bfdc-ce8ba425ee22");

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("33693985-9f7e-464f-9dee-2005a19a1865"),
                column: "IsPublic",
                value: false);

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("3a815a72-fc65-4a95-bcd1-f22583602817"),
                column: "IsPublic",
                value: false);

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("588f0697-ea69-42b5-a465-c49b2d381863"),
                column: "IsPublic",
                value: false);

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("6a593e06-b76d-4fc8-97a9-1400c907f378"),
                column: "IsPublic",
                value: false);

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("755dcf8a-be70-4351-8cd3-4ebd2765e520"),
                column: "IsPublic",
                value: false);

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("97501e8c-cc13-4123-b79d-b4ef776919aa"),
                column: "IsPublic",
                value: false);

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("9e7a3e53-ae65-4908-aa4c-9291dda70717"),
                column: "IsPublic",
                value: false);

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("b02d32fa-4ae8-4724-9586-c56683ff9dcd"),
                column: "IsPublic",
                value: false);

            migrationBuilder.UpdateData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("c7bc601f-c4a1-4569-8b6a-cdc57714e40d"),
                column: "IsPublic",
                value: false);
        }
    }
}
