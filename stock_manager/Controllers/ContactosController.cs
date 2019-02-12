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
    public class ContactosController : ControllerBase
    {
        private readonly BaseDatosContext _context;

        public ContactosController(BaseDatosContext context)
        {
            _context = context;
        }

        // GET: api/Contactos
        [HttpGet]
        public IEnumerable<Contactos> GetContactos()
        {
            return _context.Contactos;
        }

        // GET: api/Contactos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactos([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var contactos = await _context.Contactos.FindAsync(id);

            if (contactos == null)
            {
                return NotFound();
            }

            return Ok(contactos);
        }

        // PUT: api/Contactos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContactos([FromRoute] int id, [FromBody] Contactos contactos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contactos.Id)
            {
                return BadRequest();
            }

            _context.Entry(contactos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactosExists(id))
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

        // POST: api/Contactos
        [HttpPost]
        public async Task<IActionResult> PostContactos([FromBody] Contactos contactos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Contactos.Add(contactos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContactos", new { id = contactos.Id }, contactos);
        }

        // DELETE: api/Contactos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContactos([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var contactos = await _context.Contactos.FindAsync(id);
            if (contactos == null)
            {
                return NotFound();
            }

            _context.Contactos.Remove(contactos);
            await _context.SaveChangesAsync();

            return Ok(contactos);
        }

        private bool ContactosExists(int id)
        {
            return _context.Contactos.Any(e => e.Id == id);
        }
    }
}