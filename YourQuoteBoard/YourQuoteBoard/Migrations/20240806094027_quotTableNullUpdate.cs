using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace YourQuoteBoard.Migrations
{
    /// <inheritdoc />
    public partial class quotTableNullUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("0954d923-26ef-4ef6-ab00-337cac486343"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("15aec5fc-5975-46da-8049-8f27def3d09a"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("2464737b-93e3-4bbb-83f4-d423c30ccb37"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("263cf69c-6cfb-4cbe-b730-cb978702c2f2"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("302ece55-fb6f-4b37-90b2-bc233ffa6f80"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("308b8d41-e43c-4a43-b7d9-8a1fc1e041d0"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("5071310f-cc78-406a-9f6f-9415f0d330d6"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("7bee6f51-d2f2-46e6-a425-b987bd5891b5"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("b221f922-218a-49af-98f4-d1aca08408ef"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("ca7370bb-0d99-4cc4-8704-b6c48338ca0f"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("db03efce-fbcb-4ffa-bd23-f39855497a04"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("f079a678-95d7-4056-b13b-bce5980b1843"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("f7d81a63-6251-4ff3-8ea3-363491caa936"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("f9c3184f-5317-437d-9cb4-62a682cdfa12"));

            migrationBuilder.DropColumn(
                name: "InspirationalValueRating",
                table: "QuoteRatings");

            migrationBuilder.DropColumn(
                name: "OriginalityRating",
                table: "QuoteRatings");

            migrationBuilder.DropColumn(
                name: "RelevanceToTheTopicRating",
                table: "QuoteRatings");

            migrationBuilder.AlterColumn<int>(
                name: "Genre",
                table: "Quotes",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "TagId", "Discriminator", "IsDefault", "Name" },
                values: new object[,]
                {
                    { new Guid("10ca1ee0-1b3a-4b16-bc35-b14fa38a76b3"), 1, true, "Non_Fiction" },
                    { new Guid("1ca5787f-dc5f-440c-8035-acecf0f9fed3"), 1, true, "Romantic" },
                    { new Guid("30399f8a-95d0-4d17-9ad0-591a9243653c"), 0, true, "Inspirational" },
                    { new Guid("34a5f0c3-d7c8-4ca9-ba0e-cc37b012c2ad"), 1, true, "Comedy" },
                    { new Guid("3726c765-d169-4867-ba20-9e0e48505417"), 0, true, "Literary" },
                    { new Guid("4ef88cd1-5740-4d1c-bd33-a0736c409a99"), 0, true, "Emotional" },
                    { new Guid("57bee32b-6e94-46b8-88fe-2869ed2600dc"), 1, true, "Novel" },
                    { new Guid("704282f5-677a-46f3-9650-fc22f4dd4810"), 1, true, "Biography" },
                    { new Guid("7fa4923b-6974-49ad-8cc9-d5d80871be53"), 0, true, "Sad" },
                    { new Guid("a0d8879b-9090-4a4e-bd5c-6f73e152a58f"), 0, true, "Funny" },
                    { new Guid("a6b0b957-a68b-4e70-8d95-75837521a963"), 1, true, "Fiction" },
                    { new Guid("bc3c2911-b4de-4e9f-bd23-da2408861f97"), 0, true, "Philosophical" },
                    { new Guid("cf054f20-7bd2-46f5-972c-1618a43be253"), 1, true, "Autobiography" },
                    { new Guid("fa2c26a1-c5e8-4afc-951e-bdd176e60b9c"), 0, true, "Informative" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("10ca1ee0-1b3a-4b16-bc35-b14fa38a76b3"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("1ca5787f-dc5f-440c-8035-acecf0f9fed3"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("30399f8a-95d0-4d17-9ad0-591a9243653c"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("34a5f0c3-d7c8-4ca9-ba0e-cc37b012c2ad"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("3726c765-d169-4867-ba20-9e0e48505417"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("4ef88cd1-5740-4d1c-bd33-a0736c409a99"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("57bee32b-6e94-46b8-88fe-2869ed2600dc"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("704282f5-677a-46f3-9650-fc22f4dd4810"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("7fa4923b-6974-49ad-8cc9-d5d80871be53"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("a0d8879b-9090-4a4e-bd5c-6f73e152a58f"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("a6b0b957-a68b-4e70-8d95-75837521a963"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("bc3c2911-b4de-4e9f-bd23-da2408861f97"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("cf054f20-7bd2-46f5-972c-1618a43be253"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("fa2c26a1-c5e8-4afc-951e-bdd176e60b9c"));

            migrationBuilder.AlterColumn<int>(
                name: "Genre",
                table: "Quotes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "InspirationalValueRating",
                table: "QuoteRatings",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "OriginalityRating",
                table: "QuoteRatings",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "RelevanceToTheTopicRating",
                table: "QuoteRatings",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "TagId", "Discriminator", "IsDefault", "Name" },
                values: new object[,]
                {
                    { new Guid("0954d923-26ef-4ef6-ab00-337cac486343"), 0, true, "Informative" },
                    { new Guid("15aec5fc-5975-46da-8049-8f27def3d09a"), 1, true, "Novel" },
                    { new Guid("2464737b-93e3-4bbb-83f4-d423c30ccb37"), 1, true, "Romantic" },
                    { new Guid("263cf69c-6cfb-4cbe-b730-cb978702c2f2"), 0, true, "Inspirational" },
                    { new Guid("302ece55-fb6f-4b37-90b2-bc233ffa6f80"), 1, true, "Non_Fiction" },
                    { new Guid("308b8d41-e43c-4a43-b7d9-8a1fc1e041d0"), 0, true, "Philosophical" },
                    { new Guid("5071310f-cc78-406a-9f6f-9415f0d330d6"), 0, true, "Literary" },
                    { new Guid("7bee6f51-d2f2-46e6-a425-b987bd5891b5"), 1, true, "Biography" },
                    { new Guid("b221f922-218a-49af-98f4-d1aca08408ef"), 1, true, "Comedy" },
                    { new Guid("ca7370bb-0d99-4cc4-8704-b6c48338ca0f"), 1, true, "Fiction" },
                    { new Guid("db03efce-fbcb-4ffa-bd23-f39855497a04"), 0, true, "Funny" },
                    { new Guid("f079a678-95d7-4056-b13b-bce5980b1843"), 1, true, "Autobiography" },
                    { new Guid("f7d81a63-6251-4ff3-8ea3-363491caa936"), 0, true, "Sad" },
                    { new Guid("f9c3184f-5317-437d-9cb4-62a682cdfa12"), 0, true, "Emotional" }
                });
        }
    }
}
