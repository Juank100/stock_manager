using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace stock_manager.Migrations
{
    public partial class SepararCompraVentas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Items_Facturas",
                table: "Items_Facturas");

            migrationBuilder.DropIndex(
                name: "IX_Items_Facturas_Id_Item",
                table: "Items_Facturas");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Items_Facturas_Id",
                table: "Items_Facturas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Items_Facturas",
                table: "Items_Facturas",
                columns: new[] { "Id_Item", "Id_Factura" });

            migrationBuilder.CreateTable(
                name: "Compras",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Id_Item = table.Column<int>(nullable: false),
                    Id_Factura = table.Column<int>(nullable: false),
                    Cantidad = table.Column<double>(nullable: false),
                    Precio_Compra = table.Column<double>(nullable: false),
                    Cantidad_Vendida = table.Column<double>(nullable: false),
                    Observaciones = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Compras_Facturas_Id_Factura",
                        column: x => x.Id_Factura,
                        principalTable: "Facturas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Compras_Items_Id_Item",
                        column: x => x.Id_Item,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ventas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Id_Item = table.Column<int>(nullable: false),
                    Id_Factura = table.Column<int>(nullable: false),
                    Cantidad = table.Column<double>(nullable: false),
                    Precio_Venta = table.Column<double>(nullable: false),
                    Descuento = table.Column<double>(nullable: false),
                    Observaciones = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ventas_Facturas_Id_Factura",
                        column: x => x.Id_Factura,
                        principalTable: "Facturas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ventas_Items_Id_Item",
                        column: x => x.Id_Item,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Compras_Id_Factura",
                table: "Compras",
                column: "Id_Factura");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_Id_Item",
                table: "Compras",
                column: "Id_Item");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_Id_Factura",
                table: "Ventas",
                column: "Id_Factura");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_Id_Item",
                table: "Ventas",
                column: "Id_Item");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Compras");

            migrationBuilder.DropTable(
                name: "Ventas");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Items_Facturas_Id",
                table: "Items_Facturas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Items_Facturas",
                table: "Items_Facturas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Items_Facturas",
                table: "Items_Facturas",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Items_Facturas_Id_Item",
                table: "Items_Facturas",
                column: "Id_Item");
        }
    }
}
