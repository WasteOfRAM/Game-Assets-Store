using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameAssetsStore.Data.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssetsCategories_Assets_UserId",
                table: "AssetsCategories");

            migrationBuilder.DropTable(
                name: "UsersAssets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssetsCategories",
                table: "AssetsCategories");

            migrationBuilder.DropIndex(
                name: "IX_AssetsCategories_UserId",
                table: "AssetsCategories");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "AssetsCategories",
                newName: "AssetId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssetsCategories",
                table: "AssetsCategories",
                columns: new[] { "AssetId", "CategoryId" });

            migrationBuilder.CreateTable(
                name: "UsersPurchasedAssets",
                columns: table => new
                {
                    PurchasedAssetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersPurchasedAssets", x => new { x.PurchasedAssetId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UsersPurchasedAssets_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsersPurchasedAssets_Assets_PurchasedAssetId",
                        column: x => x.PurchasedAssetId,
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("37216e26-1916-41fb-b264-5d06f7872225"), 0, "021fa647-4713-4e6e-9649-c9e33242d45a", "user1@test.bg", true, false, null, "USER1@TEST.BG", "USER1", "AQAAAAEAACcQAAAAEEnNe39P9D9blooFfyu/rirNk7a8Cw5ggIVuNauhHCXSprf5phaf6XuYNgBZiUq7UA==", null, true, "HNPD455OYW2GR6AGOIK7IWTPSCRJPVBX", false, "user1" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("883e940e-e696-495c-a527-f4b497de1995"), 0, "17622983-1640-4665-9454-2e3fdf078329", "User3@test.bg", true, false, null, "USER3@TEST.BG", "USER3", "AQAAAAEAACcQAAAAEM3greQ70ALJUnEhOvFm6Yco8M6Qj7GPMwoV30FSPmvS0t/LxrsClsbJXSaRGA4mcQ==", null, true, "Q4VGRSPQVQROITNW7PRGFXCQT3YIZVLZ", false, "user3" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("ae3730fd-295e-4778-abc4-8a636e9f645e"), 0, "562f6d1b-889f-48ef-adcb-1ed2868c56ab", "User2@test.bg", true, false, null, "USER2@TEST.BG", "USER2", "AQAAAAEAACcQAAAAEFLGAbCRXD7VxA2lq/zj2ZkTVRzCPydB1knvRIK+6MdcUf935jnHbrd6v3fvcPdfPQ==", null, true, "Z2WL23KVK2KH5ILZ7XSDU6LFD7BSHQZ2", false, "User2" });

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 1, "urn:shop:shopId", "25c159f2-7159-4da5-a5e1-8d0081c6e2e1", new Guid("37216e26-1916-41fb-b264-5d06f7872225") },
                    { 2, "urn:shop:shopId", "d83edc2e-d407-4411-b750-e7e55fb28fc4", new Guid("ae3730fd-295e-4778-abc4-8a636e9f645e") }
                });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "About", "PublicEmail", "UserId", "Website" },
                values: new object[,]
                {
                    { new Guid("2b23b498-7ae0-40db-8200-a0f360635bdb"), null, null, new Guid("ae3730fd-295e-4778-abc4-8a636e9f645e"), null },
                    { new Guid("915dacdc-65f6-412e-af5d-ac191bf29487"), null, null, new Guid("883e940e-e696-495c-a527-f4b497de1995"), null },
                    { new Guid("a82abed6-405e-4438-a780-181794006611"), null, null, new Guid("37216e26-1916-41fb-b264-5d06f7872225"), null }
                });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "Id", "OwningUserId", "ShopName", "SupportEmail", "Website" },
                values: new object[,]
                {
                    { new Guid("25c159f2-7159-4da5-a5e1-8d0081c6e2e1"), new Guid("37216e26-1916-41fb-b264-5d06f7872225"), "Good Stuff", null, null },
                    { new Guid("d83edc2e-d407-4411-b750-e7e55fb28fc4"), new Guid("ae3730fd-295e-4778-abc4-8a636e9f645e"), "User2", null, null }
                });

            migrationBuilder.InsertData(
                table: "Assets",
                columns: new[] { "Id", "ArtStyleId", "AssetName", "CreatedOn", "Description", "FileName", "ModifiedOn", "Price", "ShopId", "Version" },
                values: new object[,]
                {
                    { new Guid("33693985-9f7e-464f-9dee-2005a19a1865"), new Guid("e7592028-354c-46ce-adec-b41525ccf712"), "Torus", new DateTime(2023, 8, 3, 20, 39, 48, 0, DateTimeKind.Unspecified), "Another shape\r\n\r\n\r\n\r\n\r\n\r\n", "torus.zip", null, null, new Guid("25c159f2-7159-4da5-a5e1-8d0081c6e2e1"), "Hm" },
                    { new Guid("3a815a72-fc65-4a95-bcd1-f22583602817"), new Guid("0263c1c2-da3e-4496-9cda-dcb89213a9d6"), "Bolt", new DateTime(2023, 8, 3, 20, 26, 48, 0, DateTimeKind.Unspecified), "A nice bolt.", "bolt.zip", null, 25.00m, new Guid("25c159f2-7159-4da5-a5e1-8d0081c6e2e1"), "0.2" },
                    { new Guid("588f0697-ea69-42b5-a465-c49b2d381863"), new Guid("d56f1f8f-826b-4889-a1e7-ab10ab63e975"), "Stick man Animation Idle", new DateTime(2023, 8, 3, 21, 14, 49, 0, DateTimeKind.Unspecified), "Stick man animation series. Idle.\r\n\r\nSprite sheet 5 frames.", "spritesheet.zip", null, 1.00m, new Guid("d83edc2e-d407-4411-b750-e7e55fb28fc4"), "new" },
                    { new Guid("6a593e06-b76d-4fc8-97a9-1400c907f378"), new Guid("9239d5ba-e831-4b1d-9f4a-7016f096d2ad"), "Stick man Animation Walk", new DateTime(2023, 8, 3, 21, 17, 41, 0, DateTimeKind.Unspecified), "Stick man animation series. Walk.\r\n\r\nSprite sheet 5 frames.", "spritesheet.zip", null, 1.50m, new Guid("d83edc2e-d407-4411-b750-e7e55fb28fc4"), "A-3" },
                    { new Guid("755dcf8a-be70-4351-8cd3-4ebd2765e520"), new Guid("9239d5ba-e831-4b1d-9f4a-7016f096d2ad"), "Monekey", new DateTime(2023, 8, 3, 20, 51, 0, 0, DateTimeKind.Unspecified), "Yep", "Suzanne.zip", null, null, new Guid("d83edc2e-d407-4411-b750-e7e55fb28fc4"), "z23" },
                    { new Guid("7efbf3d9-4206-4b7b-b659-f0072348d9f0"), new Guid("bb41cad1-38dc-4895-bcb4-781d25821bed"), "Cube", new DateTime(2023, 8, 3, 20, 28, 25, 0, DateTimeKind.Unspecified), "A cube. It has 6 sides! ", "cube.zip", null, null, new Guid("25c159f2-7159-4da5-a5e1-8d0081c6e2e1"), "2z" },
                    { new Guid("97501e8c-cc13-4123-b79d-b4ef776919aa"), new Guid("d5bc94dd-a06c-4744-be19-4206a84ab96c"), "Gear", new DateTime(2023, 8, 3, 20, 31, 57, 0, DateTimeKind.Unspecified), "Cogwheel with a hole.", "gear.zip", null, 33.33m, new Guid("25c159f2-7159-4da5-a5e1-8d0081c6e2e1"), "43.5V" },
                    { new Guid("9e7a3e53-ae65-4908-aa4c-9291dda70717"), new Guid("e7592028-354c-46ce-adec-b41525ccf712"), "Sphere", new DateTime(2023, 8, 3, 20, 37, 28, 0, DateTimeKind.Unspecified), "A sphere.\r\nIt can be used as a ball as well.\r\n\r\nMarble.\r\nBasically anything round sphere like that you need.\r\n\r\nI&#39;m putting it in a wrong category to test things. ", "sphere.zip", null, 345.00m, new Guid("25c159f2-7159-4da5-a5e1-8d0081c6e2e1"), "A-3" },
                    { new Guid("b02d32fa-4ae8-4724-9586-c56683ff9dcd"), new Guid("bb41cad1-38dc-4895-bcb4-781d25821bed"), "Fiber Texture", new DateTime(2023, 8, 3, 20, 44, 16, 0, DateTimeKind.Unspecified), "A texture that is actually from a real thing I did.\r\nhttps://www.youtube.com/watch?v=GzbGfSNuxSc", "fiber_set.zip", null, 17.50m, new Guid("25c159f2-7159-4da5-a5e1-8d0081c6e2e1"), "new" },
                    { new Guid("c017a10c-80f3-4184-ac8b-2b912c15d568"), new Guid("b8ec1523-e249-45cc-8c48-ef78915a5e52"), "Cylinder", new DateTime(2023, 8, 3, 20, 30, 1, 0, DateTimeKind.Unspecified), null, "Cylinder.zip", null, 2.00m, new Guid("25c159f2-7159-4da5-a5e1-8d0081c6e2e1"), "A" },
                    { new Guid("c7bc601f-c4a1-4569-8b6a-cdc57714e40d"), new Guid("77bd0468-6c70-4314-936b-b9612604e257"), "Suzanne From Blender", new DateTime(2023, 8, 3, 20, 46, 25, 0, DateTimeKind.Unspecified), "A named monkey head.", "Suzanne.zip", null, null, new Guid("25c159f2-7159-4da5-a5e1-8d0081c6e2e1"), "Suzanne" },
                    { new Guid("f3813f3f-e34a-49a6-a439-bc5a2273184c"), new Guid("b8ec1523-e249-45cc-8c48-ef78915a5e52"), "A totally different bolt", new DateTime(2023, 8, 3, 20, 49, 42, 0, DateTimeKind.Unspecified), "Will do new ones if I got time left so probably not.", "bolt.zip", null, 44.00m, new Guid("d83edc2e-d407-4411-b750-e7e55fb28fc4"), "45g" }
                });

            migrationBuilder.InsertData(
                table: "AssetsCategories",
                columns: new[] { "AssetId", "CategoryId" },
                values: new object[,]
                {
                    { new Guid("33693985-9f7e-464f-9dee-2005a19a1865"), new Guid("a27bb29f-b235-40d4-bb11-ea4318afd3c6") },
                    { new Guid("33693985-9f7e-464f-9dee-2005a19a1865"), new Guid("c98b256b-dc33-4680-a53e-084c0111844b") },
                    { new Guid("3a815a72-fc65-4a95-bcd1-f22583602817"), new Guid("59a1562a-6e96-4d82-b025-a28cb59c7e0c") },
                    { new Guid("588f0697-ea69-42b5-a465-c49b2d381863"), new Guid("5ed5f1c8-98c6-48e0-b479-51a81d3036d9") },
                    { new Guid("6a593e06-b76d-4fc8-97a9-1400c907f378"), new Guid("5ed5f1c8-98c6-48e0-b479-51a81d3036d9") },
                    { new Guid("755dcf8a-be70-4351-8cd3-4ebd2765e520"), new Guid("5ed5f1c8-98c6-48e0-b479-51a81d3036d9") },
                    { new Guid("7efbf3d9-4206-4b7b-b659-f0072348d9f0"), new Guid("59a1562a-6e96-4d82-b025-a28cb59c7e0c") },
                    { new Guid("7efbf3d9-4206-4b7b-b659-f0072348d9f0"), new Guid("e70af9fb-3fe7-430e-a959-2c201383e83a") },
                    { new Guid("97501e8c-cc13-4123-b79d-b4ef776919aa"), new Guid("59a1562a-6e96-4d82-b025-a28cb59c7e0c") },
                    { new Guid("97501e8c-cc13-4123-b79d-b4ef776919aa"), new Guid("e70af9fb-3fe7-430e-a959-2c201383e83a") },
                    { new Guid("9e7a3e53-ae65-4908-aa4c-9291dda70717"), new Guid("14b122d0-90bf-45aa-8b92-e02cd29784d3") },
                    { new Guid("b02d32fa-4ae8-4724-9586-c56683ff9dcd"), new Guid("1e746e77-4e0a-4c04-aba2-1a347767ad3a") },
                    { new Guid("c017a10c-80f3-4184-ac8b-2b912c15d568"), new Guid("59a1562a-6e96-4d82-b025-a28cb59c7e0c") },
                    { new Guid("c7bc601f-c4a1-4569-8b6a-cdc57714e40d"), new Guid("59a1562a-6e96-4d82-b025-a28cb59c7e0c") },
                    { new Guid("f3813f3f-e34a-49a6-a439-bc5a2273184c"), new Guid("14b122d0-90bf-45aa-8b92-e02cd29784d3") },
                    { new Guid("f3813f3f-e34a-49a6-a439-bc5a2273184c"), new Guid("510af335-4b59-49fe-8022-141f5cc410d4") }
                });

            migrationBuilder.InsertData(
                table: "AssetsSubCategories",
                columns: new[] { "AssetId", "SubCategoryId" },
                values: new object[,]
                {
                    { new Guid("33693985-9f7e-464f-9dee-2005a19a1865"), new Guid("4e42eba0-be74-4b1b-968d-9c104a417c10") },
                    { new Guid("33693985-9f7e-464f-9dee-2005a19a1865"), new Guid("8359654e-6e96-4254-999b-51b0ad1c9e1f") },
                    { new Guid("33693985-9f7e-464f-9dee-2005a19a1865"), new Guid("a1ae6147-9ed9-4243-8c9c-90d9a2549536") },
                    { new Guid("33693985-9f7e-464f-9dee-2005a19a1865"), new Guid("f5668d1f-6250-4da1-87d9-fe144189d1fd") },
                    { new Guid("3a815a72-fc65-4a95-bcd1-f22583602817"), new Guid("fdeb520b-93db-492b-a152-19a5a9c29227") },
                    { new Guid("588f0697-ea69-42b5-a465-c49b2d381863"), new Guid("c78774c6-65c5-4d77-ab68-d9b27aef707d") },
                    { new Guid("6a593e06-b76d-4fc8-97a9-1400c907f378"), new Guid("1359383e-3a4e-408d-91fb-aa9b9425df6f") },
                    { new Guid("6a593e06-b76d-4fc8-97a9-1400c907f378"), new Guid("c78774c6-65c5-4d77-ab68-d9b27aef707d") },
                    { new Guid("755dcf8a-be70-4351-8cd3-4ebd2765e520"), new Guid("1359383e-3a4e-408d-91fb-aa9b9425df6f") },
                    { new Guid("755dcf8a-be70-4351-8cd3-4ebd2765e520"), new Guid("2681e9d1-344b-4d58-8916-2c8732465d0a") },
                    { new Guid("755dcf8a-be70-4351-8cd3-4ebd2765e520"), new Guid("89132449-6f33-4a1a-a8a0-24a72e99fab7") },
                    { new Guid("7efbf3d9-4206-4b7b-b659-f0072348d9f0"), new Guid("d8ac59b9-c97a-47db-a3de-3c7ed15515d5") },
                    { new Guid("7efbf3d9-4206-4b7b-b659-f0072348d9f0"), new Guid("fdeb520b-93db-492b-a152-19a5a9c29227") },
                    { new Guid("97501e8c-cc13-4123-b79d-b4ef776919aa"), new Guid("d8ac59b9-c97a-47db-a3de-3c7ed15515d5") },
                    { new Guid("97501e8c-cc13-4123-b79d-b4ef776919aa"), new Guid("fdeb520b-93db-492b-a152-19a5a9c29227") },
                    { new Guid("9e7a3e53-ae65-4908-aa4c-9291dda70717"), new Guid("5dcda147-b9e1-4881-adc9-c9ed4837c8cf") },
                    { new Guid("b02d32fa-4ae8-4724-9586-c56683ff9dcd"), new Guid("d38b77d4-2ba2-404e-bc9c-ee5a55925176") },
                    { new Guid("c017a10c-80f3-4184-ac8b-2b912c15d568"), new Guid("fdeb520b-93db-492b-a152-19a5a9c29227") },
                    { new Guid("c7bc601f-c4a1-4569-8b6a-cdc57714e40d"), new Guid("1359383e-3a4e-408d-91fb-aa9b9425df6f") },
                    { new Guid("c7bc601f-c4a1-4569-8b6a-cdc57714e40d"), new Guid("fdeb520b-93db-492b-a152-19a5a9c29227") },
                    { new Guid("f3813f3f-e34a-49a6-a439-bc5a2273184c"), new Guid("a9203c28-f272-4c4c-92b8-0d75352a31cb") },
                    { new Guid("f3813f3f-e34a-49a6-a439-bc5a2273184c"), new Guid("db6a3733-625e-4ad2-bdf5-32337a91df12") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssetsCategories_CategoryId",
                table: "AssetsCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersPurchasedAssets_UserId",
                table: "UsersPurchasedAssets",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetsCategories_Assets_AssetId",
                table: "AssetsCategories",
                column: "AssetId",
                principalTable: "Assets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssetsCategories_Assets_AssetId",
                table: "AssetsCategories");

            migrationBuilder.DropTable(
                name: "UsersPurchasedAssets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssetsCategories",
                table: "AssetsCategories");

            migrationBuilder.DropIndex(
                name: "IX_AssetsCategories_CategoryId",
                table: "AssetsCategories");

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AssetsCategories",
                keyColumns: new[] { "AssetId", "CategoryId" },
                keyValues: new object[] { new Guid("33693985-9f7e-464f-9dee-2005a19a1865"), new Guid("a27bb29f-b235-40d4-bb11-ea4318afd3c6") });

            migrationBuilder.DeleteData(
                table: "AssetsCategories",
                keyColumns: new[] { "AssetId", "CategoryId" },
                keyValues: new object[] { new Guid("33693985-9f7e-464f-9dee-2005a19a1865"), new Guid("c98b256b-dc33-4680-a53e-084c0111844b") });

            migrationBuilder.DeleteData(
                table: "AssetsCategories",
                keyColumns: new[] { "AssetId", "CategoryId" },
                keyValues: new object[] { new Guid("3a815a72-fc65-4a95-bcd1-f22583602817"), new Guid("59a1562a-6e96-4d82-b025-a28cb59c7e0c") });

            migrationBuilder.DeleteData(
                table: "AssetsCategories",
                keyColumns: new[] { "AssetId", "CategoryId" },
                keyValues: new object[] { new Guid("588f0697-ea69-42b5-a465-c49b2d381863"), new Guid("5ed5f1c8-98c6-48e0-b479-51a81d3036d9") });

            migrationBuilder.DeleteData(
                table: "AssetsCategories",
                keyColumns: new[] { "AssetId", "CategoryId" },
                keyValues: new object[] { new Guid("6a593e06-b76d-4fc8-97a9-1400c907f378"), new Guid("5ed5f1c8-98c6-48e0-b479-51a81d3036d9") });

            migrationBuilder.DeleteData(
                table: "AssetsCategories",
                keyColumns: new[] { "AssetId", "CategoryId" },
                keyValues: new object[] { new Guid("755dcf8a-be70-4351-8cd3-4ebd2765e520"), new Guid("5ed5f1c8-98c6-48e0-b479-51a81d3036d9") });

            migrationBuilder.DeleteData(
                table: "AssetsCategories",
                keyColumns: new[] { "AssetId", "CategoryId" },
                keyValues: new object[] { new Guid("7efbf3d9-4206-4b7b-b659-f0072348d9f0"), new Guid("59a1562a-6e96-4d82-b025-a28cb59c7e0c") });

            migrationBuilder.DeleteData(
                table: "AssetsCategories",
                keyColumns: new[] { "AssetId", "CategoryId" },
                keyValues: new object[] { new Guid("7efbf3d9-4206-4b7b-b659-f0072348d9f0"), new Guid("e70af9fb-3fe7-430e-a959-2c201383e83a") });

            migrationBuilder.DeleteData(
                table: "AssetsCategories",
                keyColumns: new[] { "AssetId", "CategoryId" },
                keyValues: new object[] { new Guid("97501e8c-cc13-4123-b79d-b4ef776919aa"), new Guid("59a1562a-6e96-4d82-b025-a28cb59c7e0c") });

            migrationBuilder.DeleteData(
                table: "AssetsCategories",
                keyColumns: new[] { "AssetId", "CategoryId" },
                keyValues: new object[] { new Guid("97501e8c-cc13-4123-b79d-b4ef776919aa"), new Guid("e70af9fb-3fe7-430e-a959-2c201383e83a") });

            migrationBuilder.DeleteData(
                table: "AssetsCategories",
                keyColumns: new[] { "AssetId", "CategoryId" },
                keyValues: new object[] { new Guid("9e7a3e53-ae65-4908-aa4c-9291dda70717"), new Guid("14b122d0-90bf-45aa-8b92-e02cd29784d3") });

            migrationBuilder.DeleteData(
                table: "AssetsCategories",
                keyColumns: new[] { "AssetId", "CategoryId" },
                keyValues: new object[] { new Guid("b02d32fa-4ae8-4724-9586-c56683ff9dcd"), new Guid("1e746e77-4e0a-4c04-aba2-1a347767ad3a") });

            migrationBuilder.DeleteData(
                table: "AssetsCategories",
                keyColumns: new[] { "AssetId", "CategoryId" },
                keyValues: new object[] { new Guid("c017a10c-80f3-4184-ac8b-2b912c15d568"), new Guid("59a1562a-6e96-4d82-b025-a28cb59c7e0c") });

            migrationBuilder.DeleteData(
                table: "AssetsCategories",
                keyColumns: new[] { "AssetId", "CategoryId" },
                keyValues: new object[] { new Guid("c7bc601f-c4a1-4569-8b6a-cdc57714e40d"), new Guid("59a1562a-6e96-4d82-b025-a28cb59c7e0c") });

            migrationBuilder.DeleteData(
                table: "AssetsCategories",
                keyColumns: new[] { "AssetId", "CategoryId" },
                keyValues: new object[] { new Guid("f3813f3f-e34a-49a6-a439-bc5a2273184c"), new Guid("14b122d0-90bf-45aa-8b92-e02cd29784d3") });

            migrationBuilder.DeleteData(
                table: "AssetsCategories",
                keyColumns: new[] { "AssetId", "CategoryId" },
                keyValues: new object[] { new Guid("f3813f3f-e34a-49a6-a439-bc5a2273184c"), new Guid("510af335-4b59-49fe-8022-141f5cc410d4") });

            migrationBuilder.DeleteData(
                table: "AssetsSubCategories",
                keyColumns: new[] { "AssetId", "SubCategoryId" },
                keyValues: new object[] { new Guid("33693985-9f7e-464f-9dee-2005a19a1865"), new Guid("4e42eba0-be74-4b1b-968d-9c104a417c10") });

            migrationBuilder.DeleteData(
                table: "AssetsSubCategories",
                keyColumns: new[] { "AssetId", "SubCategoryId" },
                keyValues: new object[] { new Guid("33693985-9f7e-464f-9dee-2005a19a1865"), new Guid("8359654e-6e96-4254-999b-51b0ad1c9e1f") });

            migrationBuilder.DeleteData(
                table: "AssetsSubCategories",
                keyColumns: new[] { "AssetId", "SubCategoryId" },
                keyValues: new object[] { new Guid("33693985-9f7e-464f-9dee-2005a19a1865"), new Guid("a1ae6147-9ed9-4243-8c9c-90d9a2549536") });

            migrationBuilder.DeleteData(
                table: "AssetsSubCategories",
                keyColumns: new[] { "AssetId", "SubCategoryId" },
                keyValues: new object[] { new Guid("33693985-9f7e-464f-9dee-2005a19a1865"), new Guid("f5668d1f-6250-4da1-87d9-fe144189d1fd") });

            migrationBuilder.DeleteData(
                table: "AssetsSubCategories",
                keyColumns: new[] { "AssetId", "SubCategoryId" },
                keyValues: new object[] { new Guid("3a815a72-fc65-4a95-bcd1-f22583602817"), new Guid("fdeb520b-93db-492b-a152-19a5a9c29227") });

            migrationBuilder.DeleteData(
                table: "AssetsSubCategories",
                keyColumns: new[] { "AssetId", "SubCategoryId" },
                keyValues: new object[] { new Guid("588f0697-ea69-42b5-a465-c49b2d381863"), new Guid("c78774c6-65c5-4d77-ab68-d9b27aef707d") });

            migrationBuilder.DeleteData(
                table: "AssetsSubCategories",
                keyColumns: new[] { "AssetId", "SubCategoryId" },
                keyValues: new object[] { new Guid("6a593e06-b76d-4fc8-97a9-1400c907f378"), new Guid("1359383e-3a4e-408d-91fb-aa9b9425df6f") });

            migrationBuilder.DeleteData(
                table: "AssetsSubCategories",
                keyColumns: new[] { "AssetId", "SubCategoryId" },
                keyValues: new object[] { new Guid("6a593e06-b76d-4fc8-97a9-1400c907f378"), new Guid("c78774c6-65c5-4d77-ab68-d9b27aef707d") });

            migrationBuilder.DeleteData(
                table: "AssetsSubCategories",
                keyColumns: new[] { "AssetId", "SubCategoryId" },
                keyValues: new object[] { new Guid("755dcf8a-be70-4351-8cd3-4ebd2765e520"), new Guid("1359383e-3a4e-408d-91fb-aa9b9425df6f") });

            migrationBuilder.DeleteData(
                table: "AssetsSubCategories",
                keyColumns: new[] { "AssetId", "SubCategoryId" },
                keyValues: new object[] { new Guid("755dcf8a-be70-4351-8cd3-4ebd2765e520"), new Guid("2681e9d1-344b-4d58-8916-2c8732465d0a") });

            migrationBuilder.DeleteData(
                table: "AssetsSubCategories",
                keyColumns: new[] { "AssetId", "SubCategoryId" },
                keyValues: new object[] { new Guid("755dcf8a-be70-4351-8cd3-4ebd2765e520"), new Guid("89132449-6f33-4a1a-a8a0-24a72e99fab7") });

            migrationBuilder.DeleteData(
                table: "AssetsSubCategories",
                keyColumns: new[] { "AssetId", "SubCategoryId" },
                keyValues: new object[] { new Guid("7efbf3d9-4206-4b7b-b659-f0072348d9f0"), new Guid("d8ac59b9-c97a-47db-a3de-3c7ed15515d5") });

            migrationBuilder.DeleteData(
                table: "AssetsSubCategories",
                keyColumns: new[] { "AssetId", "SubCategoryId" },
                keyValues: new object[] { new Guid("7efbf3d9-4206-4b7b-b659-f0072348d9f0"), new Guid("fdeb520b-93db-492b-a152-19a5a9c29227") });

            migrationBuilder.DeleteData(
                table: "AssetsSubCategories",
                keyColumns: new[] { "AssetId", "SubCategoryId" },
                keyValues: new object[] { new Guid("97501e8c-cc13-4123-b79d-b4ef776919aa"), new Guid("d8ac59b9-c97a-47db-a3de-3c7ed15515d5") });

            migrationBuilder.DeleteData(
                table: "AssetsSubCategories",
                keyColumns: new[] { "AssetId", "SubCategoryId" },
                keyValues: new object[] { new Guid("97501e8c-cc13-4123-b79d-b4ef776919aa"), new Guid("fdeb520b-93db-492b-a152-19a5a9c29227") });

            migrationBuilder.DeleteData(
                table: "AssetsSubCategories",
                keyColumns: new[] { "AssetId", "SubCategoryId" },
                keyValues: new object[] { new Guid("9e7a3e53-ae65-4908-aa4c-9291dda70717"), new Guid("5dcda147-b9e1-4881-adc9-c9ed4837c8cf") });

            migrationBuilder.DeleteData(
                table: "AssetsSubCategories",
                keyColumns: new[] { "AssetId", "SubCategoryId" },
                keyValues: new object[] { new Guid("b02d32fa-4ae8-4724-9586-c56683ff9dcd"), new Guid("d38b77d4-2ba2-404e-bc9c-ee5a55925176") });

            migrationBuilder.DeleteData(
                table: "AssetsSubCategories",
                keyColumns: new[] { "AssetId", "SubCategoryId" },
                keyValues: new object[] { new Guid("c017a10c-80f3-4184-ac8b-2b912c15d568"), new Guid("fdeb520b-93db-492b-a152-19a5a9c29227") });

            migrationBuilder.DeleteData(
                table: "AssetsSubCategories",
                keyColumns: new[] { "AssetId", "SubCategoryId" },
                keyValues: new object[] { new Guid("c7bc601f-c4a1-4569-8b6a-cdc57714e40d"), new Guid("1359383e-3a4e-408d-91fb-aa9b9425df6f") });

            migrationBuilder.DeleteData(
                table: "AssetsSubCategories",
                keyColumns: new[] { "AssetId", "SubCategoryId" },
                keyValues: new object[] { new Guid("c7bc601f-c4a1-4569-8b6a-cdc57714e40d"), new Guid("fdeb520b-93db-492b-a152-19a5a9c29227") });

            migrationBuilder.DeleteData(
                table: "AssetsSubCategories",
                keyColumns: new[] { "AssetId", "SubCategoryId" },
                keyValues: new object[] { new Guid("f3813f3f-e34a-49a6-a439-bc5a2273184c"), new Guid("a9203c28-f272-4c4c-92b8-0d75352a31cb") });

            migrationBuilder.DeleteData(
                table: "AssetsSubCategories",
                keyColumns: new[] { "AssetId", "SubCategoryId" },
                keyValues: new object[] { new Guid("f3813f3f-e34a-49a6-a439-bc5a2273184c"), new Guid("db6a3733-625e-4ad2-bdf5-32337a91df12") });

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("2b23b498-7ae0-40db-8200-a0f360635bdb"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("915dacdc-65f6-412e-af5d-ac191bf29487"));

            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: new Guid("a82abed6-405e-4438-a780-181794006611"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("883e940e-e696-495c-a527-f4b497de1995"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("33693985-9f7e-464f-9dee-2005a19a1865"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("3a815a72-fc65-4a95-bcd1-f22583602817"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("588f0697-ea69-42b5-a465-c49b2d381863"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("6a593e06-b76d-4fc8-97a9-1400c907f378"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("755dcf8a-be70-4351-8cd3-4ebd2765e520"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("7efbf3d9-4206-4b7b-b659-f0072348d9f0"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("97501e8c-cc13-4123-b79d-b4ef776919aa"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("9e7a3e53-ae65-4908-aa4c-9291dda70717"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("b02d32fa-4ae8-4724-9586-c56683ff9dcd"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("c017a10c-80f3-4184-ac8b-2b912c15d568"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("c7bc601f-c4a1-4569-8b6a-cdc57714e40d"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("f3813f3f-e34a-49a6-a439-bc5a2273184c"));

            migrationBuilder.DeleteData(
                table: "Shops",
                keyColumn: "Id",
                keyValue: new Guid("25c159f2-7159-4da5-a5e1-8d0081c6e2e1"));

            migrationBuilder.DeleteData(
                table: "Shops",
                keyColumn: "Id",
                keyValue: new Guid("d83edc2e-d407-4411-b750-e7e55fb28fc4"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("37216e26-1916-41fb-b264-5d06f7872225"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ae3730fd-295e-4778-abc4-8a636e9f645e"));

            migrationBuilder.RenameColumn(
                name: "AssetId",
                table: "AssetsCategories",
                newName: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssetsCategories",
                table: "AssetsCategories",
                columns: new[] { "CategoryId", "UserId" });

            migrationBuilder.CreateTable(
                name: "UsersAssets",
                columns: table => new
                {
                    AssetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersAssets", x => new { x.AssetId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UsersAssets_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsersAssets_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssetsCategories_UserId",
                table: "AssetsCategories",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersAssets_UserId",
                table: "UsersAssets",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetsCategories_Assets_UserId",
                table: "AssetsCategories",
                column: "UserId",
                principalTable: "Assets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
