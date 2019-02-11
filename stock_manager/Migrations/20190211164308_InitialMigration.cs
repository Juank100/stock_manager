using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace stock_manager.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Facturas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Tipo_Factura = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medidas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medidas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Modena",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Precision = table.Column<int>(nullable: false),
                    Simbolo = table.Column<string>(nullable: true),
                    Abreviatura = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modena", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parametros",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parametros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permisos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permisos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Usuario = table.Column<string>(nullable: true),
                    Clave = table.Column<string>(nullable: true),
                    Dir_Elec = table.Column<string>(nullable: true),
                    Estado = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Codigo = table.Column<string>(nullable: true),
                    Tipo_Valoracion = table.Column<int>(nullable: false),
                    Tipo_Precio_Venta = table.Column<int>(nullable: false),
                    Precio_Venta = table.Column<double>(nullable: false),
                    IVA = table.Column<double>(nullable: false),
                    Id_Medida = table.Column<int>(nullable: false),
                    Estado = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true),
                    Imagen = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Medidas_Id_Medida",
                        column: x => x.Id_Medida,
                        principalTable: "Medidas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Permisos_Roles",
                columns: table => new
                {
                    Id_Permiso = table.Column<int>(nullable: false),
                    Id_Rol = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permisos_Roles", x => x.Id_Permiso);
                    table.ForeignKey(
                        name: "FK_Permisos_Roles_Permisos_Id_Permiso",
                        column: x => x.Id_Permiso,
                        principalTable: "Permisos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Permisos_Roles_Roles_Id_Rol",
                        column: x => x.Id_Rol,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contactos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Tipo_Contacto = table.Column<int>(nullable: false),
                    Id_Tipo_Documento = table.Column<int>(nullable: false),
                    Documento = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true),
                    Celuar = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    Dir_Elec = table.Column<string>(nullable: true),
                    Estado = table.Column<int>(nullable: false),
                    Id_Tipo_Persona = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contactos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contactos_Tipo_Documento_Id_Tipo_Documento",
                        column: x => x.Id_Tipo_Documento,
                        principalTable: "Tipo_Documento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contactos_Tipo_Persona_Id_Tipo_Persona",
                        column: x => x.Id_Tipo_Persona,
                        principalTable: "Tipo_Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Id_Tipo_Documento = table.Column<int>(nullable: false),
                    Documento = table.Column<string>(nullable: true),
                    Dig_Verificacion = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true),
                    Id_Tipo_Persona = table.Column<int>(nullable: false),
                    Estado = table.Column<int>(nullable: false),
                    Id_Padre = table.Column<int>(nullable: false),
                    Logo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Empresas_Tipo_Documento_Id_Tipo_Documento",
                        column: x => x.Id_Tipo_Documento,
                        principalTable: "Tipo_Documento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Empresas_Tipo_Persona_Id_Tipo_Persona",
                        column: x => x.Id_Tipo_Persona,
                        principalTable: "Tipo_Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Auditoria",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Id_Usuario = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Accion = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    Tabla = table.Column<string>(nullable: true),
                    Id_Detalle = table.Column<int>(nullable: false),
                    A = table.Column<string>(nullable: true),
                    B = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auditoria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Auditoria_Usuarios_Id_Usuario",
                        column: x => x.Id_Usuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Roles_Usuarios",
                columns: table => new
                {
                    Id_Rol = table.Column<int>(nullable: false),
                    Id_Usuario = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles_Usuarios", x => x.Id_Rol);
                    table.ForeignKey(
                        name: "FK_Roles_Usuarios_Roles_Id_Rol",
                        column: x => x.Id_Rol,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Roles_Usuarios_Usuarios_Id_Usuario",
                        column: x => x.Id_Usuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items_Facturas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Id_Item = table.Column<int>(nullable: false),
                    Id_Factura = table.Column<int>(nullable: false),
                    Cantidad = table.Column<double>(nullable: false),
                    Descuento = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items_Facturas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Facturas_Facturas_Id_Factura",
                        column: x => x.Id_Factura,
                        principalTable: "Facturas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Items_Facturas_Items_Id_Item",
                        column: x => x.Id_Item,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Resolucion_Facturacion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Id_Empresa = table.Column<int>(nullable: false),
                    Prefijo = table.Column<string>(nullable: true),
                    Desde = table.Column<int>(nullable: false),
                    Hasta = table.Column<int>(nullable: false),
                    Consecutivo = table.Column<int>(nullable: false),
                    Estado = table.Column<int>(nullable: false),
                    EmpresaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resolucion_Facturacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resolucion_Facturacion_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Stock",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Id_Item = table.Column<int>(nullable: false),
                    Id_Empresa = table.Column<int>(nullable: false),
                    Min_Stock = table.Column<int>(nullable: false),
                    Max_Stock = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stock_Empresas_Id_Empresa",
                        column: x => x.Id_Empresa,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stock_Items_Id_Item",
                        column: x => x.Id_Item,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Auditoria_Id_Usuario",
                table: "Auditoria",
                column: "Id_Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Contactos_Id_Tipo_Documento",
                table: "Contactos",
                column: "Id_Tipo_Documento");

            migrationBuilder.CreateIndex(
                name: "IX_Contactos_Id_Tipo_Persona",
                table: "Contactos",
                column: "Id_Tipo_Persona");

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_Id_Tipo_Documento",
                table: "Empresas",
                column: "Id_Tipo_Documento");

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_Id_Tipo_Persona",
                table: "Empresas",
                column: "Id_Tipo_Persona");

            migrationBuilder.CreateIndex(
                name: "IX_Items_Id_Medida",
                table: "Items",
                column: "Id_Medida");

            migrationBuilder.CreateIndex(
                name: "IX_Items_Facturas_Id_Factura",
                table: "Items_Facturas",
                column: "Id_Factura");

            migrationBuilder.CreateIndex(
                name: "IX_Items_Facturas_Id_Item",
                table: "Items_Facturas",
                column: "Id_Item");

            migrationBuilder.CreateIndex(
                name: "IX_Permisos_Roles_Id_Rol",
                table: "Permisos_Roles",
                column: "Id_Rol");

            migrationBuilder.CreateIndex(
                name: "IX_Resolucion_Facturacion_EmpresaId",
                table: "Resolucion_Facturacion",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Usuarios_Id_Usuario",
                table: "Roles_Usuarios",
                column: "Id_Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Stock_Id_Empresa",
                table: "Stock",
                column: "Id_Empresa");

            migrationBuilder.CreateIndex(
                name: "IX_Stock_Id_Item",
                table: "Stock",
                column: "Id_Item");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Auditoria");

            migrationBuilder.DropTable(
                name: "Contactos");

            migrationBuilder.DropTable(
                name: "Items_Facturas");

            migrationBuilder.DropTable(
                name: "Modena");

            migrationBuilder.DropTable(
                name: "Parametros");

            migrationBuilder.DropTable(
                name: "Permisos_Roles");

            migrationBuilder.DropTable(
                name: "Resolucion_Facturacion");

            migrationBuilder.DropTable(
                name: "Roles_Usuarios");

            migrationBuilder.DropTable(
                name: "Stock");

            migrationBuilder.DropTable(
                name: "Facturas");

            migrationBuilder.DropTable(
                name: "Permisos");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Tipo_Documento");

            migrationBuilder.DropTable(
                name: "Tipo_Persona");

            migrationBuilder.DropTable(
                name: "Medidas");
        }
    }
}
