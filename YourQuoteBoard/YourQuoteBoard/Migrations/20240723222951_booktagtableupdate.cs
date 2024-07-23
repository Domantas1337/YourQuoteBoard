using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace YourQuoteBoard.Migrations
{
    /// <inheritdoc />
    public partial class booktagtableupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookTags");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("05a8fad7-c372-4781-b717-1cda4194e77d"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("2852429f-a67d-4917-a960-71d9b10093df"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("2a5bd8f0-c4e3-4cfa-8772-4924d6ceb0fb"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("3773ac71-dff3-4685-9e2e-2f694601e698"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("497cfed3-af94-4581-a88d-7ada13dfe2d3"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("52d44b8c-a0ca-4ab2-88f6-b137d59240cf"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("5902fff9-1a6c-4adf-8479-2c3dbb99aaf7"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("59c806c0-bc5b-4eeb-bb27-143502fb3660"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("62f8cbbc-bd28-4a23-9baa-5c5e44500598"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("8754285f-3ff0-4db9-a5a2-17710ffa0e6b"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("9a0147c5-fd78-4980-97ab-8a6014da57d7"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("9c6d1b83-7e9e-4123-829f-cc352c82a3c7"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("b5888ed1-1d1c-4588-b9b4-50dcfe53abed"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("b801714e-d576-4b25-953b-9a3ac4a749bd"));

            migrationBuilder.AddColumn<Guid>(
                name: "BookId",
                table: "Tags",
                type: "TEXT",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "TagId", "BookId", "Discriminator", "IsDefault", "Name", "QuoteId" },
                values: new object[,]
                {
                    { new Guid("06d64c8e-b9eb-43af-b4c7-dc785aebd552"), null, 1, true, "Novel", null },
                    { new Guid("2a95af04-827c-4909-b8bb-a6f45ceaebd8"), null, 0, true, "Literary", null },
                    { new Guid("39859e0e-da9e-45f2-b28e-da3b1f0effb3"), null, 0, true, "Inspirational", null },
                    { new Guid("43b48783-e221-4bf3-a73b-6017f2d04f36"), null, 0, true, "Sad", null },
                    { new Guid("51fc6b5a-038f-49ff-9ba5-e21cc4783803"), null, 1, true, "Romantic", null },
                    { new Guid("5de8522b-b7ce-418b-959f-6bb1c04ef14c"), null, 1, true, "Comedy", null },
                    { new Guid("6dcec3e1-49c8-4b37-8ad8-ea0cd0a6b860"), null, 1, true, "Autobiography", null },
                    { new Guid("89e8dfb2-33b4-44aa-b030-25f3737d368b"), null, 0, true, "Emotional", null },
                    { new Guid("9498c845-946c-44c2-9a94-aaf3e49c6ba4"), null, 1, true, "Non_Fiction", null },
                    { new Guid("ce86fb41-6b32-41c8-8ab4-8e0cacc4d366"), null, 0, true, "Informative", null },
                    { new Guid("e6d09777-7e3f-48ec-b488-fb78cf7e2041"), null, 0, true, "Funny", null },
                    { new Guid("e8fd41bf-4190-478e-8b62-c93880305eac"), null, 0, true, "Philosophical", null },
                    { new Guid("ed8bc374-79e5-426c-88bf-1f4ea5404289"), null, 1, true, "Biography", null },
                    { new Guid("fdb9164f-57c5-4fc4-b4d2-b09d56052490"), null, 1, true, "Fiction", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tags_BookId",
                table: "Tags",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Books_BookId",
                table: "Tags",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "BookId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Books_BookId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_BookId",
                table: "Tags");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("06d64c8e-b9eb-43af-b4c7-dc785aebd552"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("2a95af04-827c-4909-b8bb-a6f45ceaebd8"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("39859e0e-da9e-45f2-b28e-da3b1f0effb3"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("43b48783-e221-4bf3-a73b-6017f2d04f36"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("51fc6b5a-038f-49ff-9ba5-e21cc4783803"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("5de8522b-b7ce-418b-959f-6bb1c04ef14c"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("6dcec3e1-49c8-4b37-8ad8-ea0cd0a6b860"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("89e8dfb2-33b4-44aa-b030-25f3737d368b"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("9498c845-946c-44c2-9a94-aaf3e49c6ba4"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("ce86fb41-6b32-41c8-8ab4-8e0cacc4d366"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("e6d09777-7e3f-48ec-b488-fb78cf7e2041"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("e8fd41bf-4190-478e-8b62-c93880305eac"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("ed8bc374-79e5-426c-88bf-1f4ea5404289"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("fdb9164f-57c5-4fc4-b4d2-b09d56052490"));

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "Tags");

            migrationBuilder.CreateTable(
                name: "BookTags",
                columns: table => new
                {
                    BookId = table.Column<Guid>(type: "TEXT", nullable: false),
                    TagId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookTags", x => new { x.BookId, x.TagId });
                    table.ForeignKey(
                        name: "FK_BookTags_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "TagId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "TagId", "Discriminator", "IsDefault", "Name", "QuoteId" },
                values: new object[,]
                {
                    { new Guid("05a8fad7-c372-4781-b717-1cda4194e77d"), 1, true, "Non_Fiction", null },
                    { new Guid("2852429f-a67d-4917-a960-71d9b10093df"), 1, true, "Autobiography", null },
                    { new Guid("2a5bd8f0-c4e3-4cfa-8772-4924d6ceb0fb"), 0, true, "Inspirational", null },
                    { new Guid("3773ac71-dff3-4685-9e2e-2f694601e698"), 0, true, "Funny", null },
                    { new Guid("497cfed3-af94-4581-a88d-7ada13dfe2d3"), 1, true, "Romantic", null },
                    { new Guid("52d44b8c-a0ca-4ab2-88f6-b137d59240cf"), 0, true, "Philosophical", null },
                    { new Guid("5902fff9-1a6c-4adf-8479-2c3dbb99aaf7"), 1, true, "Biography", null },
                    { new Guid("59c806c0-bc5b-4eeb-bb27-143502fb3660"), 1, true, "Novel", null },
                    { new Guid("62f8cbbc-bd28-4a23-9baa-5c5e44500598"), 0, true, "Emotional", null },
                    { new Guid("8754285f-3ff0-4db9-a5a2-17710ffa0e6b"), 0, true, "Sad", null },
                    { new Guid("9a0147c5-fd78-4980-97ab-8a6014da57d7"), 1, true, "Fiction", null },
                    { new Guid("9c6d1b83-7e9e-4123-829f-cc352c82a3c7"), 1, true, "Comedy", null },
                    { new Guid("b5888ed1-1d1c-4588-b9b4-50dcfe53abed"), 0, true, "Informative", null },
                    { new Guid("b801714e-d576-4b25-953b-9a3ac4a749bd"), 0, true, "Literary", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookTags_TagId",
                table: "BookTags",
                column: "TagId");
        }
    }
}
