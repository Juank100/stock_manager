using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace stock_manager.Models
{
    public class Stock
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Id_Item { get; set; }
        public int Id_Empresa { get; set; }
        public int Min_Stock { get; set; }
        public int Max_Stock { get; set; }

        [ForeignKey("Id_Item")]
        public Items Item { get; set; }

        [ForeignKey("Id_Empresa")]
        public Empresas Empresa { get; set; }
    }
}
