using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RADER.Models;
using RADER.ModelsViews;

namespace RADER.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MantenimientoesController : ControllerBase
    {
        private readonly RaderContext _context;

        public MantenimientoesController(RaderContext context)
        {
            _context = context;
        }

        // GET: api/Mantenimientoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MantenimientoMV>>> GetMantenimientos()
        {

            var query = from man in _context.Mantenimientos
                        join enc in _context.Encargados on man.EncargadoM equals enc.IdEncargado
                        join dis in _context.Dispositivos on man.DispositivoM equals dis.IdDispositivo
                        select new MantenimientoMV
                        {
                            IdMantenimiento = man.IdMantenimiento,

                            EstadoM = man.EstadoM,

                            FechaRevisionM = man.FechaRevisionM,

                            DescripcionM = man.DescripcionM,

                            EncargadoM = enc.PersonaEnc,

                            DispositivoM = dis.IdDispositivo,

                            NombreD = dis.NombreD,




                        };
            return await query.ToListAsync();
        }

        // GET: api/Mantenimientoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mantenimiento>> GetMantenimiento(int id)
        {
          if (_context.Mantenimientos == null)
          {
              return NotFound();
          }
            var mantenimiento = await _context.Mantenimientos.FindAsync(id);

            if (mantenimiento == null)
            {
                return NotFound();
            }

            return mantenimiento;
        }

        // PUT: api/Mantenimientoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMantenimiento(int id, Mantenimiento mantenimiento)
        {
            if (id != mantenimiento.IdMantenimiento)
            {
                return BadRequest();
            }

            _context.Entry(mantenimiento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MantenimientoExists(id))
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

        // POST: api/Mantenimientoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Mantenimiento>> PostMantenimiento(Mantenimiento mantenimiento)
        {
          if (_context.Mantenimientos == null)
          {
              return Problem("Entity set 'RaderContext.Mantenimientos'  is null.");
          }
            _context.Mantenimientos.Add(mantenimiento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMantenimiento", new { id = mantenimiento.IdMantenimiento }, mantenimiento);
        }

        // DELETE: api/Mantenimientoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMantenimiento(int id)
        {
            if (_context.Mantenimientos == null)
            {
                return NotFound();
            }
            var mantenimiento = await _context.Mantenimientos.FindAsync(id);
            if (mantenimiento == null)
            {
                return NotFound();
            }

            _context.Mantenimientos.Remove(mantenimiento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MantenimientoExists(int id)
        {
            return (_context.Mantenimientos?.Any(e => e.IdMantenimiento == id)).GetValueOrDefault();
        }
    }
}
