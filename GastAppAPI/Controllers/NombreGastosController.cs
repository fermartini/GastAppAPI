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
    public class NombreGastosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public NombreGastosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/NombreGastos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NombreGasto>>> GetNombreGastos()
        {
            return await _context.NombreGastos.ToListAsync();
        }

        // GET: api/NombreGastos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NombreGasto>> GetNombreGasto(int id)
        {
            var nombreGasto = await _context.NombreGastos.FindAsync(id);

            if (nombreGasto == null)
            {
                return NotFound();
            }

            return nombreGasto;
        }

        // PUT: api/NombreGastos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNombreGasto(int id, NombreGasto nombreGasto)
        {
            if (id != nombreGasto.Id)
            {
                return BadRequest();
            }

            _context.Entry(nombreGasto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NombreGastoExists(id))
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

        // POST: api/NombreGastos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NombreGasto>> PostNombreGasto(NombreGasto nombreGasto)
        {
            _context.NombreGastos.Add(nombreGasto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNombreGasto", new { id = nombreGasto.Id }, nombreGasto);
        }

        // DELETE: api/NombreGastos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNombreGasto(int id)
        {
            var nombreGasto = await _context.NombreGastos.FindAsync(id);
            if (nombreGasto == null)
            {
                return NotFound();
            }

            _context.NombreGastos.Remove(nombreGasto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NombreGastoExists(int id)
        {
            return _context.NombreGastos.Any(e => e.Id == id);
        }
    }
}
