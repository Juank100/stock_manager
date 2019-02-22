using Microsoft.EntityFrameworkCore.Migrations;

namespace stock_manager.Migrations
{
    public partial class AjustarCamposFacturas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Observaciones",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "Observaciones",
                table: "Compras");

            migrationBuilder.AddColumn<double>(
                name: "IVA",
                table: "Ventas",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Observaciones",
                table: "Facturas",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IVA",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "Observaciones",
                table: "Facturas");

            migrationBuilder.AddColumn<string>(
                name: "Observaciones",
                table: "Ventas",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Observaciones",
                table: "Compras",
                nullable: true);
        }
    }
}
