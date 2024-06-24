using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YourQuoteBoard.Migrations
{
    /// <inheritdoc />
    public partial class bookTableTypesMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "AverageRating",
                table: "Books",
                type: "REAL",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "TEXT",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "AverageRating",
                table: "Books",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "REAL",
                oldNullable: true);
        }
    }
}
