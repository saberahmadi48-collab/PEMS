using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PEMS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddEquipmentDatasheet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EquipmentDatasheets",
                columns: table => new
                {
                    DatasheetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipmentId = table.Column<int>(type: "int", nullable: false),
                    DocumentNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RevisionNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DesignPressure = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DesignTemperature = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OperatingPressure = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OperatingTemperature = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Specification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentDatasheets", x => x.DatasheetId);
                    table.ForeignKey(
                        name: "FK_EquipmentDatasheets_Equipments_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipments",
                        principalColumn: "EquipmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentDatasheets_EquipmentId",
                table: "EquipmentDatasheets",
                column: "EquipmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquipmentDatasheets");
        }
    }
}
