using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RADER.Models;
using RADER.ModelsViews;

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
        public async Task<ActionResult<IEnumerable<SolicitudMV>>> GetSolicituds()
        {
            var query = from sol in _context.Solicituds
                        join usu in _context.Usuarios on sol.UsuarioS equals usu.IdUsuario
                        join dis in _context.Dispositivos on sol.DispositivoS equals dis.IdDispositivo
                        select new SolicitudMV
                        {
                            IdSolicitud = sol.IdSolicitud,
                            TipoS = sol.TipoS,
                            DescripcionS = sol.DescripcionS,
                            UsuarioS = usu.IdUsuario,
                            NombreU = usu.NombreU,
                            DispositivoS = dis.IdDispositivo,
                            NombreD = dis.NombreD,


                        };

            return await query.ToListAsync();
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
