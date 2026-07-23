using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PEMS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddCable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cables",
                columns: table => new
                {
                    CableId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CableNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CableType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FromEquipment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToEquipment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VoltageLevel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Length = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoreNumber = table.Column<int>(type: "int", nullable: true),
                    InstallationMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CableTray = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cables", x => x.CableId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cables");
        }
    }
}
