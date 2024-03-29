﻿using System;
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
    public class PermisoesController : ControllerBase
    {
        private readonly RaderContext _context;

        public PermisoesController(RaderContext context)
        {
            _context = context;
        }

        // GET: api/Permisoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Permiso>>> GetPermisos()
        {
          if (_context.Permisos == null)
          {
              return NotFound();
          }
            return await _context.Permisos.ToListAsync();
        }

        // GET: api/Permisoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Permiso>> GetPermiso(int id)
        {
          if (_context.Permisos == null)
          {
              return NotFound();
          }
            var permiso = await _context.Permisos.FindAsync(id);

            if (permiso == null)
            {
                return NotFound();
            }

            return permiso;
        }

        // PUT: api/Permisoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPermiso(int id, Permiso permiso)
        {
            if (id != permiso.IdPermiso)
            {
                return BadRequest();
            }

            _context.Entry(permiso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PermisoExists(id))
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

        // POST: api/Permisoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Permiso>> PostPermiso(Permiso permiso)
        {
          if (_context.Permisos == null)
          {
              return Problem("Entity set 'RaderContext.Permisos'  is null.");
          }
            _context.Permisos.Add(permiso);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PermisoExists(permiso.IdPermiso))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPermiso", new { id = permiso.IdPermiso }, permiso);
        }

        // DELETE: api/Permisoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePermiso(int id)
        {
            if (_context.Permisos == null)
            {
                return NotFound();
            }
            var permiso = await _context.Permisos.FindAsync(id);
            if (permiso == null)
            {
                return NotFound();
            }

            _context.Permisos.Remove(permiso);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PermisoExists(int id)
        {
            return (_context.Permisos?.Any(e => e.IdPermiso == id)).GetValueOrDefault();
        }
    }
}
