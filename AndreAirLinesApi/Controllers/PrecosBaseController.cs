using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AndreAirLinesApi.Data;
using AndreAirLinesApi.Model;

namespace AndreAirLinesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrecosBaseController : ControllerBase
    {
        private readonly AndreAirLinesApiContext _context;

        public PrecosBaseController(AndreAirLinesApiContext context)
        {
            _context = context;
        }

        // GET: api/PrecosBase
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PrecoBase>>> GetPrecoBase()
        {
            return await _context.PrecoBase
                .Include(e => e.Origem)
                .Include(e => e.Destino)
                .Include(e => e.Classe)
                .ToListAsync();
        }

        // GET: api/PrecosBase/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PrecoBase>> GetPrecoBase(int id)
        {
            var precoBase = await _context.PrecoBase
                .Include(e => e.Origem)
                .Include(e => e.Destino)
                .Include(e => e.Classe)
                .Where(e => e.Id == id)
                .FirstOrDefaultAsync();

            if (precoBase == null)
            {
                return NotFound();
            }

            return precoBase;
        }

        // PUT: api/PrecosBase/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrecoBase(int id, PrecoBase precoBase)
        {
            if (id != precoBase.Id)
            {
                return BadRequest();
            }

            _context.Entry(precoBase).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrecoBaseExists(id))
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

        // POST: api/PrecosBase
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PrecoBase>> PostPrecoBase(PrecoBase precoBase)
        {
            
            var origem = await _context.Aeroporto.FindAsync(precoBase.Origem.Sigla);
            var destino = await _context.Aeroporto.FindAsync(precoBase.Destino.Sigla);
            var classe = await _context.Classe.FindAsync(precoBase.Classe.Id);
            if (origem != null) { precoBase.Origem = origem; }
            if (destino != null) { precoBase.Destino = destino; }
            if (classe != null) { precoBase.Classe = classe; }
            _context.PrecoBase.Add(precoBase);
            await _context.SaveChangesAsync();            
            return CreatedAtAction("GetPrecoBase", new { id = precoBase.Id }, precoBase);
        }

        // DELETE: api/PrecosBase/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrecoBase(int id)
        {
            var precoBase = await _context.PrecoBase.FindAsync(id);
            if (precoBase == null)
            {
                return NotFound();
            }

            _context.PrecoBase.Remove(precoBase);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PrecoBaseExists(int id)
        {
            return _context.PrecoBase.Any(e => e.Id == id);
        }
    }
}
