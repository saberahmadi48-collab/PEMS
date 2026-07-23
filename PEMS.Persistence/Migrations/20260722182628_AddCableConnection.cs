using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PEMS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddCableConnection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CableConnections",
                columns: table => new
                {
                    ConnectionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CableId = table.Column<int>(type: "int", nullable: false),
                    FromPanel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FromTerminal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToEquipment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToTerminal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConnectionType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CableConnections", x => x.ConnectionId);
                    table.ForeignKey(
                        name: "FK_CableConnections_Cables_CableId",
                        column: x => x.CableId,
                        principalTable: "Cables",
                        principalColumn: "CableId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CableConnections_CableId",
                table: "CableConnections",
                column: "CableId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CableConnections");
        }
    }
}
