using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameAssetsStore.Data.Migrations
{
    public partial class SeedingAndRelationChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assets_Art Style_ArtStyleId",
                table: "Assets");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetsCategories_Assets_AssetsId",
                table: "AssetsCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetsCategories_General Category_GeneralCategoriesId",
                table: "AssetsCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetsSubCategories_Assets_AssetsId",
                table: "AssetsSubCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetsSubCategories_Sub Category_SubCategoriesId",
                table: "AssetsSubCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_Sub Category_General Category_CategoryId",
                table: "Sub Category");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersAssets_AspNetUsers_UsersId",
                table: "UsersAssets");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersAssets_Assets_PurchasedAssetsId",
                table: "UsersAssets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sub Category",
                table: "Sub Category");

            migrationBuilder.DropIndex(
                name: "IX_Sub Category_CategoryId",
                table: "Sub Category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_General Category",
                table: "General Category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Art Style",
                table: "Art Style");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Sub Category");

            migrationBuilder.RenameTable(
                name: "Sub Category",
                newName: "SubCategories");

            migrationBuilder.RenameTable(
                name: "General Category",
                newName: "GeneralCategories");

            migrationBuilder.RenameTable(
                name: "Art Style",
                newName: "ArtStyles");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "UsersAssets",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "PurchasedAssetsId",
                table: "UsersAssets",
                newName: "AssetId");

            migrationBuilder.RenameIndex(
                name: "IX_UsersAssets_UsersId",
                table: "UsersAssets",
                newName: "IX_UsersAssets_UserId");

            migrationBuilder.RenameColumn(
                name: "SubCategoriesId",
                table: "AssetsSubCategories",
                newName: "SubCategoryId");

            migrationBuilder.RenameColumn(
                name: "AssetsId",
                table: "AssetsSubCategories",
                newName: "AssetId");

            migrationBuilder.RenameIndex(
                name: "IX_AssetsSubCategories_SubCategoriesId",
                table: "AssetsSubCategories",
                newName: "IX_AssetsSubCategories_SubCategoryId");

            migrationBuilder.RenameColumn(
                name: "GeneralCategoriesId",
                table: "AssetsCategories",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "AssetsId",
                table: "AssetsCategories",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_AssetsCategories_GeneralCategoriesId",
                table: "AssetsCategories",
                newName: "IX_AssetsCategories_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "FileName",
                table: "Assets",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                comment: "Encoded name of the user uploaded asset file.",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldComment: "Encoded name of the user uploaded asset file.");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubCategories",
                table: "SubCategories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GeneralCategories",
                table: "GeneralCategories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArtStyles",
                table: "ArtStyles",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CategoriesSubCategories",
                columns: table => new
                {
                    GeneralCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriesSubCategories", x => new { x.GeneralCategoryId, x.SubCategoryId });
                    table.ForeignKey(
                        name: "FK_CategoriesSubCategories_GeneralCategories_GeneralCategoryId",
                        column: x => x.GeneralCategoryId,
                        principalTable: "GeneralCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoriesSubCategories_SubCategories_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "SubCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ArtStyles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("4140686f-0b64-4e75-b41d-5daecf21f738"), "Cyberpunk" },
                    { new Guid("6422d0a4-b0df-475c-8350-7390b43d060a"), "Medieval" },
                    { new Guid("b643c6bc-95a2-4d41-9cca-0469d96d6993"), "Steampunk" },
                    { new Guid("be91442d-0a38-4b4b-b13c-afb1809bc2ee"), "Retro" },
                    { new Guid("c0752cd6-b3cf-4740-802b-9a0a8ae4c544"), "Futuristic" },
                    { new Guid("c5803ccd-ab07-45a0-838f-6aa239277d7b"), "Fantasy" },
                    { new Guid("dc45848f-0e07-4b14-af74-898767ee30d8"), "Modern" },
                    { new Guid("e5739d08-a73a-4dbb-b75d-2c7a2f9e6749"), "Sci-Fi" }
                });

            migrationBuilder.InsertData(
                table: "GeneralCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("14b122d0-90bf-45aa-8b92-e02cd29784d3"), "Addons" },
                    { new Guid("1e746e77-4e0a-4c04-aba2-1a347767ad3a"), "Textures" },
                    { new Guid("510af335-4b59-49fe-8022-141f5cc410d4"), "Scripts" },
                    { new Guid("59a1562a-6e96-4d82-b025-a28cb59c7e0c"), "3D" },
                    { new Guid("5ed5f1c8-98c6-48e0-b479-51a81d3036d9"), "2D" },
                    { new Guid("a27bb29f-b235-40d4-bb11-ea4318afd3c6"), "Vfx" },
                    { new Guid("c98b256b-dc33-4680-a53e-084c0111844b"), "Audio" },
                    { new Guid("e70af9fb-3fe7-430e-a959-2c201383e83a"), "Low poly" }
                });

            migrationBuilder.InsertData(
                table: "SubCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0cb36015-ffd6-4836-a0f3-2f8bc803a75e"), "Materials" },
                    { new Guid("1359383e-3a4e-408d-91fb-aa9b9425df6f"), "Characters" },
                    { new Guid("2681e9d1-344b-4d58-8916-2c8732465d0a"), "Background" },
                    { new Guid("2f53ee6b-277e-4b76-810d-15414fe7b32b"), "Decal" },
                    { new Guid("465da332-d175-4ea7-9452-eddc8d6fe7e5"), "Tileable" },
                    { new Guid("4e42eba0-be74-4b1b-968d-9c104a417c10"), "VFX 3D" },
                    { new Guid("5dcda147-b9e1-4881-adc9-c9ed4837c8cf"), "Unreal Engine" },
                    { new Guid("8359654e-6e96-4254-999b-51b0ad1c9e1f"), "Sfx" },
                    { new Guid("89132449-6f33-4a1a-a8a0-24a72e99fab7"), "UI" },
                    { new Guid("a1ae6147-9ed9-4243-8c9c-90d9a2549536"), "VFX 2D" },
                    { new Guid("a9203c28-f272-4c4c-92b8-0d75352a31cb"), "Godot" },
                    { new Guid("abf6b357-436f-43cc-8eb9-7b4cb7a333dd"), "Tile set" },
                    { new Guid("c78774c6-65c5-4d77-ab68-d9b27aef707d"), "Sprite sheet" },
                    { new Guid("ccb576a8-1774-4fb3-81f6-b1ba285da1f3"), "Music" },
                    { new Guid("d38b77d4-2ba2-404e-bc9c-ee5a55925176"), "Non Tileable" },
                    { new Guid("d8ac59b9-c97a-47db-a3de-3c7ed15515d5"), "Environment" },
                    { new Guid("db6a3733-625e-4ad2-bdf5-32337a91df12"), "Godot" },
                    { new Guid("eeb4556f-1b3e-4b25-81ef-8f2c1cc11498"), "Pixel Art" },
                    { new Guid("f5668d1f-6250-4da1-87d9-fe144189d1fd"), "Ambient" },
                    { new Guid("fdeb520b-93db-492b-a152-19a5a9c29227"), "Props" }
                });

            migrationBuilder.InsertData(
                table: "CategoriesSubCategories",
                columns: new[] { "GeneralCategoryId", "SubCategoryId" },
                values: new object[,]
                {
                    { new Guid("14b122d0-90bf-45aa-8b92-e02cd29784d3"), new Guid("5dcda147-b9e1-4881-adc9-c9ed4837c8cf") },
                    { new Guid("14b122d0-90bf-45aa-8b92-e02cd29784d3"), new Guid("a9203c28-f272-4c4c-92b8-0d75352a31cb") },
                    { new Guid("14b122d0-90bf-45aa-8b92-e02cd29784d3"), new Guid("db6a3733-625e-4ad2-bdf5-32337a91df12") },
                    { new Guid("1e746e77-4e0a-4c04-aba2-1a347767ad3a"), new Guid("2f53ee6b-277e-4b76-810d-15414fe7b32b") },
                    { new Guid("1e746e77-4e0a-4c04-aba2-1a347767ad3a"), new Guid("465da332-d175-4ea7-9452-eddc8d6fe7e5") },
                    { new Guid("1e746e77-4e0a-4c04-aba2-1a347767ad3a"), new Guid("d38b77d4-2ba2-404e-bc9c-ee5a55925176") },
                    { new Guid("510af335-4b59-49fe-8022-141f5cc410d4"), new Guid("5dcda147-b9e1-4881-adc9-c9ed4837c8cf") },
                    { new Guid("510af335-4b59-49fe-8022-141f5cc410d4"), new Guid("a9203c28-f272-4c4c-92b8-0d75352a31cb") },
                    { new Guid("510af335-4b59-49fe-8022-141f5cc410d4"), new Guid("db6a3733-625e-4ad2-bdf5-32337a91df12") },
                    { new Guid("59a1562a-6e96-4d82-b025-a28cb59c7e0c"), new Guid("0cb36015-ffd6-4836-a0f3-2f8bc803a75e") },
                    { new Guid("59a1562a-6e96-4d82-b025-a28cb59c7e0c"), new Guid("1359383e-3a4e-408d-91fb-aa9b9425df6f") },
                    { new Guid("59a1562a-6e96-4d82-b025-a28cb59c7e0c"), new Guid("d8ac59b9-c97a-47db-a3de-3c7ed15515d5") },
                    { new Guid("59a1562a-6e96-4d82-b025-a28cb59c7e0c"), new Guid("fdeb520b-93db-492b-a152-19a5a9c29227") },
                    { new Guid("5ed5f1c8-98c6-48e0-b479-51a81d3036d9"), new Guid("1359383e-3a4e-408d-91fb-aa9b9425df6f") },
                    { new Guid("5ed5f1c8-98c6-48e0-b479-51a81d3036d9"), new Guid("2681e9d1-344b-4d58-8916-2c8732465d0a") },
                    { new Guid("5ed5f1c8-98c6-48e0-b479-51a81d3036d9"), new Guid("89132449-6f33-4a1a-a8a0-24a72e99fab7") },
                    { new Guid("5ed5f1c8-98c6-48e0-b479-51a81d3036d9"), new Guid("abf6b357-436f-43cc-8eb9-7b4cb7a333dd") },
                    { new Guid("5ed5f1c8-98c6-48e0-b479-51a81d3036d9"), new Guid("c78774c6-65c5-4d77-ab68-d9b27aef707d") },
                    { new Guid("5ed5f1c8-98c6-48e0-b479-51a81d3036d9"), new Guid("eeb4556f-1b3e-4b25-81ef-8f2c1cc11498") },
                    { new Guid("5ed5f1c8-98c6-48e0-b479-51a81d3036d9"), new Guid("fdeb520b-93db-492b-a152-19a5a9c29227") },
                    { new Guid("a27bb29f-b235-40d4-bb11-ea4318afd3c6"), new Guid("4e42eba0-be74-4b1b-968d-9c104a417c10") },
                    { new Guid("a27bb29f-b235-40d4-bb11-ea4318afd3c6"), new Guid("a1ae6147-9ed9-4243-8c9c-90d9a2549536") },
                    { new Guid("c98b256b-dc33-4680-a53e-084c0111844b"), new Guid("8359654e-6e96-4254-999b-51b0ad1c9e1f") },
                    { new Guid("c98b256b-dc33-4680-a53e-084c0111844b"), new Guid("ccb576a8-1774-4fb3-81f6-b1ba285da1f3") },
                    { new Guid("c98b256b-dc33-4680-a53e-084c0111844b"), new Guid("f5668d1f-6250-4da1-87d9-fe144189d1fd") },
                    { new Guid("e70af9fb-3fe7-430e-a959-2c201383e83a"), new Guid("0cb36015-ffd6-4836-a0f3-2f8bc803a75e") },
                    { new Guid("e70af9fb-3fe7-430e-a959-2c201383e83a"), new Guid("1359383e-3a4e-408d-91fb-aa9b9425df6f") },
                    { new Guid("e70af9fb-3fe7-430e-a959-2c201383e83a"), new Guid("d8ac59b9-c97a-47db-a3de-3c7ed15515d5") },
                    { new Guid("e70af9fb-3fe7-430e-a959-2c201383e83a"), new Guid("fdeb520b-93db-492b-a152-19a5a9c29227") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoriesSubCategories_SubCategoryId",
                table: "CategoriesSubCategories",
                column: "SubCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_ArtStyles_ArtStyleId",
                table: "Assets",
                column: "ArtStyleId",
                principalTable: "ArtStyles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetsCategories_Assets_UserId",
                table: "AssetsCategories",
                column: "UserId",
                principalTable: "Assets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetsCategories_GeneralCategories_CategoryId",
                table: "AssetsCategories",
                column: "CategoryId",
                principalTable: "GeneralCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetsSubCategories_Assets_AssetId",
                table: "AssetsSubCategories",
                column: "AssetId",
                principalTable: "Assets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetsSubCategories_SubCategories_SubCategoryId",
                table: "AssetsSubCategories",
                column: "SubCategoryId",
                principalTable: "SubCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersAssets_AspNetUsers_UserId",
                table: "UsersAssets",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersAssets_Assets_AssetId",
                table: "UsersAssets",
                column: "AssetId",
                principalTable: "Assets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assets_ArtStyles_ArtStyleId",
                table: "Assets");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetsCategories_Assets_UserId",
                table: "AssetsCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetsCategories_GeneralCategories_CategoryId",
                table: "AssetsCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetsSubCategories_Assets_AssetId",
                table: "AssetsSubCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_AssetsSubCategories_SubCategories_SubCategoryId",
                table: "AssetsSubCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersAssets_AspNetUsers_UserId",
                table: "UsersAssets");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersAssets_Assets_AssetId",
                table: "UsersAssets");

            migrationBuilder.DropTable(
                name: "CategoriesSubCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubCategories",
                table: "SubCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GeneralCategories",
                table: "GeneralCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArtStyles",
                table: "ArtStyles");

            migrationBuilder.DeleteData(
                table: "ArtStyles",
                keyColumn: "Id",
                keyValue: new Guid("4140686f-0b64-4e75-b41d-5daecf21f738"));

            migrationBuilder.DeleteData(
                table: "ArtStyles",
                keyColumn: "Id",
                keyValue: new Guid("6422d0a4-b0df-475c-8350-7390b43d060a"));

            migrationBuilder.DeleteData(
                table: "ArtStyles",
                keyColumn: "Id",
                keyValue: new Guid("b643c6bc-95a2-4d41-9cca-0469d96d6993"));

            migrationBuilder.DeleteData(
                table: "ArtStyles",
                keyColumn: "Id",
                keyValue: new Guid("be91442d-0a38-4b4b-b13c-afb1809bc2ee"));

            migrationBuilder.DeleteData(
                table: "ArtStyles",
                keyColumn: "Id",
                keyValue: new Guid("c0752cd6-b3cf-4740-802b-9a0a8ae4c544"));

            migrationBuilder.DeleteData(
                table: "ArtStyles",
                keyColumn: "Id",
                keyValue: new Guid("c5803ccd-ab07-45a0-838f-6aa239277d7b"));

            migrationBuilder.DeleteData(
                table: "ArtStyles",
                keyColumn: "Id",
                keyValue: new Guid("dc45848f-0e07-4b14-af74-898767ee30d8"));

            migrationBuilder.DeleteData(
                table: "ArtStyles",
                keyColumn: "Id",
                keyValue: new Guid("e5739d08-a73a-4dbb-b75d-2c7a2f9e6749"));

            migrationBuilder.DeleteData(
                table: "GeneralCategories",
                keyColumn: "Id",
                keyValue: new Guid("14b122d0-90bf-45aa-8b92-e02cd29784d3"));

            migrationBuilder.DeleteData(
                table: "GeneralCategories",
                keyColumn: "Id",
                keyValue: new Guid("1e746e77-4e0a-4c04-aba2-1a347767ad3a"));

            migrationBuilder.DeleteData(
                table: "GeneralCategories",
                keyColumn: "Id",
                keyValue: new Guid("510af335-4b59-49fe-8022-141f5cc410d4"));

            migrationBuilder.DeleteData(
                table: "GeneralCategories",
                keyColumn: "Id",
                keyValue: new Guid("59a1562a-6e96-4d82-b025-a28cb59c7e0c"));

            migrationBuilder.DeleteData(
                table: "GeneralCategories",
                keyColumn: "Id",
                keyValue: new Guid("5ed5f1c8-98c6-48e0-b479-51a81d3036d9"));

            migrationBuilder.DeleteData(
                table: "GeneralCategories",
                keyColumn: "Id",
                keyValue: new Guid("a27bb29f-b235-40d4-bb11-ea4318afd3c6"));

            migrationBuilder.DeleteData(
                table: "GeneralCategories",
                keyColumn: "Id",
                keyValue: new Guid("c98b256b-dc33-4680-a53e-084c0111844b"));

            migrationBuilder.DeleteData(
                table: "GeneralCategories",
                keyColumn: "Id",
                keyValue: new Guid("e70af9fb-3fe7-430e-a959-2c201383e83a"));

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: new Guid("0cb36015-ffd6-4836-a0f3-2f8bc803a75e"));

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: new Guid("1359383e-3a4e-408d-91fb-aa9b9425df6f"));

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: new Guid("2681e9d1-344b-4d58-8916-2c8732465d0a"));

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: new Guid("2f53ee6b-277e-4b76-810d-15414fe7b32b"));

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: new Guid("465da332-d175-4ea7-9452-eddc8d6fe7e5"));

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: new Guid("4e42eba0-be74-4b1b-968d-9c104a417c10"));

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: new Guid("5dcda147-b9e1-4881-adc9-c9ed4837c8cf"));

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: new Guid("8359654e-6e96-4254-999b-51b0ad1c9e1f"));

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: new Guid("89132449-6f33-4a1a-a8a0-24a72e99fab7"));

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: new Guid("a1ae6147-9ed9-4243-8c9c-90d9a2549536"));

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: new Guid("a9203c28-f272-4c4c-92b8-0d75352a31cb"));

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: new Guid("abf6b357-436f-43cc-8eb9-7b4cb7a333dd"));

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: new Guid("c78774c6-65c5-4d77-ab68-d9b27aef707d"));

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: new Guid("ccb576a8-1774-4fb3-81f6-b1ba285da1f3"));

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: new Guid("d38b77d4-2ba2-404e-bc9c-ee5a55925176"));

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: new Guid("d8ac59b9-c97a-47db-a3de-3c7ed15515d5"));

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: new Guid("db6a3733-625e-4ad2-bdf5-32337a91df12"));

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: new Guid("eeb4556f-1b3e-4b25-81ef-8f2c1cc11498"));

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: new Guid("f5668d1f-6250-4da1-87d9-fe144189d1fd"));

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: new Guid("fdeb520b-93db-492b-a152-19a5a9c29227"));

            migrationBuilder.RenameTable(
                name: "SubCategories",
                newName: "Sub Category");

            migrationBuilder.RenameTable(
                name: "GeneralCategories",
                newName: "General Category");

            migrationBuilder.RenameTable(
                name: "ArtStyles",
                newName: "Art Style");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UsersAssets",
                newName: "UsersId");

            migrationBuilder.RenameColumn(
                name: "AssetId",
                table: "UsersAssets",
                newName: "PurchasedAssetsId");

            migrationBuilder.RenameIndex(
                name: "IX_UsersAssets_UserId",
                table: "UsersAssets",
                newName: "IX_UsersAssets_UsersId");

            migrationBuilder.RenameColumn(
                name: "SubCategoryId",
                table: "AssetsSubCategories",
                newName: "SubCategoriesId");

            migrationBuilder.RenameColumn(
                name: "AssetId",
                table: "AssetsSubCategories",
                newName: "AssetsId");

            migrationBuilder.RenameIndex(
                name: "IX_AssetsSubCategories_SubCategoryId",
                table: "AssetsSubCategories",
                newName: "IX_AssetsSubCategories_SubCategoriesId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "AssetsCategories",
                newName: "GeneralCategoriesId");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "AssetsCategories",
                newName: "AssetsId");

            migrationBuilder.RenameIndex(
                name: "IX_AssetsCategories_UserId",
                table: "AssetsCategories",
                newName: "IX_AssetsCategories_GeneralCategoriesId");

            migrationBuilder.AlterColumn<string>(
                name: "FileName",
                table: "Assets",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                comment: "Encoded name of the user uploaded asset file.",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldComment: "Encoded name of the user uploaded asset file.");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "Sub Category",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sub Category",
                table: "Sub Category",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_General Category",
                table: "General Category",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Art Style",
                table: "Art Style",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Sub Category_CategoryId",
                table: "Sub Category",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_Art Style_ArtStyleId",
                table: "Assets",
                column: "ArtStyleId",
                principalTable: "Art Style",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetsCategories_Assets_AssetsId",
                table: "AssetsCategories",
                column: "AssetsId",
                principalTable: "Assets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetsCategories_General Category_GeneralCategoriesId",
                table: "AssetsCategories",
                column: "GeneralCategoriesId",
                principalTable: "General Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetsSubCategories_Assets_AssetsId",
                table: "AssetsSubCategories",
                column: "AssetsId",
                principalTable: "Assets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AssetsSubCategories_Sub Category_SubCategoriesId",
                table: "AssetsSubCategories",
                column: "SubCategoriesId",
                principalTable: "Sub Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sub Category_General Category_CategoryId",
                table: "Sub Category",
                column: "CategoryId",
                principalTable: "General Category",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersAssets_AspNetUsers_UsersId",
                table: "UsersAssets",
                column: "UsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersAssets_Assets_PurchasedAssetsId",
                table: "UsersAssets",
                column: "PurchasedAssetsId",
                principalTable: "Assets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
