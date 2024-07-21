using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YourQuoteBoard.Migrations
{
    /// <inheritdoc />
    public partial class quotebookratingupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "BookRatings");

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
                name: "OverallRating",
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
                name: "QuoteRatings",
                columns: table => new
                {
                    QuoteRatingId = table.Column<Guid>(type: "TEXT", nullable: false),
                    OverallRating = table.Column<double>(type: "REAL", nullable: false),
                    OriginalityRating = table.Column<double>(type: "REAL", nullable: false),
                    InspirationalValueRating = table.Column<double>(type: "REAL", nullable: false),
                    RelevanceToTheTopicRating = table.Column<double>(type: "REAL", nullable: false),
                    QuoteId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuoteRatings", x => x.QuoteRatingId);
                    table.ForeignKey(
                        name: "FK_QuoteRatings_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuoteRatings_Quotes_QuoteId",
                        column: x => x.QuoteId,
                        principalTable: "Quotes",
                        principalColumn: "QuoteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuoteRatings_ApplicationUserId",
                table: "QuoteRatings",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_QuoteRatings_QuoteId",
                table: "QuoteRatings",
                column: "QuoteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuoteRatings");

            migrationBuilder.DropColumn(
                name: "AverageRating",
                table: "Quotes");

            migrationBuilder.DropColumn(
                name: "NumberOfRatings",
                table: "Quotes");

            migrationBuilder.DropColumn(
                name: "AccuracyRating",
                table: "BookRatings");

            migrationBuilder.DropColumn(
                name: "CharacterDevelopmentRating",
                table: "BookRatings");

            migrationBuilder.DropColumn(
                name: "OverallRating",
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
                name: "Rating",
                table: "BookRatings",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
