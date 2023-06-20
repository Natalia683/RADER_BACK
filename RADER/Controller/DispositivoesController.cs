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
    public class DispositivoesController : ControllerBase
    {
        private readonly RaderContext _context;

        public DispositivoesController(RaderContext context)
        {
            _context = context;
        }

        // GET: api/Dispositivoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DispositivosMV>>> GetDispositivos()
        {

            var query = from dis in _context.Dispositivos
                        join emp in _context.Empresas on dis.EmpresaD equals emp.IdEmpresa
                        select new DispositivosMV
                        {
                            IdDispositivo = dis.IdDispositivo,
                            NombreD = dis.NombreD,
                            LargoD = dis.LargoD,
                            AltoD = dis.AltoD,
                            AnchoD = dis.AnchoD,
                            PesoD = dis.PesoD,
                            EmpresaD = dis.EmpresaD,
                            NombreE = emp.NombreE,
                            NitE = emp.NitE,
                        };
            return await query.ToListAsync();
        }


        // GET: api/Dispositivoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dispositivo>> GetDispositivo(int id)
        {
          if (_context.Dispositivos == null)
          {
              return NotFound();
          }
            var dispositivo = await _context.Dispositivos.FindAsync(id);

            if (dispositivo == null)
            {
                return NotFound();
            }

            return dispositivo;
        }

        // PUT: api/Dispositivoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDispositivo(int id, Dispositivo dispositivo)
        {
            if (id != dispositivo.IdDispositivo)
            {
                return BadRequest();
            }

            _context.Entry(dispositivo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DispositivoExists(id))
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

        // POST: api/Dispositivoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Dispositivo>> PostDispositivo(Dispositivo dispositivo)
        {
          if (_context.Dispositivos == null)
          {
              return Problem("Entity set 'RaderContext.Dispositivos'  is null.");
          }
            _context.Dispositivos.Add(dispositivo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDispositivo", new { id = dispositivo.IdDispositivo }, dispositivo);
        }

        // DELETE: api/Dispositivoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDispositivo(int id)
        {
            if (_context.Dispositivos == null)
            {
                return NotFound();
            }
            var dispositivo = await _context.Dispositivos.FindAsync(id);
            if (dispositivo == null)
            {
                return NotFound();
            }

            _context.Dispositivos.Remove(dispositivo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DispositivoExists(int id)
        {
            return (_context.Dispositivos?.Any(e => e.IdDispositivo == id)).GetValueOrDefault();
        }
    }
}
