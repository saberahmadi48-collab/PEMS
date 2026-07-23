using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PEMS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddElectricalEquipment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ElectricalEquipments",
                columns: table => new
                {
                    ElectricalEquipmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipmentId = table.Column<int>(type: "int", nullable: true),
                    TagNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EquipmentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PowerKW = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Voltage = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RatedCurrent = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Phase = table.Column<int>(type: "int", nullable: true),
                    SupplySource = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectricalEquipments", x => x.ElectricalEquipmentId);
                    table.ForeignKey(
                        name: "FK_ElectricalEquipments_Equipments_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipments",
                        principalColumn: "EquipmentId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ElectricalEquipments_EquipmentId",
                table: "ElectricalEquipments",
                column: "EquipmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ElectricalEquipments");
        }
    }
}
