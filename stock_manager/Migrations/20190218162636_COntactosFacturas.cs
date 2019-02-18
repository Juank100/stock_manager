using Microsoft.EntityFrameworkCore.Migrations;

namespace stock_manager.Migrations
{
    public partial class COntactosFacturas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id_Contacto",
                table: "Facturas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Num",
                table: "Facturas",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_Id_Contacto",
                table: "Facturas",
                column: "Id_Contacto");

            migrationBuilder.AddForeignKey(
                name: "FK_Facturas_Contactos_Id_Contacto",
                table: "Facturas",
                column: "Id_Contacto",
                principalTable: "Contactos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facturas_Contactos_Id_Contacto",
                table: "Facturas");

            migrationBuilder.DropIndex(
                name: "IX_Facturas_Id_Contacto",
                table: "Facturas");

            migrationBuilder.DropColumn(
                name: "Id_Contacto",
                table: "Facturas");

            migrationBuilder.DropColumn(
                name: "Num",
                table: "Facturas");
        }
    }
}
