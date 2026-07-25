using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PEMS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddDocumentSoftDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeletedById",
                table: "EngineeringDocuments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "EngineeringDocuments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "EngineeringDocuments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_EngineeringDocuments_DeletedById",
                table: "EngineeringDocuments",
                column: "DeletedById");

            migrationBuilder.AddForeignKey(
                name: "FK_EngineeringDocuments_Employees_DeletedById",
                table: "EngineeringDocuments",
                column: "DeletedById",
                principalTable: "Employees",
                principalColumn: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EngineeringDocuments_Employees_DeletedById",
                table: "EngineeringDocuments");

            migrationBuilder.DropIndex(
                name: "IX_EngineeringDocuments_DeletedById",
                table: "EngineeringDocuments");

            migrationBuilder.DropColumn(
                name: "DeletedById",
                table: "EngineeringDocuments");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "EngineeringDocuments");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "EngineeringDocuments");
        }
    }
}
