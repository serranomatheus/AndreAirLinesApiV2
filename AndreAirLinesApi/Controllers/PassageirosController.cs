using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AndreAirLinesApi.Data;
using AndreAirLinesApi.Model;
using AndreAirLinesApi.Service;

namespace AndreAirLinesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassageirosController : ControllerBase
    {
        private readonly AndreAirLinesApiContext _context;

        public PassageirosController(AndreAirLinesApiContext context)
        {
            _context = context;
        }

        // GET: api/Passageiros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Passageiro>>> GetPassageiro()
        {
            return await _context.Passageiro.Include(E => E.Endereco).ToListAsync();
        }

        // GET: api/Passageiros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Passageiro>> GetPassageiro(string id)
        {
            var passageiro = await _context.Passageiro
                            .Include(e => e.Endereco)
                            .Where(d => d.Cpf == id).FirstOrDefaultAsync();

            if (passageiro == null)
            {
                return NotFound();
            }

            return passageiro;
        }

        // PUT: api/Passageiros/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPassageiro(string id, Passageiro passageiro)
        {
            if (id != passageiro.Cpf)
            {
                return BadRequest();
            }

            _context.Entry(passageiro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PassageiroExists(id))
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

        // POST: api/Passageiros
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Passageiro>> PostPassageiro(Passageiro passageiro)
        {
            var endereco = await _context.Endereco.FindAsync(passageiro.Endereco.Id);
            if (endereco != null) { passageiro.Endereco = endereco; }

            if (passageiro.Endereco.Id == 0)
            {
                var enderecoApi = await ApiCep.BuscarEnderecoApi(passageiro.Endereco.CEP);
                passageiro.Endereco = new Endereco(enderecoApi.Bairro, enderecoApi.Cidade, enderecoApi.Logradouro, enderecoApi.Estado, enderecoApi.Complemento, passageiro.Endereco.Numero);
            }

            _context.Passageiro.Add(passageiro);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PassageiroExists(passageiro.Cpf))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPassageiro", new { id = passageiro.Cpf }, passageiro);
        }

        // DELETE: api/Passageiros/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePassageiro(string id)
        {
            var passageiro = await _context.Passageiro.FindAsync(id);
            if (passageiro == null)
            {
                return NotFound();
            }

            _context.Passageiro.Remove(passageiro);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PassageiroExists(string id)
        {
            return _context.Passageiro.Any(e => e.Cpf == id);
        }
    }
}
