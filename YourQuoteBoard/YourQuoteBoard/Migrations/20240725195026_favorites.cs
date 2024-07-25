using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace YourQuoteBoard.Migrations
{
    /// <inheritdoc />
    public partial class favorites : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("01943c18-3355-4ac1-86d1-a4e89b3a44ad"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("083429ba-3101-41af-8fc4-001492bde4a8"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("1882e152-822b-4fc0-8a3e-9b8d9150f9d1"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("1ecd8b4b-7248-41aa-8f40-5e776168a13c"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("2e23f13f-d9f5-4938-a1e6-dcfa07bed2ee"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("35799033-15c4-4990-a909-6304fbc2683c"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("453d001e-bc93-4508-8844-d6d3698f008d"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("541be059-3c00-46f4-9c59-0cda28c7ffeb"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("965064d8-8439-4e4e-b529-b96fb8c2f887"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("bb6d8f8c-d53d-4db5-b288-2163578517e2"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("d05094a2-9ac0-41f6-bd85-d162d2b52dcc"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("e75db146-c87b-42ba-a1d0-8280aa7907af"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("fcbf6907-12b7-4d19-a2d3-691090557a40"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("ff273830-5bae-4a1d-ad8c-ee89af053a70"));

            migrationBuilder.CreateTable(
                name: "Favorites",
                columns: table => new
                {
                    FavoriteId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "TEXT", nullable: false),
                    QuoteId = table.Column<Guid>(type: "TEXT", nullable: false),
                    TimeAdded = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorites", x => x.FavoriteId);
                    table.ForeignKey(
                        name: "FK_Favorites_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Favorites_Quotes_QuoteId",
                        column: x => x.QuoteId,
                        principalTable: "Quotes",
                        principalColumn: "QuoteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "TagId", "Discriminator", "IsDefault", "Name" },
                values: new object[,]
                {
                    { new Guid("0b3141db-f2d0-4b00-b503-778d657ebff9"), 1, true, "Romantic" },
                    { new Guid("0d674a4b-49a7-4c0b-96e7-e7bf5413d2b0"), 0, true, "Inspirational" },
                    { new Guid("1f73aea4-c285-4bc1-a6b9-5598ed711eed"), 1, true, "Autobiography" },
                    { new Guid("403935a2-5de1-4746-8069-0299b879626d"), 0, true, "Sad" },
                    { new Guid("678d270d-2c89-46cd-86d6-6b9d7ffac6f2"), 0, true, "Literary" },
                    { new Guid("8433df0c-42a4-42af-9636-af2fd8befa7f"), 1, true, "Biography" },
                    { new Guid("866a5a7b-2c4b-4288-b4c5-28bf1e549e85"), 1, true, "Non_Fiction" },
                    { new Guid("87b776b6-1898-4fd4-a189-8dea3fb2e556"), 1, true, "Fiction" },
                    { new Guid("a2a62cbe-642c-4925-9547-57d3d1ae1a36"), 1, true, "Comedy" },
                    { new Guid("a880914c-4f7b-44ff-a5fe-3a4119c16968"), 0, true, "Philosophical" },
                    { new Guid("aa1067dc-5728-4bf2-97d2-ed5cc3eec9e9"), 1, true, "Novel" },
                    { new Guid("bdb73fad-f09b-4ccf-96df-d0c5e189f406"), 0, true, "Funny" },
                    { new Guid("d0a1cf93-3714-47b1-a56a-a5a15857fc3e"), 0, true, "Informative" },
                    { new Guid("f05d5d2d-8e38-4114-85ab-f5f548e38009"), 0, true, "Emotional" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_ApplicationUserId",
                table: "Favorites",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_QuoteId",
                table: "Favorites",
                column: "QuoteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Favorites");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("0b3141db-f2d0-4b00-b503-778d657ebff9"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("0d674a4b-49a7-4c0b-96e7-e7bf5413d2b0"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("1f73aea4-c285-4bc1-a6b9-5598ed711eed"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("403935a2-5de1-4746-8069-0299b879626d"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("678d270d-2c89-46cd-86d6-6b9d7ffac6f2"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("8433df0c-42a4-42af-9636-af2fd8befa7f"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("866a5a7b-2c4b-4288-b4c5-28bf1e549e85"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("87b776b6-1898-4fd4-a189-8dea3fb2e556"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("a2a62cbe-642c-4925-9547-57d3d1ae1a36"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("a880914c-4f7b-44ff-a5fe-3a4119c16968"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("aa1067dc-5728-4bf2-97d2-ed5cc3eec9e9"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("bdb73fad-f09b-4ccf-96df-d0c5e189f406"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("d0a1cf93-3714-47b1-a56a-a5a15857fc3e"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("f05d5d2d-8e38-4114-85ab-f5f548e38009"));

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "TagId", "Discriminator", "IsDefault", "Name" },
                values: new object[,]
                {
                    { new Guid("01943c18-3355-4ac1-86d1-a4e89b3a44ad"), 1, true, "Non_Fiction" },
                    { new Guid("083429ba-3101-41af-8fc4-001492bde4a8"), 0, true, "Emotional" },
                    { new Guid("1882e152-822b-4fc0-8a3e-9b8d9150f9d1"), 0, true, "Philosophical" },
                    { new Guid("1ecd8b4b-7248-41aa-8f40-5e776168a13c"), 0, true, "Informative" },
                    { new Guid("2e23f13f-d9f5-4938-a1e6-dcfa07bed2ee"), 0, true, "Sad" },
                    { new Guid("35799033-15c4-4990-a909-6304fbc2683c"), 0, true, "Literary" },
                    { new Guid("453d001e-bc93-4508-8844-d6d3698f008d"), 1, true, "Autobiography" },
                    { new Guid("541be059-3c00-46f4-9c59-0cda28c7ffeb"), 1, true, "Biography" },
                    { new Guid("965064d8-8439-4e4e-b529-b96fb8c2f887"), 0, true, "Inspirational" },
                    { new Guid("bb6d8f8c-d53d-4db5-b288-2163578517e2"), 1, true, "Comedy" },
                    { new Guid("d05094a2-9ac0-41f6-bd85-d162d2b52dcc"), 1, true, "Romantic" },
                    { new Guid("e75db146-c87b-42ba-a1d0-8280aa7907af"), 1, true, "Fiction" },
                    { new Guid("fcbf6907-12b7-4d19-a2d3-691090557a40"), 0, true, "Funny" },
                    { new Guid("ff273830-5bae-4a1d-ad8c-ee89af053a70"), 1, true, "Novel" }
                });
        }
    }
}
