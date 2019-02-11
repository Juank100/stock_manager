using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace stock_manager.Models
{
    public class Usuarios
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Clave { get; set; }
        public string Dir_Elec { get; set; }
        public ESTADOS Estado { get; set; }

        public List<Roles_Usuarios> Roles_Usuarios { get; set; }
    }

    public class Roles
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nombre { get; set; }

        public List<Permisos_Roles> Permisos_Roles { get; set; }
        public List<Roles_Usuarios> Roles_Usuarios { get; set; }
    }

    public class Permisos
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public List<Permisos_Roles> Permisos_Roles { get; set; }
    }

    public class Roles_Usuarios
    {
        [Key]
        public int Id_Rol { get; set; }
        public int Id_Usuario { get; set; }

        [ForeignKey("Id_Rol")]
        public Roles Roles { get; set; }
        [ForeignKey("Id_Usuario")]
        public Usuarios Usuarios { get; set; }
    }

    public class Permisos_Roles
    {
        [Key]
        public int Id_Permiso { get; set; }
        public int Id_Rol { get; set; }

        [ForeignKey("Id_Rol")]
        public Roles Roles { get; set; }
        [ForeignKey("Id_Permiso")]
        public Permisos Permisos { get; set; }
    }
}
