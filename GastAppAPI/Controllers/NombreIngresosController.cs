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
    public class NombreIngresosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public NombreIngresosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/NombreIngresos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NombreIngreso>>> GetNombreIngresos()
        {
            return await _context.NombreIngresos.ToListAsync();
        }

        // GET: api/NombreIngresos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NombreIngreso>> GetNombreIngreso(int id)
        {
            var nombreIngreso = await _context.NombreIngresos.FindAsync(id);

            if (nombreIngreso == null)
            {
                return NotFound();
            }

            return nombreIngreso;
        }

        // PUT: api/NombreIngresos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNombreIngreso(int id, NombreIngreso nombreIngreso)
        {
            if (id != nombreIngreso.Id)
            {
                return BadRequest();
            }

            _context.Entry(nombreIngreso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NombreIngresoExists(id))
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

        // POST: api/NombreIngresos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NombreIngreso>> PostNombreIngreso(NombreIngreso nombreIngreso)
        {
            _context.NombreIngresos.Add(nombreIngreso);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNombreIngreso", new { id = nombreIngreso.Id }, nombreIngreso);
        }

        // DELETE: api/NombreIngresos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNombreIngreso(int id)
        {
            var nombreIngreso = await _context.NombreIngresos.FindAsync(id);
            if (nombreIngreso == null)
            {
                return NotFound();
            }

            _context.NombreIngresos.Remove(nombreIngreso);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NombreIngresoExists(int id)
        {
            return _context.NombreIngresos.Any(e => e.Id == id);
        }
    }
}
