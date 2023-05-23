using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RADER.Models;
using RADER.ModelsViews;

namespace RADER.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistorialsController : ControllerBase
    {
        private readonly RaderContext _context;

        public HistorialsController(RaderContext context)
        {
            _context = context;
        }

        // GET: api/Historials
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HistorialMV>>> GetHistorials()
        { var query = from his in _context.Historials
                      join usu in _context.Usuarios on his.UsuarioH equals usu.IdUsuario
                      join com in _context.Componentes on his.ComponenteH equals com.IdComponente
                      select new HistorialMV
                      {
                          IdHistorial= his.IdHistorial, 
                          FechaH= his.FechaH, 
                          NovedadH= his.NovedadH,
                          SugerenciaUsuarioH= his.SugerenciaUsuarioH, 
                          IncidenciasH= his.IncidenciasH,
                          ComponenteH= com.IdComponente, 
                          NombreC=com.NombreC, 
                          UsuarioH=usu.IdUsuario, 
                          NombreU =usu.NombreU,

    };

            return await query.ToArrayAsync();
        }

        // GET: api/Historials/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Historial>> GetHistorial(int id)
        {
            var historial = await _context.Historials.FindAsync(id);

            if (historial == null)
            {
                return NotFound();
            }

            return historial;
        }

        // PUT: api/Historials/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHistorial(int id, Historial historial)
        {
            if (id != historial.IdHistorial)
            {
                return BadRequest();
            }

            _context.Entry(historial).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistorialExists(id))
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

        // POST: api/Historials
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Historial>> PostHistorial(Historial historial)
        {
            _context.Historials.Add(historial);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HistorialExists(historial.IdHistorial))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetHistorial", new { id = historial.IdHistorial }, historial);
        }

        // DELETE: api/Historials/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHistorial(int id)
        {
            var historial = await _context.Historials.FindAsync(id);
            if (historial == null)
            {
                return NotFound();
            }

            _context.Historials.Remove(historial);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HistorialExists(int id)
        {
            return _context.Historials.Any(e => e.IdHistorial == id);
        }
    }
}
