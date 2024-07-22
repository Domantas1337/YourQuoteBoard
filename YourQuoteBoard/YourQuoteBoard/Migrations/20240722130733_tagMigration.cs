using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace YourQuoteBoard.Migrations
{
    /// <inheritdoc />
    public partial class tagMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookTags",
                columns: table => new
                {
                    BookTagId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Tag = table.Column<string>(type: "TEXT", nullable: false),
                    IsDefault = table.Column<bool>(type: "INTEGER", nullable: false),
                    BookId = table.Column<Guid>(type: "TEXT", nullable: true)
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
                    Tag = table.Column<string>(type: "TEXT", nullable: false),
                    IsDefault = table.Column<bool>(type: "INTEGER", nullable: false),
                    QuoteId = table.Column<Guid>(type: "TEXT", nullable: true)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookTags");

            migrationBuilder.DropTable(
                name: "QuoteTags");
        }
    }
}
