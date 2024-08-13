using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace YourQuoteBoard.Migrations
{
    /// <inheritdoc />
    public partial class ShortDescriptionQuote : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "ShortDescription",
                table: "Quotes",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "ShortDescription",
                table: "Quotes");

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
    }
}
