using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PEMS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddEngineeringDocumentUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocumentAttachments_EngineeringDocuments_DocumentId",
                table: "DocumentAttachments");

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentAttachments_EngineeringDocuments_DocumentId",
                table: "DocumentAttachments",
                column: "DocumentId",
                principalTable: "EngineeringDocuments",
                principalColumn: "DocumentId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocumentAttachments_EngineeringDocuments_DocumentId",
                table: "DocumentAttachments");

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentAttachments_EngineeringDocuments_DocumentId",
                table: "DocumentAttachments",
                column: "DocumentId",
                principalTable: "EngineeringDocuments",
                principalColumn: "DocumentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
