using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PEMS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddStaticEquipment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StaticEquipments",
                columns: table => new
                {
                    StaticEquipmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MechanicalEquipmentId = table.Column<int>(type: "int", nullable: false),
                    EquipmentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Volume = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DesignPressure = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DesignTemperature = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Material = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Orientation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeStandard = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaticEquipments", x => x.StaticEquipmentId);
                    table.ForeignKey(
                        name: "FK_StaticEquipments_MechanicalEquipments_MechanicalEquipmentId",
                        column: x => x.MechanicalEquipmentId,
                        principalTable: "MechanicalEquipments",
                        principalColumn: "MechanicalEquipmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StaticEquipments_MechanicalEquipmentId",
                table: "StaticEquipments",
                column: "MechanicalEquipmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StaticEquipments");
        }
    }
}
