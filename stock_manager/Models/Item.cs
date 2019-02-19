using stock_manager.Helpers;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace stock_manager.Models
{
    [ParseToJavascript]
    public enum TIPO_VALORACION
    {
        LIFO = 1,
        FIFO = 2,
        PRECIO_PROMEDIO = 3
    }

    [ParseToJavascript]
    public enum TIPO_PRECIO_VENTA
    {
        PRECIO_FIJO = 1,
        PORCENTAJE_GANANCIA = 2
    }

    public class Medidas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nombre { get; set; }
    }

    public class Items
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public TIPO_VALORACION Tipo_Valoracion { get; set; }
        public TIPO_PRECIO_VENTA Tipo_Precio_Venta { get; set; }
        public double Precio_Venta { get; set; }
        public double IVA { get; set; }
        public int Id_Medida { get; set; }
        public ESTADOS Estado { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }

        [ForeignKey("Id_Medida")]
        public Medidas Medida { get; set; }

        public ICollection<Items_Facturas> Items_Facturas { get; set; }

        [NotMapped]
        public double Precio
        {
            get { return Precio_Venta; }
        }

        [NotMapped]
        public double Stock { get; set; }

        //[NotMapped]
        //public double Stock
        //{
        //    get
        //    {
        //        double entradas = 0;
        //        double salidas = 0;
        //        foreach (var f in Items_Facturas)
        //        {
        //            if (f.Factura.Tipo_Factura == TIPO_FACTURA.COMPRA)
        //            {
        //                entradas += f.Cantidad;
        //            }
        //            else
        //            {
        //                salidas += f.Cantidad;
        //            }
        //        }
        //        return entradas - salidas;
        //    }
        //}
    }
}
