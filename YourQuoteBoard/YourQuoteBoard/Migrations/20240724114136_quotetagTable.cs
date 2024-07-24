using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace YourQuoteBoard.Migrations
{
    /// <inheritdoc />
    public partial class quotetagTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Quotes_QuoteId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_QuoteId",
                table: "Tags");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("0241fa77-214c-44a8-abfe-8484ee7b849b"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("02710de8-8ad6-4ffa-a167-05797812b904"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("2ea85663-d107-4cde-82e2-635271f562a7"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("3888ad5d-d489-4403-b2df-9b3b068c8551"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("3c0806f4-d592-489d-8490-19a20087985f"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("403bce12-b3ca-4745-bcb8-08e38e411b0f"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("43a4a27d-3373-43ef-8d04-853d7e018c09"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("767c6d3b-5b1a-4bd5-a953-aeaa7c0a942c"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("a1fcb497-4e23-4706-9c6b-0f3b68caf786"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("a4b9965b-7cc4-478e-ac28-936b548fb9f8"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("a882983b-70aa-497f-b3ad-5a819344b363"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("b4a6b78b-f19a-4294-8a1f-01d136e72031"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("bca4ca01-34fc-416b-be7d-5e90a6383730"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("ed5e0db3-3b6c-4e45-af44-530332949736"));

            migrationBuilder.DropColumn(
                name: "QuoteId",
                table: "Tags");

            migrationBuilder.CreateTable(
                name: "QuoteTag",
                columns: table => new
                {
                    QuoteId = table.Column<Guid>(type: "TEXT", nullable: false),
                    TagsTagId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuoteTag", x => new { x.QuoteId, x.TagsTagId });
                    table.ForeignKey(
                        name: "FK_QuoteTag_Quotes_QuoteId",
                        column: x => x.QuoteId,
                        principalTable: "Quotes",
                        principalColumn: "QuoteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuoteTag_Tags_TagsTagId",
                        column: x => x.TagsTagId,
                        principalTable: "Tags",
                        principalColumn: "TagId",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_QuoteTag_TagsTagId",
                table: "QuoteTag",
                column: "TagsTagId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuoteTag");

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

            migrationBuilder.AddColumn<Guid>(
                name: "QuoteId",
                table: "Tags",
                type: "TEXT",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "TagId", "Discriminator", "IsDefault", "Name", "QuoteId" },
                values: new object[,]
                {
                    { new Guid("0241fa77-214c-44a8-abfe-8484ee7b849b"), 0, true, "Informative", null },
                    { new Guid("02710de8-8ad6-4ffa-a167-05797812b904"), 1, true, "Non_Fiction", null },
                    { new Guid("2ea85663-d107-4cde-82e2-635271f562a7"), 0, true, "Sad", null },
                    { new Guid("3888ad5d-d489-4403-b2df-9b3b068c8551"), 0, true, "Literary", null },
                    { new Guid("3c0806f4-d592-489d-8490-19a20087985f"), 1, true, "Novel", null },
                    { new Guid("403bce12-b3ca-4745-bcb8-08e38e411b0f"), 0, true, "Inspirational", null },
                    { new Guid("43a4a27d-3373-43ef-8d04-853d7e018c09"), 0, true, "Emotional", null },
                    { new Guid("767c6d3b-5b1a-4bd5-a953-aeaa7c0a942c"), 1, true, "Romantic", null },
                    { new Guid("a1fcb497-4e23-4706-9c6b-0f3b68caf786"), 1, true, "Comedy", null },
                    { new Guid("a4b9965b-7cc4-478e-ac28-936b548fb9f8"), 0, true, "Philosophical", null },
                    { new Guid("a882983b-70aa-497f-b3ad-5a819344b363"), 1, true, "Autobiography", null },
                    { new Guid("b4a6b78b-f19a-4294-8a1f-01d136e72031"), 1, true, "Fiction", null },
                    { new Guid("bca4ca01-34fc-416b-be7d-5e90a6383730"), 0, true, "Funny", null },
                    { new Guid("ed5e0db3-3b6c-4e45-af44-530332949736"), 1, true, "Biography", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tags_QuoteId",
                table: "Tags",
                column: "QuoteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Quotes_QuoteId",
                table: "Tags",
                column: "QuoteId",
                principalTable: "Quotes",
                principalColumn: "QuoteId");
        }
    }
}
