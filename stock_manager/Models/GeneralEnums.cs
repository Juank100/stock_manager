using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace stock_manager.Models
{
    public enum ESTADOS
    {
        ACTIVO = 1,
        INACTIVO = 2
    }


    public class Tipo_Persona
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nombre { get; set; }
    }

    public enum TIPO_DOCUMENTOS
    {
        CEDULA,
        CEDULA_EXTRANJERIA,
        NIT,
        PASAPORTE
    }

}
