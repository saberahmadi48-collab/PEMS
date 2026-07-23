using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PEMS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddDocumentRevision : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DocumentRevisions",
                columns: table => new
                {
                    RevisionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentId = table.Column<int>(type: "int", nullable: false),
                    RevisionNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RevisionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PreparedById = table.Column<int>(type: "int", nullable: true),
                    CheckedById = table.Column<int>(type: "int", nullable: true),
                    ApprovedById = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentRevisions", x => x.RevisionId);
                    table.ForeignKey(
                        name: "FK_DocumentRevisions_Employees_ApprovedById",
                        column: x => x.ApprovedById,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId");
                    table.ForeignKey(
                        name: "FK_DocumentRevisions_Employees_CheckedById",
                        column: x => x.CheckedById,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId");
                    table.ForeignKey(
                        name: "FK_DocumentRevisions_Employees_PreparedById",
                        column: x => x.PreparedById,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId");
                    table.ForeignKey(
                        name: "FK_DocumentRevisions_EngineeringDocuments_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "EngineeringDocuments",
                        principalColumn: "DocumentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DocumentRevisions_ApprovedById",
                table: "DocumentRevisions",
                column: "ApprovedById");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentRevisions_CheckedById",
                table: "DocumentRevisions",
                column: "CheckedById");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentRevisions_DocumentId",
                table: "DocumentRevisions",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentRevisions_PreparedById",
                table: "DocumentRevisions",
                column: "PreparedById");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocumentRevisions");
        }
    }
}
