using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using stock_manager.Models;

namespace stock_manager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResolucionFacturacionController : ControllerBase
    {
        private readonly BaseDatosContext _context;

        public ResolucionFacturacionController(BaseDatosContext context)
        {
            _context = context;
        }

        // GET: api/ResolucionFacturacion
        [HttpGet]
        public IEnumerable<Resolucion_Facturacion> GetResolucion_Facturacion()
        {
            return _context.Resolucion_Facturacion;
        }

        // GET: api/ResolucionFacturacion/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetResolucion_Facturacion([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var resolucion_Facturacion = await _context.Resolucion_Facturacion.FindAsync(id);

            if (resolucion_Facturacion == null)
            {
                return NotFound();
            }

            return Ok(resolucion_Facturacion);
        }

        // PUT: api/ResolucionFacturacion/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutResolucion_Facturacion([FromRoute] int id, [FromBody] Resolucion_Facturacion resolucion_Facturacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != resolucion_Facturacion.Id)
            {
                return BadRequest();
            }

            _context.Entry(resolucion_Facturacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Resolucion_FacturacionExists(id))
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

        // POST: api/ResolucionFacturacion
        [HttpPost]
        public async Task<IActionResult> PostResolucion_Facturacion([FromBody] Resolucion_Facturacion resolucion_Facturacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Resolucion_Facturacion.Add(resolucion_Facturacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetResolucion_Facturacion", new { id = resolucion_Facturacion.Id }, resolucion_Facturacion);
        }

        // DELETE: api/ResolucionFacturacion/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResolucion_Facturacion([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var resolucion_Facturacion = await _context.Resolucion_Facturacion.FindAsync(id);
            if (resolucion_Facturacion == null)
            {
                return NotFound();
            }

            _context.Resolucion_Facturacion.Remove(resolucion_Facturacion);
            await _context.SaveChangesAsync();

            return Ok(resolucion_Facturacion);
        }

        private bool Resolucion_FacturacionExists(int id)
        {
            return _context.Resolucion_Facturacion.Any(e => e.Id == id);
        }
    }
}