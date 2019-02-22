using Microsoft.EntityFrameworkCore;

namespace stock_manager.Models
{

    public class BaseDatosContext : DbContext
    {
        public BaseDatosContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Permisos> Permisos { get; set; }
        public DbSet<Permisos_Roles> Permisos_Roles { get; set; }
        public DbSet<Roles_Usuarios> Roles_Usuarios { get; set; }

        public DbSet<Items> Items { get; set; }
        public DbSet<Medidas> Medidas { get; set; }
        public DbSet<Facturas> Facturas { get; set; }
        public DbSet<Items_Facturas> Items_Facturas { get; set; }
        public DbSet<Contactos> Contactos { get; set; }
        public DbSet<Empresas> Empresas { get; set; }
        public DbSet<Resolucion_Facturacion> Resolucion_Facturacion { get; set; }
        public DbSet<Stock> Stock { get; set; }
        public DbSet<Parametros> Parametros { get; set; }
        public DbSet<Modena> Modena { get; set; }
        public DbSet<Compras> Compras { get; set; }
        public DbSet<Ventas> Ventas { get; set; }

        public DbSet<Auditoria> Auditoria { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Items_Facturas>()
                .HasKey(bc => new { bc.Id_Item, bc.Id_Factura });
            modelBuilder.Entity<Items_Facturas>()
                .HasOne(bc => bc.Item)
                .WithMany(b => b.Items_Facturas)
                .HasForeignKey(bc => bc.Id_Item);
            modelBuilder.Entity<Items_Facturas>()
                .HasOne(bc => bc.Factura)
                .WithMany(c => c.Items_Facturas)
                .HasForeignKey(bc => bc.Id_Factura);
        }
    }
}
