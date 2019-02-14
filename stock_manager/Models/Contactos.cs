using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using stock_manager.Helpers;

namespace stock_manager.Models
{
    [ParseToJavascript]
    public enum TIPO_CONTACTO
    {
        CLIENTE = 1,
        PROVEEDOR = 2
    }

    public class Contactos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public TIPO_CONTACTO Tipo_Contacto { get; set; }
        public TIPO_DOCUMENTOS Tipo_Documento { get; set; }
        public string Documento { get; set; }
        public string Telefono { get; set; }
        public string Celuar { get; set; }
        public string Direccion { get; set; }
        public string Dir_Elec { get; set; }
        public ESTADOS Estado { get; set; }
        public TIPO_PERSONA Tipo_Persona { get; set; }
    }

}
