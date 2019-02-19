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
    public class MedidasController : ControllerBase
    {
        private readonly BaseDatosContext _context;

        public MedidasController(BaseDatosContext context)
        {
            _context = context;
        }

        // GET: api/Medidas
        [HttpGet]
        public IEnumerable<Medidas> GetMedidas()
        {
            return _context.Medidas;
        }

        // GET: api/Medidas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMedidas([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var medidas = await _context.Medidas.FindAsync(id);

            if (medidas == null)
            {
                return NotFound();
            }

            return Ok(medidas);
        }

        // PUT: api/Medidas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedidas([FromRoute] int id, [FromBody] Medidas medidas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != medidas.Id)
            {
                return BadRequest();
            }

            _context.Entry(medidas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedidasExists(id))
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

        // POST: api/Medidas
        [HttpPost]
        public async Task<IActionResult> PostMedidas([FromBody] Medidas medidas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Medidas.Add(medidas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMedidas", new { id = medidas.Id }, medidas);
        }

        // DELETE: api/Medidas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedidas([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var medidas = await _context.Medidas.FindAsync(id);
            if (medidas == null)
            {
                return NotFound();
            }

            _context.Medidas.Remove(medidas);
            await _context.SaveChangesAsync();

            return Ok(medidas);
        }

        private bool MedidasExists(int id)
        {
            return _context.Medidas.Any(e => e.Id == id);
        }
    }
}