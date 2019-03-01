using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using stock_manager.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace stock_manager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturasController : ControllerBase
    {
        private readonly BaseDatosContext _context;
        private IConverter _converter;

        public FacturasController(BaseDatosContext context, IConverter converter)
        {
            _context = context;
            _converter = converter;
        }

        // GET: api/Facturas
        [HttpGet]
        public IEnumerable<Facturas> GetFacturas()
        {
            return _context.Facturas;
        }

        [HttpGet("Ventas")]
        public IEnumerable<Facturas> GetFacturasVentas()
        {
            return _context.Facturas.Where(f => f.Tipo_Factura == TIPO_FACTURA.VENTA).Include(i => i.Contacto).ToList();
        }

        [HttpGet("Compras")]
        public IActionResult GetFacturasCompras()
        {
            var facturas = _context.Facturas.Where(f => f.Tipo_Factura == TIPO_FACTURA.COMPRA).Include(i => i.Contacto).ToList();
            //foreach (var f in facturas)
            //{
            //    f.Items_Facturas = _context.Items_Facturas.Where(itf => itf.Id_Factura == f.Id).ToList();
            //}

            return Ok(facturas);
        }

        // GET: api/Facturas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFacturas([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var factura = await _context.Facturas.FindAsync(id);
            var factura = _context.Facturas.Include(f => f.Items_Facturas).Include(f => f.Contacto).Single(f => f.Id == id);
            IQueryable items = null;
            if (factura.Tipo_Factura == TIPO_FACTURA.COMPRA)
            {
                items = _context.Compras.Include(c => c.Item).Where(c => c.Id_Factura == factura.Id);
            }
            else if (factura.Tipo_Factura == TIPO_FACTURA.VENTA)
            {
                items = _context.Ventas.Include(c => c.Item).Where(c => c.Id_Factura == factura.Id);
            }

            if (factura == null)
            {
                return NotFound();
            }

            return Ok(new { factura, items });
        }

        // PUT: api/Facturas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFacturas([FromRoute] int id, [FromBody] Facturas facturas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != facturas.Id)
            {
                return BadRequest();
            }

            _context.Entry(facturas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacturasExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Facturas
        [HttpPost]
        public async Task<IActionResult> PostFacturas([FromBody] FacturasViewsModels data)
        {
            Facturas factura = data.Factura;
            factura.Fecha = DateTime.Now;
            _context.Facturas.Add(factura);

            if (factura.Tipo_Factura == TIPO_FACTURA.COMPRA)
            {
                foreach (var item in data.Items)
                {
                    _context.Compras.Add(new Compras
                    {
                        Id_Factura = factura.Id,
                        Id_Item = item.producto.Id,
                        Cantidad = item.cantidad,
                        Precio_Compra = item.producto.Precio,
                        Cantidad_Vendida = 0
                    });
                }
            }
            else if (factura.Tipo_Factura == TIPO_FACTURA.VENTA)
            {
                foreach (var item in data.Items)
                {
                    // Guarda eL registro de la venta
                    _context.Ventas.Add(new Ventas
                    {
                        Id_Factura = factura.Id,
                        Id_Item = item.producto.Id,
                        Cantidad = item.cantidad,
                        Descuento = item.producto.Descuento,
                        Precio_Venta = item.producto.Precio,
                        IVA = item.producto.IVA
                    });

                    // Suma las cantidades vendidas de las compras activas
                    var compras = _context.Compras.Where(c => c.Cantidad_Vendida < c.Cantidad).Include(c => c.Factura);
                    if (item.producto.Tipo_Valoracion == TIPO_VALORACION.FIFO)
                    {
                        compras.OrderBy(c => c.Factura.Fecha);
                    }
                    else if (item.producto.Tipo_Valoracion == TIPO_VALORACION.LIFO)
                    {
                        compras.OrderByDescending(c => c.Factura.Fecha);
                    }

                    var cantidadRestanteXReportar = item.cantidad;
                    foreach (var c in compras)
                    {
                        if (cantidadRestanteXReportar <= 0)
                        {
                            break;
                        }

                        var disponiblesEnRegistro = c.Cantidad - c.Cantidad_Vendida;
                        _context.Entry(c).State = EntityState.Modified;
                        string query = "UPDATE Compras set Cantidad_Vendida = {0} where Id = {1}";
                        if (disponiblesEnRegistro > cantidadRestanteXReportar)
                        {
                            c.Cantidad_Vendida = c.Cantidad_Vendida + cantidadRestanteXReportar;

                        }
                        else
                        {
                            c.Cantidad_Vendida = c.Cantidad_Vendida + disponiblesEnRegistro;
                        }
                        cantidadRestanteXReportar -= disponiblesEnRegistro;
                    }
                }
            }

            // Resolucion Facturacion
            var resolucion = _context.Resolucion_Facturacion.FirstOrDefault();
            if (resolucion != null)
            {
                resolucion.Consecutivo++;
                _context.Entry(resolucion).State = EntityState.Modified;

            }


            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFacturas", new { id = factura.Id }, factura);
        }

        // DELETE: api/Facturas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFacturas([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var facturas = await _context.Facturas.FindAsync(id);
            if (facturas == null)
            {
                return NotFound();
            }

            _context.Facturas.Remove(facturas);
            await _context.SaveChangesAsync();

            return Ok(facturas);
        }

        private bool FacturasExists(int id)
        {
            return _context.Facturas.Any(e => e.Id == id);
        }


        [HttpGet("Generar/{Id_Factura}")]
        public IActionResult createFactura(int Id_Factura)
        {

            var template = System.IO.File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "templates", "factura_0001.html"));
            var factura = _context.Facturas.Include(f => f.Contacto).SingleOrDefault(f => f.Id == Id_Factura);

            template = template.Replace("@Factura.Num", factura.Num);
            template = template.Replace("@Factura.Fecha", factura.Fecha.ToString("D"));
            template = template.Replace("@Contacto", factura.Contacto.Nombre);
            //Ventas items = null;
            //if (factura.Tipo_Factura == TIPO_FACTURA.COMPRA)
            //{
            //    items = _context.Compras.Include(c => c.Item).Where(c => c.Id_Factura == factura.Id);
            //}
            //else if (factura.Tipo_Factura == TIPO_FACTURA.VENTA)
            //{
            //}

           var items = _context.Ventas.Include(c => c.Item).Where(c => c.Id_Factura == factura.Id);
            var tabla = "";
            double sum = 0;
            foreach(var i in items)
            {
                tabla += "<tr>";
                tabla += String.Format("<td>{0}</td>", i.Item.Codigo);
                tabla += String.Format("<td>{0}</td>", i.Item.Codigo);
                tabla += String.Format("<td>{0}</td>", i.Cantidad);
                tabla += String.Format("<td>{0}</td>", i.Item.Precio_Venta);
                tabla += String.Format("<td>{0}</td>", i.Item.Precio_Venta * i.Cantidad);
                tabla += "</tr>";
                sum += i.Item.Precio_Venta * i.Cantidad;
            }

            tabla += ("<tr><td colspan='3'>{0}<td><tr>", sum);


            template = template.Replace("@Items", tabla);

            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = "PDF Report",
            };

            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = template,
                //WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "assets", "styles.css") },
                HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
                FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Report Footer" }
            };

            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };

            var file = _converter.Convert(pdf);
            return File(file, "application/pdf");
        }
    }
}