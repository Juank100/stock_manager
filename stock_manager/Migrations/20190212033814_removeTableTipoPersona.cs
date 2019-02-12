using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace stock_manager.Migrations
{
    public partial class removeTableTipoPersona : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contactos_Tipo_Persona_Id_Tipo_Persona",
                table: "Contactos");

            migrationBuilder.DropForeignKey(
                name: "FK_Empresas_Tipo_Persona_Id_Tipo_Persona",
                table: "Empresas");

            migrationBuilder.DropTable(
                name: "Tipo_Persona");

            migrationBuilder.DropIndex(
                name: "IX_Empresas_Id_Tipo_Persona",
                table: "Empresas");

            migrationBuilder.DropIndex(
                name: "IX_Contactos_Id_Tipo_Persona",
                table: "Contactos");

            migrationBuilder.DropColumn(
                name: "Id_Tipo_Persona",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "Id_Tipo_Persona",
                table: "Contactos");

            migrationBuilder.AddColumn<int>(
                name: "Tipo_Persona",
                table: "Empresas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Tipo_Persona",
                table: "Contactos",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tipo_Persona",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "Tipo_Persona",
                table: "Contactos");

            migrationBuilder.AddColumn<int>(
                name: "Id_Tipo_Persona",
                table: "Empresas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id_Tipo_Persona",
                table: "Contactos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Tipo_Persona",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipo_Persona", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_Id_Tipo_Persona",
                table: "Empresas",
                column: "Id_Tipo_Persona");

            migrationBuilder.CreateIndex(
                name: "IX_Contactos_Id_Tipo_Persona",
                table: "Contactos",
                column: "Id_Tipo_Persona");

            migrationBuilder.AddForeignKey(
                name: "FK_Contactos_Tipo_Persona_Id_Tipo_Persona",
                table: "Contactos",
                column: "Id_Tipo_Persona",
                principalTable: "Tipo_Persona",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Empresas_Tipo_Persona_Id_Tipo_Persona",
                table: "Empresas",
                column: "Id_Tipo_Persona",
                principalTable: "Tipo_Persona",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
