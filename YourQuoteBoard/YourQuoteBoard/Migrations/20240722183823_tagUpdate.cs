using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace YourQuoteBoard.Migrations
{
    /// <inheritdoc />
    public partial class tagUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookTags");

            migrationBuilder.DropTable(
                name: "QuoteTags");

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    TagId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    IsDefault = table.Column<bool>(type: "INTEGER", nullable: false),
                    Discriminator = table.Column<int>(type: "INTEGER", nullable: false),
                    BookId = table.Column<Guid>(type: "TEXT", nullable: true),
                    QuoteId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.TagId);
                    table.ForeignKey(
                        name: "FK_Tags_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId");
                    table.ForeignKey(
                        name: "FK_Tags_Quotes_QuoteId",
                        column: x => x.QuoteId,
                        principalTable: "Quotes",
                        principalColumn: "QuoteId");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Tags_QuoteId",
                table: "Tags",
                column: "QuoteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.CreateTable(
                name: "BookTags",
                columns: table => new
                {
                    BookTagId = table.Column<Guid>(type: "TEXT", nullable: false),
                    BookId = table.Column<Guid>(type: "TEXT", nullable: true),
                    IsDefault = table.Column<bool>(type: "INTEGER", nullable: false),
                    Tag = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookTags", x => x.BookTagId);
                    table.ForeignKey(
                        name: "FK_BookTags_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId");
                });

            migrationBuilder.CreateTable(
                name: "QuoteTags",
                columns: table => new
                {
                    QuoteTagId = table.Column<Guid>(type: "TEXT", nullable: false),
                    IsDefault = table.Column<bool>(type: "INTEGER", nullable: false),
                    QuoteId = table.Column<Guid>(type: "TEXT", nullable: true),
                    Tag = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuoteTags", x => x.QuoteTagId);
                    table.ForeignKey(
                        name: "FK_QuoteTags_Quotes_QuoteId",
                        column: x => x.QuoteId,
                        principalTable: "Quotes",
                        principalColumn: "QuoteId");
                });

            migrationBuilder.InsertData(
                table: "BookTags",
                columns: new[] { "BookTagId", "BookId", "IsDefault", "Tag" },
                values: new object[,]
                {
                    { new Guid("120b2f01-33e3-4548-bbc2-4ae2d1badd31"), null, true, "Novel" },
                    { new Guid("47d799f4-f5ef-404e-ba71-63f26244b3ac"), null, true, "Fiction" },
                    { new Guid("765e4444-62b1-486f-8aa0-dead824d4fa0"), null, true, "Biography" },
                    { new Guid("7b23bbab-2adb-4ed7-bd03-243f36239684"), null, true, "Romantic" },
                    { new Guid("bbc58bcd-0340-40de-a17e-f882e27b7472"), null, true, "Non_Fiction" },
                    { new Guid("ce997cea-c3d7-4c3b-a1bc-17fd56a8f14a"), null, true, "Autobiography" },
                    { new Guid("f2275b14-386b-4092-b15e-0426596f5b4e"), null, true, "Comedy" }
                });

            migrationBuilder.InsertData(
                table: "QuoteTags",
                columns: new[] { "QuoteTagId", "IsDefault", "QuoteId", "Tag" },
                values: new object[,]
                {
                    { new Guid("1da732f2-ebc6-4fad-be08-f3fb5b95649e"), true, null, "Inspirational" },
                    { new Guid("2388b233-1bf5-4c69-817a-83eca10cfbff"), true, null, "Informative" },
                    { new Guid("428ef8fc-cb20-4eb5-b936-bfc41040b909"), true, null, "Emotional" },
                    { new Guid("594986f8-ca34-477f-b478-8844581543f1"), true, null, "Funny" },
                    { new Guid("59a96010-bbb5-49ca-bc54-479937178c46"), true, null, "Sad" },
                    { new Guid("c1b51404-567a-415e-9126-e9f7d396f8ce"), true, null, "Literary" },
                    { new Guid("efc9c9d5-9f96-4ce2-9e1c-734f1106abd0"), true, null, "Philosophical" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookTags_BookId",
                table: "BookTags",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_QuoteTags_QuoteId",
                table: "QuoteTags",
                column: "QuoteId");
        }
    }
}
