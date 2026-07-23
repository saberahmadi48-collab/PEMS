using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PEMS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddMaintenancePlan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MaintenancePlans",
                columns: table => new
                {
                    MaintenancePlanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipmentId = table.Column<int>(type: "int", nullable: false),
                    MaintenanceStrategyId = table.Column<int>(type: "int", nullable: false),
                    PlanNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IntervalDays = table.Column<int>(type: "int", nullable: true),
                    LastExecutionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NextDueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenancePlans", x => x.MaintenancePlanId);
                    table.ForeignKey(
                        name: "FK_MaintenancePlans_Equipments_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipments",
                        principalColumn: "EquipmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaintenancePlans_MaintenanceStrategies_MaintenanceStrategyId",
                        column: x => x.MaintenanceStrategyId,
                        principalTable: "MaintenanceStrategies",
                        principalColumn: "MaintenanceStrategyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MaintenancePlans_EquipmentId",
                table: "MaintenancePlans",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenancePlans_MaintenanceStrategyId",
                table: "MaintenancePlans",
                column: "MaintenanceStrategyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaintenancePlans");
        }
    }
}
