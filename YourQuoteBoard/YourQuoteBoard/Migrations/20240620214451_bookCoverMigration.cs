using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YourQuoteBoard.Migrations
{
    /// <inheritdoc />
    public partial class bookCoverMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CoverImage",
                table: "Books",
                newName: "CoverImagePath");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CoverImagePath",
                table: "Books",
                newName: "CoverImage");
        }
    }
}
