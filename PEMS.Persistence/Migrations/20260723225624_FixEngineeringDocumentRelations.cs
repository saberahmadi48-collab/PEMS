using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PEMS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixEngineeringDocumentRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EngineeringDocuments_Disciplines_DisciplineId",
                table: "EngineeringDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_EngineeringDocuments_Projects_ProjectId",
                table: "EngineeringDocuments");

            migrationBuilder.AddForeignKey(
                name: "FK_EngineeringDocuments_Disciplines_DisciplineId",
                table: "EngineeringDocuments",
                column: "DisciplineId",
                principalTable: "Disciplines",
                principalColumn: "DisciplineId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EngineeringDocuments_Projects_ProjectId",
                table: "EngineeringDocuments",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EngineeringDocuments_Disciplines_DisciplineId",
                table: "EngineeringDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_EngineeringDocuments_Projects_ProjectId",
                table: "EngineeringDocuments");

            migrationBuilder.AddForeignKey(
                name: "FK_EngineeringDocuments_Disciplines_DisciplineId",
                table: "EngineeringDocuments",
                column: "DisciplineId",
                principalTable: "Disciplines",
                principalColumn: "DisciplineId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EngineeringDocuments_Projects_ProjectId",
                table: "EngineeringDocuments",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
