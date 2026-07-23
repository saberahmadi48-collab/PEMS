using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PEMS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddMechanicalEquipment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MechanicalEquipments",
                columns: table => new
                {
                    MechanicalEquipmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipmentId = table.Column<int>(type: "int", nullable: true),
                    TagNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EquipmentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DesignPressure = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DesignTemperature = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OperatingPressure = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OperatingTemperature = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Material = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MechanicalEquipments", x => x.MechanicalEquipmentId);
                    table.ForeignKey(
                        name: "FK_MechanicalEquipments_Equipments_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipments",
                        principalColumn: "EquipmentId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MechanicalEquipments_EquipmentId",
                table: "MechanicalEquipments",
                column: "EquipmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MechanicalEquipments");
        }
    }
}
