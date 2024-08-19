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
    public class IngresosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public IngresosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Ingresos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ingreso>>> GetIngresos()
        {
            return await _context.Ingresos.ToListAsync();
        }

        // GET: api/Ingresos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ingreso>> GetIngreso(int id)
        {
            var ingreso = await _context.Ingresos.FindAsync(id);

            if (ingreso == null)
            {
                return NotFound();
            }

            return ingreso;
        }
        // GET: api/Gastos/5
        [HttpGet("usuario/{usuarioId}")]
        public async Task<ActionResult<IEnumerable<Ingreso>>> GetIngresoUsuario(string usuarioId)
        {
            var ingreso = await _context.Ingresos
                    .Where(g => g.UsuarioId == usuarioId)
                        .ToListAsync();
            if (ingreso == null)
            {
                return NotFound();
            }

            return ingreso;
        }

        // GET: api/Gastos/5
        [HttpGet("nombreingreso/{nombreIngresoId}")]
        public async Task<ActionResult<IEnumerable<Ingreso>>> GetIngresoUsuario(int nombreIngresoId)
        {
            var ingreso = await _context.Ingresos
                    .Where(g => g.NombreIngresoId == nombreIngresoId)
                        .ToListAsync();
            if (ingreso == null)
            {
                return NotFound();
            }

            return ingreso;
        }

        // PUT: api/Ingresos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIngreso(int id, Ingreso ingreso)
        {
            if (id != ingreso.Id)
            {
                return BadRequest();
            }

            _context.Entry(ingreso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IngresoExists(id))
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

        // POST: api/Ingresos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ingreso>> PostIngreso(Ingreso ingreso)
        {
            _context.Ingresos.Add(ingreso);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIngreso", new { id = ingreso.Id }, ingreso);
        }

        // DELETE: api/Ingresos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIngreso(int id)
        {
            var ingreso = await _context.Ingresos.FindAsync(id);
            if (ingreso == null)
            {
                return NotFound();
            }

            _context.Ingresos.Remove(ingreso);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IngresoExists(int id)
        {
            return _context.Ingresos.Any(e => e.Id == id);
        }
    }
}
