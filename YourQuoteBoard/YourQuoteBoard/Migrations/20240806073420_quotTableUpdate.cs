using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace YourQuoteBoard.Migrations
{
    /// <inheritdoc />
    public partial class quotTableUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<int>(
                name: "Genre",
                table: "Quotes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<double>(
                name: "OverallRating",
                table: "BookRatings",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "REAL",
                oldNullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "Genre",
                table: "Quotes");

            migrationBuilder.AlterColumn<double>(
                name: "OverallRating",
                table: "BookRatings",
                type: "REAL",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "REAL");

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
        }
    }
}
