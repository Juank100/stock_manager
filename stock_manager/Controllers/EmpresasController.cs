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
    public class EmpresasController : ControllerBase
    {
        private readonly BaseDatosContext _context;

        public EmpresasController(BaseDatosContext context)
        {
            _context = context;
        }

        // GET: api/Empresas
        [HttpGet]
        public IEnumerable<Empresas> GetEmpresas()
        {
            return _context.Empresas;
        }

        // GET: api/Empresas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmpresas([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var empresas = await _context.Empresas.FindAsync(id);

            if (empresas == null)
            {
                return NotFound();
            }

            return Ok(empresas);
        }

        [HttpGet("{id}/POS")]
        public async Task<IActionResult> GetPOSEmpresas([FromRoute] int id)
        {
            var empresas = _context.Empresas.Where(e => e.Id_Padre == id);
            return Ok(empresas);
        }

        // PUT: api/Empresas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpresas([FromRoute] int id, [FromBody] Empresas empresas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != empresas.Id)
            {
                return BadRequest();
            }

            _context.Entry(empresas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpresasExists(id))
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

        // POST: api/Empresas
        [HttpPost]
        public async Task<IActionResult> PostEmpresas([FromBody] Empresas empresas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Empresas.Add(empresas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmpresas", new { id = empresas.Id }, empresas);
        }

        // DELETE: api/Empresas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpresas([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var empresas = await _context.Empresas.FindAsync(id);
            if (empresas == null)
            {
                return NotFound();
            }

            _context.Empresas.Remove(empresas);
            await _context.SaveChangesAsync();

            return Ok(empresas);
        }

        private bool EmpresasExists(int id)
        {
            return _context.Empresas.Any(e => e.Id == id);
        }
    }
}