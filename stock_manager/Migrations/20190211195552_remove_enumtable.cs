using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace stock_manager.Migrations
{
    public partial class remove_enumtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contactos_Tipo_Documento_Id_Tipo_Documento",
                table: "Contactos");

            migrationBuilder.DropForeignKey(
                name: "FK_Empresas_Tipo_Documento_Id_Tipo_Documento",
                table: "Empresas");

            migrationBuilder.DropTable(
                name: "Tipo_Documento");

            migrationBuilder.DropIndex(
                name: "IX_Empresas_Id_Tipo_Documento",
                table: "Empresas");

            migrationBuilder.DropIndex(
                name: "IX_Contactos_Id_Tipo_Documento",
                table: "Contactos");

            migrationBuilder.DropColumn(
                name: "Id_Tipo_Documento",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "Id_Tipo_Documento",
                table: "Contactos");

            migrationBuilder.AddColumn<int>(
                name: "Tipo_Documento",
                table: "Empresas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Tipo_Documento",
                table: "Contactos",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tipo_Documento",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "Tipo_Documento",
                table: "Contactos");

            migrationBuilder.AddColumn<int>(
                name: "Id_Tipo_Documento",
                table: "Empresas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id_Tipo_Documento",
                table: "Contactos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Tipo_Documento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipo_Documento", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_Id_Tipo_Documento",
                table: "Empresas",
                column: "Id_Tipo_Documento");

            migrationBuilder.CreateIndex(
                name: "IX_Contactos_Id_Tipo_Documento",
                table: "Contactos",
                column: "Id_Tipo_Documento");

            migrationBuilder.AddForeignKey(
                name: "FK_Contactos_Tipo_Documento_Id_Tipo_Documento",
                table: "Contactos",
                column: "Id_Tipo_Documento",
                principalTable: "Tipo_Documento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Empresas_Tipo_Documento_Id_Tipo_Documento",
                table: "Empresas",
                column: "Id_Tipo_Documento",
                principalTable: "Tipo_Documento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
