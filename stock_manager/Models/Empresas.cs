using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace stock_manager.Models
{
    public enum TIPO_EMPRESAS
    {
        EMPRESA = 1,
        POS = 2
    }
    

    public class Empresas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public TIPO_DOCUMENTOS Tipo_Documento { get; set; }
        public string Documento { get; set; }
        public string Dig_Verificacion { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int Id_Tipo_Persona { get; set; }
        public ESTADOS Estado { get; set; }
        public int Id_Padre { get; set; }
        public string Logo { get; set; }

        [ForeignKey("Id_Tipo_Persona")]
        public Tipo_Persona Tipo_Persona { get; set; }
    }


    public class Resolucion_Facturacion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Id_Empresa { get; set; }
        public string Prefijo { get; set; }
        public int Desde { get; set; }
        public int Hasta { get; set; }
        public int Consecutivo { get; set; }
        public ESTADOS Estado { get; set; }

        public Empresas Empresa { get; set; }
    }
}
