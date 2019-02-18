using System.Collections.Generic;

namespace stock_manager.Models
{
    public class FacturasViewsModels
    {
        public Facturas Factura { get; set; }
        public List<ItemsFacturasViewsModels> Items { get; set; }
    }


    public class ItemsFacturasViewsModels
    {
        public double cantidad { get; set; }
        public Items producto { get; set; }
    }
}
