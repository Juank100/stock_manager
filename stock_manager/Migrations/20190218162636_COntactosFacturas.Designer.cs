﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using stock_manager.Models;

namespace stock_manager.Migrations
{
    [DbContext(typeof(BaseDatosContext))]
    [Migration("20190218162636_COntactosFacturas")]
    partial class COntactosFacturas
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("stock_manager.Models.Auditoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("A");

                    b.Property<string>("Accion");

                    b.Property<string>("B");

                    b.Property<string>("Descripcion");

                    b.Property<DateTime>("Fecha");

                    b.Property<int>("Id_Detalle");

                    b.Property<int>("Id_Usuario");

                    b.Property<string>("Tabla");

                    b.HasKey("Id");

                    b.HasIndex("Id_Usuario");

                    b.ToTable("Auditoria");
                });

            modelBuilder.Entity("stock_manager.Models.Contactos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Celuar");

                    b.Property<string>("Dir_Elec");

                    b.Property<string>("Direccion");

                    b.Property<string>("Documento");

                    b.Property<int>("Estado");

                    b.Property<string>("Nombre");

                    b.Property<string>("Telefono");

                    b.Property<int>("Tipo_Contacto");

                    b.Property<int>("Tipo_Documento");

                    b.Property<int>("Tipo_Persona");

                    b.HasKey("Id");

                    b.ToTable("Contactos");
                });

            modelBuilder.Entity("stock_manager.Models.Empresas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Dig_Verificacion");

                    b.Property<string>("Direccion");

                    b.Property<string>("Documento");

                    b.Property<int>("Estado");

                    b.Property<int>("Id_Padre");

                    b.Property<string>("Logo");

                    b.Property<string>("Nombre");

                    b.Property<string>("Telefono");

                    b.Property<int>("Tipo_Documento");

                    b.Property<int>("Tipo_Persona");

                    b.HasKey("Id");

                    b.ToTable("Empresas");
                });

            modelBuilder.Entity("stock_manager.Models.Facturas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Fecha");

                    b.Property<int>("Id_Contacto");

                    b.Property<string>("Num");

                    b.Property<int>("Tipo_Factura");

                    b.HasKey("Id");

                    b.HasIndex("Id_Contacto");

                    b.ToTable("Facturas");
                });

            modelBuilder.Entity("stock_manager.Models.Items", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Codigo");

                    b.Property<string>("Descripcion");

                    b.Property<int>("Estado");

                    b.Property<double>("IVA");

                    b.Property<int>("Id_Medida");

                    b.Property<string>("Imagen");

                    b.Property<string>("Nombre");

                    b.Property<double>("Precio_Venta");

                    b.Property<int>("Tipo_Precio_Venta");

                    b.Property<int>("Tipo_Valoracion");

                    b.HasKey("Id");

                    b.HasIndex("Id_Medida");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("stock_manager.Models.Items_Facturas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Cantidad");

                    b.Property<double>("Descuento");

                    b.Property<int>("Id_Factura");

                    b.Property<int>("Id_Item");

                    b.HasKey("Id");

                    b.HasIndex("Id_Factura");

                    b.HasIndex("Id_Item");

                    b.ToTable("Items_Facturas");
                });

            modelBuilder.Entity("stock_manager.Models.Medidas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre");

                    b.HasKey("Id");

                    b.ToTable("Medidas");
                });

            modelBuilder.Entity("stock_manager.Models.Modena", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Abreviatura");

                    b.Property<string>("Nombre");

                    b.Property<int>("Precision");

                    b.Property<string>("Simbolo");

                    b.HasKey("Id");

                    b.ToTable("Modena");
                });

            modelBuilder.Entity("stock_manager.Models.Parametros", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("Parametros");
                });

            modelBuilder.Entity("stock_manager.Models.Permisos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion");

                    b.Property<string>("Nombre");

                    b.HasKey("Id");

                    b.ToTable("Permisos");
                });

            modelBuilder.Entity("stock_manager.Models.Permisos_Roles", b =>
                {
                    b.Property<int>("Id_Permiso");

                    b.Property<int>("Id_Rol");

                    b.HasKey("Id_Permiso");

                    b.HasIndex("Id_Rol");

                    b.ToTable("Permisos_Roles");
                });

            modelBuilder.Entity("stock_manager.Models.Resolucion_Facturacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Consecutivo");

                    b.Property<int>("Desde");

                    b.Property<int?>("EmpresaId");

                    b.Property<int>("Estado");

                    b.Property<int>("Hasta");

                    b.Property<int>("Id_Empresa");

                    b.Property<string>("Prefijo");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.ToTable("Resolucion_Facturacion");
                });

            modelBuilder.Entity("stock_manager.Models.Roles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("stock_manager.Models.Roles_Usuarios", b =>
                {
                    b.Property<int>("Id_Rol");

                    b.Property<int>("Id_Usuario");

                    b.HasKey("Id_Rol");

                    b.HasIndex("Id_Usuario");

                    b.ToTable("Roles_Usuarios");
                });

            modelBuilder.Entity("stock_manager.Models.Stock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Id_Empresa");

                    b.Property<int>("Id_Item");

                    b.Property<int>("Max_Stock");

                    b.Property<int>("Min_Stock");

                    b.HasKey("Id");

                    b.HasIndex("Id_Empresa");

                    b.HasIndex("Id_Item");

                    b.ToTable("Stock");
                });

            modelBuilder.Entity("stock_manager.Models.Usuarios", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Clave");

                    b.Property<string>("Dir_Elec");

                    b.Property<int>("Estado");

                    b.Property<string>("Usuario");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("stock_manager.Models.Auditoria", b =>
                {
                    b.HasOne("stock_manager.Models.Usuarios", "Usuario")
                        .WithMany()
                        .HasForeignKey("Id_Usuario")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("stock_manager.Models.Facturas", b =>
                {
                    b.HasOne("stock_manager.Models.Contactos", "Contacto")
                        .WithMany()
                        .HasForeignKey("Id_Contacto")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("stock_manager.Models.Items", b =>
                {
                    b.HasOne("stock_manager.Models.Medidas", "Medida")
                        .WithMany()
                        .HasForeignKey("Id_Medida")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("stock_manager.Models.Items_Facturas", b =>
                {
                    b.HasOne("stock_manager.Models.Facturas", "Factura")
                        .WithMany()
                        .HasForeignKey("Id_Factura")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("stock_manager.Models.Items", "Item")
                        .WithMany()
                        .HasForeignKey("Id_Item")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("stock_manager.Models.Permisos_Roles", b =>
                {
                    b.HasOne("stock_manager.Models.Permisos", "Permisos")
                        .WithMany("Permisos_Roles")
                        .HasForeignKey("Id_Permiso")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("stock_manager.Models.Roles", "Roles")
                        .WithMany("Permisos_Roles")
                        .HasForeignKey("Id_Rol")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("stock_manager.Models.Resolucion_Facturacion", b =>
                {
                    b.HasOne("stock_manager.Models.Empresas", "Empresa")
                        .WithMany()
                        .HasForeignKey("EmpresaId");
                });

            modelBuilder.Entity("stock_manager.Models.Roles_Usuarios", b =>
                {
                    b.HasOne("stock_manager.Models.Roles", "Roles")
                        .WithMany("Roles_Usuarios")
                        .HasForeignKey("Id_Rol")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("stock_manager.Models.Usuarios", "Usuarios")
                        .WithMany("Roles_Usuarios")
                        .HasForeignKey("Id_Usuario")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("stock_manager.Models.Stock", b =>
                {
                    b.HasOne("stock_manager.Models.Empresas", "Empresa")
                        .WithMany()
                        .HasForeignKey("Id_Empresa")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("stock_manager.Models.Items", "Item")
                        .WithMany()
                        .HasForeignKey("Id_Item")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
