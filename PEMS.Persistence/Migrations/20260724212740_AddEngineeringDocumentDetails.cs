using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PEMS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddEngineeringDocumentDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocumentRevisions_EngineeringDocuments_DocumentId",
                table: "DocumentRevisions");

            migrationBuilder.DropForeignKey(
                name: "FK_DocumentWorkflows_EngineeringDocuments_DocumentId",
                table: "DocumentWorkflows");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "EngineeringDocuments");

            migrationBuilder.AddColumn<string>(
                name: "ApprovedBy",
                table: "EngineeringDocuments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CheckedBy",
                table: "EngineeringDocuments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IssuePurpose",
                table: "EngineeringDocuments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "EngineeringDocuments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PreparedBy",
                table: "EngineeringDocuments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentRevisions_EngineeringDocuments_DocumentId",
                table: "DocumentRevisions",
                column: "DocumentId",
                principalTable: "EngineeringDocuments",
                principalColumn: "DocumentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentWorkflows_EngineeringDocuments_DocumentId",
                table: "DocumentWorkflows",
                column: "DocumentId",
                principalTable: "EngineeringDocuments",
                principalColumn: "DocumentId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocumentRevisions_EngineeringDocuments_DocumentId",
                table: "DocumentRevisions");

            migrationBuilder.DropForeignKey(
                name: "FK_DocumentWorkflows_EngineeringDocuments_DocumentId",
                table: "DocumentWorkflows");

            migrationBuilder.DropColumn(
                name: "ApprovedBy",
                table: "EngineeringDocuments");

            migrationBuilder.DropColumn(
                name: "CheckedBy",
                table: "EngineeringDocuments");

            migrationBuilder.DropColumn(
                name: "IssuePurpose",
                table: "EngineeringDocuments");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "EngineeringDocuments");

            migrationBuilder.DropColumn(
                name: "PreparedBy",
                table: "EngineeringDocuments");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "EngineeringDocuments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentRevisions_EngineeringDocuments_DocumentId",
                table: "DocumentRevisions",
                column: "DocumentId",
                principalTable: "EngineeringDocuments",
                principalColumn: "DocumentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentWorkflows_EngineeringDocuments_DocumentId",
                table: "DocumentWorkflows",
                column: "DocumentId",
                principalTable: "EngineeringDocuments",
                principalColumn: "DocumentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
