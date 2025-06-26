using ApiOcorrenciaApi.Data;
using ApiOcorrenciaApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiOcorrenciaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OcorrenciaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OcorrenciaController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ocorrencia
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ocorrencia>>> Listar()
        {
            return await _context.Ocorrencias.ToListAsync();
        }

        // GET: api/ocorrencia/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ocorrencia>> Consultar(int id)
        {
            var ocorrencia = await _context.Ocorrencias.FindAsync(id);

            if (ocorrencia == null)
            {
                return NotFound();
            }

            return ocorrencia;
        }

        // POST: api/ocorrencia
        [HttpPost]
        public async Task<ActionResult<Ocorrencia>> Inserir(Ocorrencia ocorrencia)
        {
            _context.Ocorrencias.Add(ocorrencia);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Consultar), new { id = ocorrencia.idOcorrencia }, ocorrencia);
        }

        // PUT: api/ocorrencia/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Finalizar(int id, Ocorrencia ocorrencia)
        {
            if (id != ocorrencia.idOcorrencia)
            {
                return BadRequest();
            }

            _context.Entry(ocorrencia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OcorrenciaExists(id))
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

        // DELETE: api/ocorrencia/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(int id)
        {
            var ocorrencia = await _context.Ocorrencias.FindAsync(id);
            if (ocorrencia == null)
            {
                return NotFound();
            }

            _context.Ocorrencias.Remove(ocorrencia);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OcorrenciaExists(int id)
        {
            return _context.Ocorrencias.Any(e => e.idOcorrencia == id);
        }
    }
}