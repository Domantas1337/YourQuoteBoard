using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YourQuoteBoard.Migrations
{
    /// <inheritdoc />
    public partial class folderMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Folders",
                columns: table => new
                {
                    FolderId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Folders", x => x.FolderId);
                    table.ForeignKey(
                        name: "FK_Folders_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuoteFolderJointTable",
                columns: table => new
                {
                    FoldersFolderId = table.Column<Guid>(type: "TEXT", nullable: false),
                    QuotesQuoteId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuoteFolderJointTable", x => new { x.FoldersFolderId, x.QuotesQuoteId });
                    table.ForeignKey(
                        name: "FK_QuoteFolderJointTable_Folders_FoldersFolderId",
                        column: x => x.FoldersFolderId,
                        principalTable: "Folders",
                        principalColumn: "FolderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuoteFolderJointTable_Quotes_QuotesQuoteId",
                        column: x => x.QuotesQuoteId,
                        principalTable: "Quotes",
                        principalColumn: "QuoteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Folders_ApplicationUserId",
                table: "Folders",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_QuoteFolderJointTable_QuotesQuoteId",
                table: "QuoteFolderJointTable",
                column: "QuotesQuoteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuoteFolderJointTable");

            migrationBuilder.DropTable(
                name: "Folders");
        }
    }
}
