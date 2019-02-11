using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace stock_manager.Models
{
    public class Auditoria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Id_Usuario { get; set; }
        public DateTime Fecha { get; set; }
        public string Accion { get; set; }
        public string Descripcion { get; set; }
        public string Tabla { get; set; }
        public int Id_Detalle { get; set; }
        public string A { get; set; }
        public string B { get; set; }

        [ForeignKey("Id_Usuario")]
        public Usuarios Usuario { get; set; }
    }
}
