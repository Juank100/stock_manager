using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using stock_manager.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stock_manager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly BaseDatosContext _context;

        public ItemsController(BaseDatosContext context)
        {
            _context = context;
        }

        // GET: api/Items
        [HttpGet]
        public IEnumerable<Items> GetItems()
        {
            return _context.Items;
        }

        // GET: api/Items/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetItems([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = await _context.Items.FindAsync(id);

            if (items == null)
            {
                return NotFound();
            }

            return Ok(items);
        }

        // PUT: api/Items/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItems([FromRoute] int id, [FromBody] Items items)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != items.Id)
            {
                return BadRequest();
            }

            _context.Entry(items).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemsExists(id))
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

        // POST: api/Items
        [HttpPost]
        public async Task<IActionResult> PostItems([FromBody] Items item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            /*
             * Busca si la medida ya esta ingresada dentro del sistema, s i no es así agrega la nueva unidad de medida.
             * Todos los nombre de medidas van en minusculas.
             */
            var nomMedida = item.Medida.Nombre.ToLower();
            Medidas medida = _context.Medidas.FirstOrDefault(m => m.Nombre == nomMedida);
            if (medida == null)
            {
                medida = new Medidas { Nombre = nomMedida };
                _context.Medidas.Add(medida);
            }
            item.Id_Medida = medida.Id;
            item.Medida = medida;

            _context.Items.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItems", new { id = item.Id }, item);
        }

        // DELETE: api/Items/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItems([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = await _context.Items.FindAsync(id);
            if (items == null)
            {
                return NotFound();
            }

            _context.Items.Remove(items);
            await _context.SaveChangesAsync();

            return Ok(items);
        }

        private bool ItemsExists(int id)
        {
            return _context.Items.Any(e => e.Id == id);
        }
    }
}