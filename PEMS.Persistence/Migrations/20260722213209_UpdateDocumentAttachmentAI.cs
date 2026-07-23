using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PEMS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDocumentAttachmentAI : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AIProcessed",
                table: "DocumentAttachments");

            migrationBuilder.RenameColumn(
                name: "AIResult",
                table: "DocumentAttachments",
                newName: "AITags");

            migrationBuilder.AddColumn<double>(
                name: "AIConfidence",
                table: "DocumentAttachments",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AIKeywords",
                table: "DocumentAttachments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AIStatus",
                table: "DocumentAttachments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AISummary",
                table: "DocumentAttachments",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AIConfidence",
                table: "DocumentAttachments");

            migrationBuilder.DropColumn(
                name: "AIKeywords",
                table: "DocumentAttachments");

            migrationBuilder.DropColumn(
                name: "AIStatus",
                table: "DocumentAttachments");

            migrationBuilder.DropColumn(
                name: "AISummary",
                table: "DocumentAttachments");

            migrationBuilder.RenameColumn(
                name: "AITags",
                table: "DocumentAttachments",
                newName: "AIResult");

            migrationBuilder.AddColumn<bool>(
                name: "AIProcessed",
                table: "DocumentAttachments",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
