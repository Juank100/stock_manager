using stock_manager.Helpers;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace stock_manager.Models
{
    [ParseToJavascript]
    public enum TIPO_FACTURA
    {
        VENTA = 1,
        COMPRA = 2
    }

    public class Facturas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public TIPO_FACTURA Tipo_Factura { get; set; }
        public DateTime Fecha { get; set; }
    }

    public class Items_Facturas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Id_Item { get; set; }
        public int Id_Factura { get; set; }
        public double Cantidad { get; set; }
        public double Descuento { get; set; }

        [ForeignKey("Id_Item")]
        public Items Item { get; set; }
        [ForeignKey("Id_Factura")]
        public Facturas Factura { get; set; }

    }
}
