using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameAssetsStore.Data.Migrations
{
    public partial class AddingFakePaymentmethod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PaymentMethodId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Name of the payment method"),
                    Balance = table.Column<decimal>(type: "money", nullable: false, defaultValue: 100.00m, comment: "A fake balance.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.Id);
                },
                comment: "A fake payment method fo testing");

            migrationBuilder.InsertData(
                table: "PaymentMethods",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("11fc7d8e-9363-47af-8d0c-e0ef73c471f7"), "Bank1" });

            migrationBuilder.InsertData(
                table: "PaymentMethods",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("4ab3226d-a16d-49e6-8d91-0bd99cc15d8f"), "Bank2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("37216e26-1916-41fb-b264-5d06f7872225"),
                column: "PaymentMethodId",
                value: new Guid("11fc7d8e-9363-47af-8d0c-e0ef73c471f7"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ae3730fd-295e-4778-abc4-8a636e9f645e"),
                column: "PaymentMethodId",
                value: new Guid("4ab3226d-a16d-49e6-8d91-0bd99cc15d8f"));

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PaymentMethodId",
                table: "AspNetUsers",
                column: "PaymentMethodId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_PaymentMethods_PaymentMethodId",
                table: "AspNetUsers",
                column: "PaymentMethodId",
                principalTable: "PaymentMethods",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_PaymentMethods_PaymentMethodId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "PaymentMethods");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PaymentMethodId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PaymentMethodId",
                table: "AspNetUsers");
        }
    }
}
