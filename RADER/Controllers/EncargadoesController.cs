using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RADER.Models;

namespace RADER.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EncargadoesController : ControllerBase
    {
        private readonly RaderContext _context;

        public EncargadoesController(RaderContext context)
        {
            _context = context;
        }

        // GET: api/Encargadoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Encargado>>> GetEncargados()
        {
            return await _context.Encargados.ToListAsync();
        }

        // GET: api/Encargadoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Encargado>> GetEncargado(int id)
        {
            var encargado = await _context.Encargados.FindAsync(id);

            if (encargado == null)
            {
                return NotFound();
            }

            return encargado;
        }

        // PUT: api/Encargadoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEncargado(int id, Encargado encargado)
        {
            if (id != encargado.IdEncargado)
            {
                return BadRequest();
            }

            _context.Entry(encargado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EncargadoExists(id))
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

        // POST: api/Encargadoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Encargado>> PostEncargado(Encargado encargado)
        {
            _context.Encargados.Add(encargado);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EncargadoExists(encargado.IdEncargado))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEncargado", new { id = encargado.IdEncargado }, encargado);
        }

        // DELETE: api/Encargadoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEncargado(int id)
        {
            var encargado = await _context.Encargados.FindAsync(id);
            if (encargado == null)
            {
                return NotFound();
            }

            _context.Encargados.Remove(encargado);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EncargadoExists(int id)
        {
            return _context.Encargados.Any(e => e.IdEncargado == id);
        }
    }
}
