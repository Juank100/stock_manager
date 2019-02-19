﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using stock_manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stock_manager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturasController : ControllerBase
    {
        private readonly BaseDatosContext _context;

        public FacturasController(BaseDatosContext context)
        {
            _context = context;
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
            return _context.Facturas.Where(f => f.Tipo_Factura == TIPO_FACTURA.VENTA).ToList();
        }

        // GET: api/Facturas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFacturas([FromRoute] int id)
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

            return Ok(facturas);
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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Facturas factura = data.Factura;
            factura.Fecha = DateTime.Now;

            foreach (var item in data.Items) {
                _context.Items_Facturas.Add(new Items_Facturas {
                    Id_Factura = factura.Id,
                    Id_Item = item.producto.Id,
                    Cantidad = item.cantidad
                });
            }

            _context.Facturas.Add(factura);
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
    }
}