using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace YourQuoteBoard.Migrations
{
    /// <inheritdoc />
    public partial class BookRatingMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RatingSummary");

            migrationBuilder.DropTable(
                name: "SpecificRatings");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("0260c837-6e5d-4891-ac02-ce92319d90c2"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("0a8abcc5-000b-4d5e-b3cb-af367821eaab"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("1a73e52a-9cd1-42d3-b96f-12f3aa378408"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("2ba83977-f4df-4a00-9a34-280703e73592"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("44546ec7-cc78-4af4-ac44-61b12d133d99"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("4c715ab4-9aed-42e1-be38-17996f0edfa3"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("a753d54c-3a0a-444a-9951-4c0bdbd504b2"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("aed35497-76f1-4abb-9827-ec3901b6bb2d"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("bea8adc8-3e57-44a5-aba7-7e6f1ce88f83"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("c31b96aa-63c0-4a8e-8adb-30f92ed62096"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("dd5ff169-27fe-4d97-b045-532f9fca64d0"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("eea9f259-c971-479c-856a-38734c5e4a4d"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("f02562b5-730b-4052-b19d-69d4f1924113"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("f4187471-f87f-4545-b6f1-8a378993d706"));

            migrationBuilder.DropColumn(
                name: "AverageRating",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "NumberOfRatings",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "AccuracyRating",
                table: "BookRatings");

            migrationBuilder.DropColumn(
                name: "CharacterDevelopmentRating",
                table: "BookRatings");

            migrationBuilder.DropColumn(
                name: "PlotRating",
                table: "BookRatings");

            migrationBuilder.DropColumn(
                name: "WorldBuildingRating",
                table: "BookRatings");

            migrationBuilder.DropColumn(
                name: "WritingStyleRating",
                table: "BookRatings");

            migrationBuilder.AddColumn<double>(
                name: "AverageOverallRating",
                table: "Books",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfOverallRatings",
                table: "Books",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BookRatingSummaries",
                columns: table => new
                {
                    BookRatingSummaryId = table.Column<Guid>(type: "TEXT", nullable: false),
                    RatingCategory = table.Column<int>(type: "INTEGER", nullable: false),
                    AverageRating = table.Column<double>(type: "REAL", nullable: false),
                    NumberOfRatings = table.Column<int>(type: "INTEGER", nullable: false),
                    BookId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookRatingSummaries", x => x.BookRatingSummaryId);
                    table.ForeignKey(
                        name: "FK_BookRatingSummaries_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookSpecificRatings",
                columns: table => new
                {
                    BookSpecificRatingId = table.Column<Guid>(type: "TEXT", nullable: false),
                    RatingCategory = table.Column<int>(type: "INTEGER", nullable: false),
                    Rating = table.Column<double>(type: "REAL", nullable: true),
                    BookRatingId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookSpecificRatings", x => x.BookSpecificRatingId);
                    table.ForeignKey(
                        name: "FK_BookSpecificRatings_BookRatings_BookRatingId",
                        column: x => x.BookRatingId,
                        principalTable: "BookRatings",
                        principalColumn: "BookRatingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuoteRatingSummaries",
                columns: table => new
                {
                    QuoteRatingSummaryId = table.Column<Guid>(type: "TEXT", nullable: false),
                    RatingCategory = table.Column<int>(type: "INTEGER", nullable: false),
                    AverageRating = table.Column<double>(type: "REAL", nullable: false),
                    NumberOfRatings = table.Column<int>(type: "INTEGER", nullable: false),
                    QuoteId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuoteRatingSummaries", x => x.QuoteRatingSummaryId);
                    table.ForeignKey(
                        name: "FK_QuoteRatingSummaries_Quotes_QuoteId",
                        column: x => x.QuoteId,
                        principalTable: "Quotes",
                        principalColumn: "QuoteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuoteSpecificRatings",
                columns: table => new
                {
                    QuoteSpecificRatingId = table.Column<Guid>(type: "TEXT", nullable: false),
                    RatingCategory = table.Column<int>(type: "INTEGER", nullable: false),
                    Rating = table.Column<double>(type: "REAL", nullable: true),
                    QuoteRatingId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuoteSpecificRatings", x => x.QuoteSpecificRatingId);
                    table.ForeignKey(
                        name: "FK_QuoteSpecificRatings_QuoteRatings_QuoteRatingId",
                        column: x => x.QuoteRatingId,
                        principalTable: "QuoteRatings",
                        principalColumn: "QuoteRatingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "TagId", "Discriminator", "IsDefault", "Name" },
                values: new object[,]
                {
                    { new Guid("04e0a766-8b37-4eec-8bf6-3fcd24ae67b4"), 0, true, "Funny" },
                    { new Guid("0711ef55-bfde-4f6e-8f55-afc14e306806"), 1, true, "Comedy" },
                    { new Guid("0b1b930e-3812-4e78-882e-3223db35622d"), 0, true, "Literary" },
                    { new Guid("209f7d62-2b2a-4e73-a476-291d793fd44d"), 0, true, "Philosophical" },
                    { new Guid("317dbb97-322c-4558-b3df-9fa645d491d7"), 1, true, "Autobiography" },
                    { new Guid("513e39f8-2785-4efb-92bd-5e8ad0268d01"), 1, true, "Novel" },
                    { new Guid("51f8c642-92f1-428a-bba9-2a3e9822e3c9"), 1, true, "Romantic" },
                    { new Guid("5993e16c-f75a-414c-852c-73de49ba5ef4"), 0, true, "Sad" },
                    { new Guid("8f801b50-959d-4030-94fa-b16aa1f0f235"), 0, true, "Emotional" },
                    { new Guid("93436277-e29b-485b-bf68-3dbc1e6dca19"), 1, true, "Fiction" },
                    { new Guid("a0ba04a2-8b51-40ca-81e6-f04e8f19babe"), 1, true, "Biography" },
                    { new Guid("cf6c5337-10e9-48d9-9022-864ca0ff959c"), 0, true, "Inspirational" },
                    { new Guid("d4fd5a66-5aaa-4033-82e8-162e7ba64283"), 1, true, "Non_Fiction" },
                    { new Guid("d838e817-7fec-4280-812b-153015b8f088"), 0, true, "Informative" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookRatingSummaries_BookId",
                table: "BookRatingSummaries",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookSpecificRatings_BookRatingId",
                table: "BookSpecificRatings",
                column: "BookRatingId");

            migrationBuilder.CreateIndex(
                name: "IX_QuoteRatingSummaries_QuoteId",
                table: "QuoteRatingSummaries",
                column: "QuoteId");

            migrationBuilder.CreateIndex(
                name: "IX_QuoteSpecificRatings_QuoteRatingId",
                table: "QuoteSpecificRatings",
                column: "QuoteRatingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookRatingSummaries");

            migrationBuilder.DropTable(
                name: "BookSpecificRatings");

            migrationBuilder.DropTable(
                name: "QuoteRatingSummaries");

            migrationBuilder.DropTable(
                name: "QuoteSpecificRatings");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("04e0a766-8b37-4eec-8bf6-3fcd24ae67b4"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("0711ef55-bfde-4f6e-8f55-afc14e306806"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("0b1b930e-3812-4e78-882e-3223db35622d"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("209f7d62-2b2a-4e73-a476-291d793fd44d"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("317dbb97-322c-4558-b3df-9fa645d491d7"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("513e39f8-2785-4efb-92bd-5e8ad0268d01"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("51f8c642-92f1-428a-bba9-2a3e9822e3c9"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("5993e16c-f75a-414c-852c-73de49ba5ef4"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("8f801b50-959d-4030-94fa-b16aa1f0f235"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("93436277-e29b-485b-bf68-3dbc1e6dca19"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("a0ba04a2-8b51-40ca-81e6-f04e8f19babe"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("cf6c5337-10e9-48d9-9022-864ca0ff959c"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("d4fd5a66-5aaa-4033-82e8-162e7ba64283"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("d838e817-7fec-4280-812b-153015b8f088"));

            migrationBuilder.DropColumn(
                name: "AverageOverallRating",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "NumberOfOverallRatings",
                table: "Books");

            migrationBuilder.AddColumn<double>(
                name: "AverageRating",
                table: "Books",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfRatings",
                table: "Books",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "AccuracyRating",
                table: "BookRatings",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "CharacterDevelopmentRating",
                table: "BookRatings",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "PlotRating",
                table: "BookRatings",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "WorldBuildingRating",
                table: "BookRatings",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "WritingStyleRating",
                table: "BookRatings",
                type: "REAL",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RatingSummary",
                columns: table => new
                {
                    RatingSummaryId = table.Column<Guid>(type: "TEXT", nullable: false),
                    QuoteId = table.Column<Guid>(type: "TEXT", nullable: false),
                    AverageRating = table.Column<double>(type: "REAL", nullable: false),
                    NumberOfRatings = table.Column<int>(type: "INTEGER", nullable: false),
                    RatingCategory = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RatingSummary", x => x.RatingSummaryId);
                    table.ForeignKey(
                        name: "FK_RatingSummary_Quotes_QuoteId",
                        column: x => x.QuoteId,
                        principalTable: "Quotes",
                        principalColumn: "QuoteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpecificRatings",
                columns: table => new
                {
                    SpecificRatingId = table.Column<Guid>(type: "TEXT", nullable: false),
                    QuoteRatingId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Rating = table.Column<double>(type: "REAL", nullable: false),
                    RatingCategory = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecificRatings", x => x.SpecificRatingId);
                    table.ForeignKey(
                        name: "FK_SpecificRatings_QuoteRatings_QuoteRatingId",
                        column: x => x.QuoteRatingId,
                        principalTable: "QuoteRatings",
                        principalColumn: "QuoteRatingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "TagId", "Discriminator", "IsDefault", "Name" },
                values: new object[,]
                {
                    { new Guid("0260c837-6e5d-4891-ac02-ce92319d90c2"), 0, true, "Philosophical" },
                    { new Guid("0a8abcc5-000b-4d5e-b3cb-af367821eaab"), 1, true, "Romantic" },
                    { new Guid("1a73e52a-9cd1-42d3-b96f-12f3aa378408"), 1, true, "Non_Fiction" },
                    { new Guid("2ba83977-f4df-4a00-9a34-280703e73592"), 1, true, "Novel" },
                    { new Guid("44546ec7-cc78-4af4-ac44-61b12d133d99"), 1, true, "Comedy" },
                    { new Guid("4c715ab4-9aed-42e1-be38-17996f0edfa3"), 0, true, "Emotional" },
                    { new Guid("a753d54c-3a0a-444a-9951-4c0bdbd504b2"), 0, true, "Inspirational" },
                    { new Guid("aed35497-76f1-4abb-9827-ec3901b6bb2d"), 0, true, "Literary" },
                    { new Guid("bea8adc8-3e57-44a5-aba7-7e6f1ce88f83"), 0, true, "Informative" },
                    { new Guid("c31b96aa-63c0-4a8e-8adb-30f92ed62096"), 1, true, "Biography" },
                    { new Guid("dd5ff169-27fe-4d97-b045-532f9fca64d0"), 1, true, "Autobiography" },
                    { new Guid("eea9f259-c971-479c-856a-38734c5e4a4d"), 0, true, "Sad" },
                    { new Guid("f02562b5-730b-4052-b19d-69d4f1924113"), 0, true, "Funny" },
                    { new Guid("f4187471-f87f-4545-b6f1-8a378993d706"), 1, true, "Fiction" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RatingSummary_QuoteId",
                table: "RatingSummary",
                column: "QuoteId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecificRatings_QuoteRatingId",
                table: "SpecificRatings",
                column: "QuoteRatingId");
        }
    }
}
