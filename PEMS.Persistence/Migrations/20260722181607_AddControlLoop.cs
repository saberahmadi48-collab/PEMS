using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PEMS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddControlLoop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ControlLoops",
                columns: table => new
                {
                    LoopId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoopNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProcessArea = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ControllerType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ControllerSystem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstrumentId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControlLoops", x => x.LoopId);
                    table.ForeignKey(
                        name: "FK_ControlLoops_Instruments_InstrumentId",
                        column: x => x.InstrumentId,
                        principalTable: "Instruments",
                        principalColumn: "InstrumentId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ControlLoops_InstrumentId",
                table: "ControlLoops",
                column: "InstrumentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ControlLoops");
        }
    }
}
