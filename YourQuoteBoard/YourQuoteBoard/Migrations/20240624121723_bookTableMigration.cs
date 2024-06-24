using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YourQuoteBoard.Migrations
{
    /// <inheritdoc />
    public partial class bookTableMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "AverageRating",
                table: "Books",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfRatings",
                table: "Books",
                type: "INTEGER",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AverageRating",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "NumberOfRatings",
                table: "Books");
        }
    }
}
