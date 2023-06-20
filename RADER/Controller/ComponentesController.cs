using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RADER.Models;

namespace RADER.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComponentesController : ControllerBase
    {
        private readonly RaderContext _context;

        public ComponentesController(RaderContext context)
        {
            _context = context;
        }

        // GET: api/Componentes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Componente>>> GetComponentes()
        {
          if (_context.Componentes == null)
          {
              return NotFound();
          }
            return await _context.Componentes.ToListAsync();
        }

        // GET: api/Componentes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Componente>> GetComponente(int id)
        {
          if (_context.Componentes == null)
          {
              return NotFound();
          }
            var componente = await _context.Componentes.FindAsync(id);

            if (componente == null)
            {
                return NotFound();
            }

            return componente;
        }

        // PUT: api/Componentes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComponente(int id, Componente componente)
        {
            if (id != componente.IdComponente)
            {
                return BadRequest();
            }

            _context.Entry(componente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComponenteExists(id))
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

        // POST: api/Componentes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Componente>> PostComponente(Componente componente)
        {
          if (_context.Componentes == null)
          {
              return Problem("Entity set 'RaderContext.Componentes'  is null.");
          }
            _context.Componentes.Add(componente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComponente", new { id = componente.IdComponente }, componente);
        }

        // DELETE: api/Componentes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComponente(int id)
        {
            if (_context.Componentes == null)
            {
                return NotFound();
            }
            var componente = await _context.Componentes.FindAsync(id);
            if (componente == null)
            {
                return NotFound();
            }

            _context.Componentes.Remove(componente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ComponenteExists(int id)
        {
            return (_context.Componentes?.Any(e => e.IdComponente == id)).GetValueOrDefault();
        }
    }
}
