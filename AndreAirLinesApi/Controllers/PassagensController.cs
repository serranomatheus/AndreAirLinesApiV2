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
    public class PassagensController : ControllerBase
    {
        private readonly AndreAirLinesApiContext _context;

        public PassagensController(AndreAirLinesApiContext context)
        {
            _context = context;
        }

        // GET: api/Passagens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Passagem>>> GetPassagem()
        {
            return await _context.Passagem
                .Include(e => e.Voo)
                .Include(e => e.Passageiro)
                .Include(e => e.Classe)
                .ToListAsync();
        }

        // GET: api/Passagens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Passagem>> GetPassagem(int id)
        {
            var passagem = await _context.Passagem
                 .Include(e => e.Voo)
                 .Include(e => e.Passageiro)
                 .Include(e => e.Classe)
                 .Where(e => e.Id == id)
                 .FirstOrDefaultAsync();

            if (passagem == null)
            {
                return NotFound();
            }

            return passagem;
        }

        // PUT: api/Passagens/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPassagem(int id, Passagem passagem)
        {
            if (id != passagem.Id)
            {
                return BadRequest();
            }

            _context.Entry(passagem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PassagemExists(id))
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

        // POST: api/Passagens
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Passagem>> PostPassagem(Passagem passagem)
        {

            var voo = await _context.Voo.Include(e => e.Origem)
                                        .Include(e => e.Destino)
                                        .Where(d => d.Id == passagem.Voo.Id).FirstOrDefaultAsync();
            if (voo != null) { passagem.Voo = voo; }

            var passageiro = await _context.Passageiro.FindAsync(passagem.Passageiro.Cpf);

            var classe = await _context.Classe.FindAsync(passagem.Classe.Id);
            
            
            var precoBase = await _context.PrecoBase.Where(x => x.Origem.Sigla == passagem.Voo.Origem.Sigla && x.Destino.Sigla == passagem.Voo.Destino.Sigla && x.Classe == passagem.Classe).FirstOrDefaultAsync();
            passagem.Valor = (precoBase.Valor - ((precoBase.Valor * precoBase.PromocaoPorcentagem) / 100));
            
            if (passageiro != null) { passagem.Passageiro = passageiro; }
            if (classe != null) { passagem.Classe = classe; }
          
            _context.Passagem.Add(passagem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPassagem", new { id = passagem.Id }, passagem);
        }

        // DELETE: api/Passagens/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePassagem(int id)
        {
            var passagem = await _context.Passagem.FindAsync(id);
            if (passagem == null)
            {
                return NotFound();
            }

            _context.Passagem.Remove(passagem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PassagemExists(int id)
        {
            return _context.Passagem.Any(e => e.Id == id);
        }
    }
}
