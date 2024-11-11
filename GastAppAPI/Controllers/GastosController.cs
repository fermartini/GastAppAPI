using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GastAppAPI.Context;
using GastAppAPI.Models;

namespace GastAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GastosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GastosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Gastos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gasto>>> GetGastos()
        {
            return await _context.Gastos.ToListAsync();
        }

        // GET: api/Gastos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Gasto>> GetGasto(int id)
        {
            var gasto = await _context.Gastos.FindAsync(id);

            if (gasto == null)
            {
                return NotFound();
            }

            return gasto;
        }

        // GET: api/Gastos/5
        [HttpGet("usuario/{usuarioId}")]
        public async Task<ActionResult<IEnumerable<Gasto>>> GetGastoUsuarios(string usuarioId)
        {
            var gastos = await _context.Gastos
                    .Where(g => g.UsuarioId == usuarioId)
                        .ToListAsync();
            if (gastos == null)
            {
                return NotFound();
            }

            return gastos;
        }

        // GET: api/nombregasto/5
        [HttpGet("nombregasto/{nombreGastoId}")]
        public async Task<ActionResult<IEnumerable<Gasto>>> GetNombreGastoId(int nombreGastoId)
        {
            var gastos = await _context.Gastos
                    .Where(g => g.NombreGastoId == nombreGastoId)
                        .ToListAsync();
            if (gastos == null)
            {
                return NotFound();
            }

            return gastos;
        }

        // PUT: api/Gastos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGasto(int id, Gasto gasto)
        {
            if (id != gasto.Id)
            {
                return BadRequest();
            }

            _context.Entry(gasto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GastoExists(id))
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

        // PUT: api/Gastos/5/pagado
        [HttpPut("{id}/pagado")]
        public async Task<IActionResult> UpdatePagado(int id)
        {
            var gasto = await _context.Gastos.FindAsync(id);
            if (gasto == null)
            {
                return NotFound();
            }

            // Cambiar el valor de Pagado entre 0 y 1
            gasto.Pagado = gasto.Pagado == 0 ? 1 : 0;  // Si es 0 lo pone a 1, si es 1 lo pone a 0

            _context.Entry(gasto).Property(g => g.Pagado).IsModified = true;

            try
            {
                await _context.SaveChangesAsync();  // Guarda los cambios en la base de datos
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GastoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();  // Devuelve una respuesta sin contenido (indicando éxito)
        }



        // POST: api/Gastos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Gasto>> PostGasto(Gasto gasto)
        {
            _context.Gastos.Add(gasto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGasto", new { id = gasto.Id }, gasto);
        }

        // DELETE: api/Gastos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGasto(int id)
        {
            var gasto = await _context.Gastos.FindAsync(id);
            if (gasto == null)
            {
                return NotFound();
            }

            _context.Gastos.Remove(gasto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GastoExists(int id)
        {
            return _context.Gastos.Any(e => e.Id == id);
        }
    }
}
