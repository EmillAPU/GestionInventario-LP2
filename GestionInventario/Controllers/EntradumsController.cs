using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestionInventario.Models;
using AutoMapper;
using GestionInventario.DTO.EntradumDTO;

namespace GestionInventario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntradumsController : ControllerBase
    {
        private readonly GestionInventariosContext _context;
        private readonly IMapper mapper;

        public EntradumsController(GestionInventariosContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        // GET: api/Entradums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EntradumGetDTO>>> GetEntrada()
        {
            var EntradaLista = await _context.Entrada.ToListAsync();
            var EntradaDTO = mapper.Map<IEnumerable<EntradumGetDTO>>(EntradaLista);
            return Ok(EntradaDTO);
        }

        // GET: api/Entradums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EntradumGetDTO>> GetEntradum(int id)
        {
            var entradum = await _context.Entrada.FindAsync(id);

            if (entradum == null)
            {
                return NotFound();
            }
            var entradaDTO = mapper.Map<EntradumGetDTO>(entradum);

            return entradaDTO;
        }

        // PUT: api/Entradums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEntradum(int id, EntradumPutDTO entradaDTO)
        {
            if (id != entradaDTO.Id)
            {
                return BadRequest();
            }

            var entradum = mapper.Map<Entradum>(entradaDTO);
            _context.Entry(entradum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntradumExists(id))
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

        // POST: api/Entradums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Entradum>> PostEntradum(EntradumInsertDTO entradaDTO)
        {
            var entradum = mapper.Map<Entradum>(entradaDTO);
            _context.Entrada.Add(entradum);
            await _context.SaveChangesAsync();

            return Ok(entradum.Id);
        }

        // DELETE: api/Entradums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntradum(int id)
        {
            var entradum = await _context.Entrada.FindAsync(id);
            if (entradum == null)
            {
                return NotFound();
            }

            _context.Entrada.Remove(entradum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EntradumExists(int id)
        {
            return _context.Entrada.Any(e => e.Id == id);
        }
    }
}
