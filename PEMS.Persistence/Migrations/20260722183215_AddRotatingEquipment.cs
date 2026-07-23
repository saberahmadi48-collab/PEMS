using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PEMS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddRotatingEquipment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RotatingEquipments",
                columns: table => new
                {
                    RotatingEquipmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MechanicalEquipmentId = table.Column<int>(type: "int", nullable: false),
                    EquipmentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlowRate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Head = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SpeedRPM = table.Column<int>(type: "int", nullable: true),
                    PowerKW = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DriverType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BearingType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LubricationType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RotatingEquipments", x => x.RotatingEquipmentId);
                    table.ForeignKey(
                        name: "FK_RotatingEquipments_MechanicalEquipments_MechanicalEquipmentId",
                        column: x => x.MechanicalEquipmentId,
                        principalTable: "MechanicalEquipments",
                        principalColumn: "MechanicalEquipmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RotatingEquipments_MechanicalEquipmentId",
                table: "RotatingEquipments",
                column: "MechanicalEquipmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RotatingEquipments");
        }
    }
}
