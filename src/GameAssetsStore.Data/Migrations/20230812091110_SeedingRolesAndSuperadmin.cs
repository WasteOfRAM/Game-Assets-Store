using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameAssetsStore.Data.Migrations
{
    public partial class SeedingRolesAndSuperadmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Balance",
                table: "PaymentMethods",
                type: "money",
                nullable: false,
                defaultValue: 1000.00m,
                comment: "A fake balance.",
                oldClrType: typeof(decimal),
                oldType: "money",
                oldDefaultValue: 100.00m,
                oldComment: "A fake balance.");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("ca808a49-1993-4f34-bd87-5f05191a24e2"), "10d9ce30-ee30-4b29-a165-13d1ea274e4c", "SuperAdmin", "SUPERADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("d1cfb3d4-72f7-4a38-9d52-fda32639e459"), "f58f19e9-c031-4606-bfdc-ce8ba425ee22", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PaymentMethodId", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("3bd229ce-a8ad-4c29-a0e8-6f1cdb668076"), 0, "52728f30-1e14-48d4-8549-2f571eb81c8c", "superadmin@gameassetstore.com", true, false, null, "SUPERADMIN@GAMEASSETSTORE.COM", "SUPERADMIN", "AQAAAAEAACcQAAAAEN3EmWZBaGmDR2XF/aYO+/Xmf7kRZWFBY1yD1ikL9R2wXkr1u8nNrut2EVrXqFTRMQ==", null, null, true, "BBRMPJ6KMXZG2JEHIXPFQ7QBH4XZ4324", false, "superadmin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("ca808a49-1993-4f34-bd87-5f05191a24e2"), new Guid("3bd229ce-a8ad-4c29-a0e8-6f1cdb668076") });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("d1cfb3d4-72f7-4a38-9d52-fda32639e459"), new Guid("3bd229ce-a8ad-4c29-a0e8-6f1cdb668076") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("ca808a49-1993-4f34-bd87-5f05191a24e2"), new Guid("3bd229ce-a8ad-4c29-a0e8-6f1cdb668076") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("d1cfb3d4-72f7-4a38-9d52-fda32639e459"), new Guid("3bd229ce-a8ad-4c29-a0e8-6f1cdb668076") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ca808a49-1993-4f34-bd87-5f05191a24e2"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d1cfb3d4-72f7-4a38-9d52-fda32639e459"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3bd229ce-a8ad-4c29-a0e8-6f1cdb668076"));

            migrationBuilder.AlterColumn<decimal>(
                name: "Balance",
                table: "PaymentMethods",
                type: "money",
                nullable: false,
                defaultValue: 100.00m,
                comment: "A fake balance.",
                oldClrType: typeof(decimal),
                oldType: "money",
                oldDefaultValue: 1000.00m,
                oldComment: "A fake balance.");
        }
    }
}
