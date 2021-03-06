﻿using stock_manager.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace stock_manager.Models
{
    [ParseToJavascript]
    public enum TIPO_FACTURA
    {
        VENTA = 1,
        COMPRA = 2
    }

    public class Facturas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Num { get; set; }
        public TIPO_FACTURA Tipo_Factura { get; set; }
        public DateTime Fecha { get; set; }
        public int Id_Contacto { get; set; }
        public string Observaciones { get; set; }

        [ForeignKey("Id_Contacto")]
        public Contactos Contacto { get; set; }

        public ICollection<Items_Facturas> Items_Facturas { get; set; }
    }

    public class Items_Facturas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Id_Item { get; set; }
        public int Id_Factura { get; set; }
        public double Cantidad { get; set; }
        public double Descuento { get; set; }

        [ForeignKey("Id_Item")]
        public Items Item { get; set; }

        [ForeignKey("Id_Factura")]
        public Facturas Factura { get; set; }

    }

    public class Compras
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Id_Item { get; set; }
        public int Id_Factura { get; set; }
        public double Cantidad { get; set; }
        public double Precio_Compra { get; set; }
        public double Cantidad_Vendida { get; set; }

        [ForeignKey("Id_Item")]
        public Items Item { get; set; }

        [ForeignKey("Id_Factura")]
        public Facturas Factura { get; set; }
    }


    public class Ventas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Id_Item { get; set; }
        public int Id_Factura { get; set; }
        public double Cantidad { get; set; }
        public double Precio_Venta { get; set; }
        public double Descuento { get; set; }
        public double IVA { get;  set; }

        [ForeignKey("Id_Item")]
        public Items Item { get; set; }

        [ForeignKey("Id_Factura")]
        public Facturas Factura { get; set; }
    }



}
