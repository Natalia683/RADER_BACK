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
    public class SolicitudsController : ControllerBase
    {
        private readonly RaderContext _context;

        public SolicitudsController(RaderContext context)
        {
            _context = context;
        }

        // GET: api/Solicituds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Solicitud>>> GetSolicituds()
        {
            return await _context.Solicituds.ToListAsync();
        }

        // GET: api/Solicituds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Solicitud>> GetSolicitud(int id)
        {
            var solicitud = await _context.Solicituds.FindAsync(id);

            if (solicitud == null)
            {
                return NotFound();
            }

            return solicitud;
        }

        // PUT: api/Solicituds/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSolicitud(int id, Solicitud solicitud)
        {
            if (id != solicitud.IdSolicitud)
            {
                return BadRequest();
            }

            _context.Entry(solicitud).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SolicitudExists(id))
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

        // POST: api/Solicituds
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Solicitud>> PostSolicitud(Solicitud solicitud)
        {
            _context.Solicituds.Add(solicitud);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SolicitudExists(solicitud.IdSolicitud))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSolicitud", new { id = solicitud.IdSolicitud }, solicitud);
        }

        // DELETE: api/Solicituds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSolicitud(int id)
        {
            var solicitud = await _context.Solicituds.FindAsync(id);
            if (solicitud == null)
            {
                return NotFound();
            }

            _context.Solicituds.Remove(solicitud);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SolicitudExists(int id)
        {
            return _context.Solicituds.Any(e => e.IdSolicitud == id);
        }
    }
}
