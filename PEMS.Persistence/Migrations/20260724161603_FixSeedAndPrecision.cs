using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PEMS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixSeedAndPrecision : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectId", "ClientName", "CreatedDate", "EndDate", "IsActive", "Location", "ProjectCode", "ProjectName", "StartDate", "Status" },
                values: new object[] { 1, "Petrochemical", new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, "Assaluyeh", "PEMS-001", "Polymer Plant Development", null, "Active" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 1);
        }
    }
}
