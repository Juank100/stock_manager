using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace stock_manager.Models
{
    public enum ESTADOS
    {
        ACTIVO = 1,
        INACTIVO = 2
    }

    public enum TIPO_PERSONA
    {
        NATURAL,
        JURIDICA
    }

    public enum TIPO_DOCUMENTOS
    {
        CEDULA,
        CEDULA_EXTRANJERIA,
        NIT,
        PASAPORTE
    }

}
