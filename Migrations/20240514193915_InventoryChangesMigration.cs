using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManagment.Web.Migrations
{
    /// <inheritdoc />
    public partial class InventoryChangesMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DisplayModels");

            migrationBuilder.DropTable(
                name: "hardwareModelodels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Displays",
                table: "Displays");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "Laptops");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "Displays");

            migrationBuilder.RenameTable(
                name: "Displays",
                newName: "Monitors");

            migrationBuilder.AddColumn<DateOnly>(
                name: "DateOfPurchase",
                table: "Laptops",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<int>(
                name: "HardwareModel",
                table: "Laptops",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateOnly>(
                name: "DateOfPurchase",
                table: "Monitors",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<int>(
                name: "HardwareModel",
                table: "Monitors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Monitors",
                table: "Monitors",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "HardwareModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Producer = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HardwareModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InventoryChanges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HardwareId = table.Column<int>(type: "int", nullable: false),
                    InStock = table.Column<bool>(type: "bit", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HardwareModelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssignedTo = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Producer = table.Column<int>(type: "int", nullable: false),
                    HardwareModel = table.Column<int>(type: "int", nullable: false),
                    TypeOfHardware = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfChange = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryChanges", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HardwareModels");

            migrationBuilder.DropTable(
                name: "InventoryChanges");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Monitors",
                table: "Monitors");

            migrationBuilder.DropColumn(
                name: "DateOfPurchase",
                table: "Laptops");

            migrationBuilder.DropColumn(
                name: "HardwareModel",
                table: "Laptops");

            migrationBuilder.DropColumn(
                name: "DateOfPurchase",
                table: "Monitors");

            migrationBuilder.DropColumn(
                name: "HardwareModel",
                table: "Monitors");

            migrationBuilder.RenameTable(
                name: "Monitors",
                newName: "Displays");

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "Laptops",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "Displays",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Displays",
                table: "Displays",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "DisplayModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Producer = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisplayModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "hardwareModelodels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Producer = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hardwareModelodels", x => x.Id);
                });
        }
    }
}
