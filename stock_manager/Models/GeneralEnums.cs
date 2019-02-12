using stock_manager.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace stock_manager.Models
{
    [ParseToJavascript]
    public enum ESTADOS
    {
        ACTIVO = 1,
        INACTIVO = 2
    }

    [ParseToJavascript]
    public enum TIPO_PERSONA
    {
        NATURAL,
        JURIDICA
    }

    [ParseToJavascript]
    public enum TIPO_DOCUMENTOS
    {
        CEDULA,
        CEDULA_EXTRANJERIA,
        NIT,
        PASAPORTE
    }

}
