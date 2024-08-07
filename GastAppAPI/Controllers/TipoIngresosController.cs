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
    public class TipoIngresosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TipoIngresosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/TipoIngresos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoIngreso>>> GetTipoIngresos()
        {
            return await _context.TipoIngresos.ToListAsync();
        }

        // GET: api/TipoIngresos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoIngreso>> GetTipoIngreso(int id)
        {
            var tipoIngreso = await _context.TipoIngresos.FindAsync(id);

            if (tipoIngreso == null)
            {
                return NotFound();
            }

            return tipoIngreso;
        }

        // PUT: api/TipoIngresos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoIngreso(int id, TipoIngreso tipoIngreso)
        {
            if (id != tipoIngreso.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipoIngreso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoIngresoExists(id))
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

        // POST: api/TipoIngresos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoIngreso>> PostTipoIngreso(TipoIngreso tipoIngreso)
        {
            _context.TipoIngresos.Add(tipoIngreso);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoIngreso", new { id = tipoIngreso.Id }, tipoIngreso);
        }

        // DELETE: api/TipoIngresos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoIngreso(int id)
        {
            var tipoIngreso = await _context.TipoIngresos.FindAsync(id);
            if (tipoIngreso == null)
            {
                return NotFound();
            }

            _context.TipoIngresos.Remove(tipoIngreso);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoIngresoExists(int id)
        {
            return _context.TipoIngresos.Any(e => e.Id == id);
        }
    }
}
