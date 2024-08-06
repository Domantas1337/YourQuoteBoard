using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace YourQuoteBoard.Migrations
{
    /// <inheritdoc />
    public partial class detailedRating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { new Guid("260e120a-e859-4340-b5b8-c9b332bf3bcb"), 0, true, "Emotional" },
                    { new Guid("2c837ffb-5d90-4bc5-a6d4-7ac188dfec75"), 1, true, "Autobiography" },
                    { new Guid("351b1422-72cc-4b9f-946d-38c038c650c5"), 0, true, "Informative" },
                    { new Guid("617de854-f7e2-4829-b886-ab914effac17"), 0, true, "Literary" },
                    { new Guid("674cbc23-601a-4472-b72b-0b24f38b22c5"), 1, true, "Fiction" },
                    { new Guid("6e82ea27-911e-44e9-858a-7f6eed909a95"), 0, true, "Sad" },
                    { new Guid("743ef06f-9f8c-4ffb-bf7e-37a4d844ffcb"), 0, true, "Philosophical" },
                    { new Guid("75b2cab3-86a9-492a-a22a-931f65fcfe02"), 1, true, "Comedy" },
                    { new Guid("a67f610d-6dcf-454c-b913-796b9f220ec9"), 1, true, "Novel" },
                    { new Guid("acddf115-450c-4227-98b3-49110ee8c207"), 0, true, "Funny" },
                    { new Guid("b0ab7b41-9c8f-42a4-9509-b68c62d6840d"), 1, true, "Non_Fiction" },
                    { new Guid("bb5eb928-6ad5-41f5-9f6f-d5e7f88b2ae0"), 1, true, "Romantic" },
                    { new Guid("daf61beb-b791-4b55-9415-c8941e78a754"), 1, true, "Biography" },
                    { new Guid("ec42e8b7-fc2c-4242-a905-cbf3d49631c3"), 0, true, "Inspirational" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("260e120a-e859-4340-b5b8-c9b332bf3bcb"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("2c837ffb-5d90-4bc5-a6d4-7ac188dfec75"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("351b1422-72cc-4b9f-946d-38c038c650c5"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("617de854-f7e2-4829-b886-ab914effac17"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("674cbc23-601a-4472-b72b-0b24f38b22c5"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("6e82ea27-911e-44e9-858a-7f6eed909a95"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("743ef06f-9f8c-4ffb-bf7e-37a4d844ffcb"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("75b2cab3-86a9-492a-a22a-931f65fcfe02"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("a67f610d-6dcf-454c-b913-796b9f220ec9"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("acddf115-450c-4227-98b3-49110ee8c207"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("b0ab7b41-9c8f-42a4-9509-b68c62d6840d"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("bb5eb928-6ad5-41f5-9f6f-d5e7f88b2ae0"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("daf61beb-b791-4b55-9415-c8941e78a754"));

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagId",
                keyValue: new Guid("ec42e8b7-fc2c-4242-a905-cbf3d49631c3"));

            migrationBuilder.DropColumn(
                name: "QuoteRatingInDetail_InspirationalValueRating",
                table: "QuoteRatings");

            migrationBuilder.DropColumn(
                name: "QuoteRatingInDetail_OriginalityRating",
                table: "QuoteRatings");

            migrationBuilder.DropColumn(
                name: "QuoteRatingInDetail_RelevanceToTheTopicRating",
                table: "QuoteRatings");

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
    }
}
