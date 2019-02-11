using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace stock_manager.Models
{
    public enum TIPO_VALORACION
    {
        LIFO = 1,
        FIFO = 2,
        PRECIO_PROMEDIO = 3
    }

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
    }
}
