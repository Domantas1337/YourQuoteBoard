using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace YourQuoteBoard.Migrations
{
    /// <inheritdoc />
    public partial class ratingUpdateMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("0e99aefa-d036-4acc-ad31-d08117188988"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("217c72de-194c-4cfd-9dac-eb38fdd4e77b"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("22569750-34fd-42ad-9fcd-36d0f5d13fba"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("2ca28332-9b30-4b0f-a70d-f7725e451968"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("43994156-bc20-48d5-8084-41db763fa9c3"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("5bd92020-901f-4109-9ab0-aced9f85117a"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("6a28c1ec-f6f5-4e0b-a7da-25656961e659"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("714c8528-18d6-4087-8786-b623413742b3"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("84395c68-462a-42f6-9eac-0762ccd2c346"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("a500b82b-3159-46e6-a3cd-4db4723cb0c7"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("b897e25d-c38f-4ff1-b05b-a8e7e6055e36"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("dbfb1cd7-c56f-44df-827c-0ce52ce95b60"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("e6c73460-f8a2-4ec1-af16-ecc67ee8045c"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("ea96b502-5231-45b2-9d57-a161d2bea9ef"));

            migrationBuilder.DropColumn(
                name: "AverageRating",
                table: "Quotes");

            migrationBuilder.DropColumn(
                name: "NumberOfRatings",
                table: "Quotes");

            migrationBuilder.DropColumn(
                name: "QuoteRatingInDetail_InspirationalValueRating",
                table: "QuoteRatings");

            migrationBuilder.DropColumn(
                name: "QuoteRatingInDetail_OriginalityRating",
                table: "QuoteRatings");

            migrationBuilder.DropColumn(
                name: "QuoteRatingInDetail_RelevanceToTheTopicRating",
                table: "QuoteRatings");

            migrationBuilder.AddColumn<double>(
                name: "AverageOverallRating",
                table: "Quotes",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfOverallRatings",
                table: "Quotes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "RatingSummary",
                columns: table => new
                {
                    RatingSummaryId = table.Column<Guid>(type: "TEXT", nullable: false),
                    RatingCategory = table.Column<int>(type: "INTEGER", nullable: false),
                    AverageRating = table.Column<double>(type: "REAL", nullable: false),
                    NumberOfRatings = table.Column<int>(type: "INTEGER", nullable: false),
                    QuoteId = table.Column<Guid>(type: "TEXT", nullable: false)
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
                    RatingCategory = table.Column<int>(type: "INTEGER", nullable: false),
                    Rating = table.Column<double>(type: "REAL", nullable: false),
                    QuoteRatingId = table.Column<Guid>(type: "TEXT", nullable: false)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "AverageOverallRating",
                table: "Quotes");

            migrationBuilder.DropColumn(
                name: "NumberOfOverallRatings",
                table: "Quotes");

            migrationBuilder.AddColumn<double>(
                name: "AverageRating",
                table: "Quotes",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfRatings",
                table: "Quotes",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "QuoteRatingInDetail_InspirationalValueRating",
                table: "QuoteRatings",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "QuoteRatingInDetail_OriginalityRating",
                table: "QuoteRatings",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "QuoteRatingInDetail_RelevanceToTheTopicRating",
                table: "QuoteRatings",
                type: "REAL",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "TagId", "Discriminator", "IsDefault", "Name" },
                values: new object[,]
                {
                    { new Guid("0e99aefa-d036-4acc-ad31-d08117188988"), 0, true, "Emotional" },
                    { new Guid("217c72de-194c-4cfd-9dac-eb38fdd4e77b"), 0, true, "Informative" },
                    { new Guid("22569750-34fd-42ad-9fcd-36d0f5d13fba"), 0, true, "Funny" },
                    { new Guid("2ca28332-9b30-4b0f-a70d-f7725e451968"), 0, true, "Philosophical" },
                    { new Guid("43994156-bc20-48d5-8084-41db763fa9c3"), 0, true, "Sad" },
                    { new Guid("5bd92020-901f-4109-9ab0-aced9f85117a"), 1, true, "Non_Fiction" },
                    { new Guid("6a28c1ec-f6f5-4e0b-a7da-25656961e659"), 0, true, "Literary" },
                    { new Guid("714c8528-18d6-4087-8786-b623413742b3"), 1, true, "Romantic" },
                    { new Guid("84395c68-462a-42f6-9eac-0762ccd2c346"), 1, true, "Fiction" },
                    { new Guid("a500b82b-3159-46e6-a3cd-4db4723cb0c7"), 1, true, "Comedy" },
                    { new Guid("b897e25d-c38f-4ff1-b05b-a8e7e6055e36"), 1, true, "Autobiography" },
                    { new Guid("dbfb1cd7-c56f-44df-827c-0ce52ce95b60"), 0, true, "Inspirational" },
                    { new Guid("e6c73460-f8a2-4ec1-af16-ecc67ee8045c"), 1, true, "Biography" },
                    { new Guid("ea96b502-5231-45b2-9d57-a161d2bea9ef"), 1, true, "Novel" }
                });
        }
    }
}
