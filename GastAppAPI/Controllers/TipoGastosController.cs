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
    public class TipoGastosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TipoGastosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/TipoGastos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoGasto>>> GetTipoGastos()
        {
            return await _context.TipoGastos.ToListAsync();
        }

        // GET: api/TipoGastos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoGasto>> GetTipoGasto(int id)
        {
            var tipoGasto = await _context.TipoGastos.FindAsync(id);

            if (tipoGasto == null)
            {
                return NotFound();
            }

            return tipoGasto;
        }

        // PUT: api/TipoGastos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoGasto(int id, TipoGasto tipoGasto)
        {
            if (id != tipoGasto.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipoGasto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoGastoExists(id))
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

        // POST: api/TipoGastos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoGasto>> PostTipoGasto(TipoGasto tipoGasto)
        {
            _context.TipoGastos.Add(tipoGasto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoGasto", new { id = tipoGasto.Id }, tipoGasto);
        }

        // DELETE: api/TipoGastos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoGasto(int id)
        {
            var tipoGasto = await _context.TipoGastos.FindAsync(id);
            if (tipoGasto == null)
            {
                return NotFound();
            }

            _context.TipoGastos.Remove(tipoGasto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoGastoExists(int id)
        {
            return _context.TipoGastos.Any(e => e.Id == id);
        }
    }
}
