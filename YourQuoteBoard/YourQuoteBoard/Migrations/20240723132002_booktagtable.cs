using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace YourQuoteBoard.Migrations
{
    /// <inheritdoc />
    public partial class booktagtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                keyValue: new Guid("16a4ef36-264a-4d76-ba8f-3c5671ee7fbf"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("1d608112-76e4-4168-813e-38bcfbc2a650"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("23e74940-adae-4d85-bbcb-c87a69b7982f"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("53ed4b87-6810-491f-a3ec-53903f699dbd"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("579215d2-a5d0-432e-ade7-432d75f6388e"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("5cc550d2-a6c8-4bbf-a877-8733056810ff"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("6f47f21a-8cee-4d5b-9c91-6fef93f02cfd"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("70fd0042-d889-40f5-b7ca-69f930dab42c"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("72f0e7ad-d19e-490c-928a-4430ae0f3c85"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("c45200ed-e850-4262-a24e-b02b651a1198"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("c788a15c-616e-4f2f-bd83-b3283a8cfaf5"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("cfef7afd-bc3e-4c22-99e2-ece541e5c692"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("e1ea9a28-514d-404d-99db-9ed7e8acab6a"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("eae0e5a0-64d6-49dc-94a7-be1588422156"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { new Guid("16a4ef36-264a-4d76-ba8f-3c5671ee7fbf"), null, 1, true, "Biography", null },
                    { new Guid("1d608112-76e4-4168-813e-38bcfbc2a650"), null, 1, true, "Autobiography", null },
                    { new Guid("23e74940-adae-4d85-bbcb-c87a69b7982f"), null, 1, true, "Romantic", null },
                    { new Guid("53ed4b87-6810-491f-a3ec-53903f699dbd"), null, 0, true, "Informative", null },
                    { new Guid("579215d2-a5d0-432e-ade7-432d75f6388e"), null, 1, true, "Novel", null },
                    { new Guid("5cc550d2-a6c8-4bbf-a877-8733056810ff"), null, 0, true, "Inspirational", null },
                    { new Guid("6f47f21a-8cee-4d5b-9c91-6fef93f02cfd"), null, 0, true, "Emotional", null },
                    { new Guid("70fd0042-d889-40f5-b7ca-69f930dab42c"), null, 0, true, "Philosophical", null },
                    { new Guid("72f0e7ad-d19e-490c-928a-4430ae0f3c85"), null, 1, true, "Comedy", null },
                    { new Guid("c45200ed-e850-4262-a24e-b02b651a1198"), null, 1, true, "Non_Fiction", null },
                    { new Guid("c788a15c-616e-4f2f-bd83-b3283a8cfaf5"), null, 0, true, "Sad", null },
                    { new Guid("cfef7afd-bc3e-4c22-99e2-ece541e5c692"), null, 1, true, "Fiction", null },
                    { new Guid("e1ea9a28-514d-404d-99db-9ed7e8acab6a"), null, 0, true, "Literary", null },
                    { new Guid("eae0e5a0-64d6-49dc-94a7-be1588422156"), null, 0, true, "Funny", null }
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
    }
}
