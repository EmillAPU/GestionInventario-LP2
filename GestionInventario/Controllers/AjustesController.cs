using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestionInventario.Models;
using AutoMapper;
using GestionInventario.Share.DTO.AjusteDTO;

namespace GestionInventario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AjustesController : ControllerBase
    {
        private readonly GestionInventariosContext _context;
        private readonly IMapper mapper;

        public AjustesController(GestionInventariosContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        // GET: api/Ajustes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AjusteGetDTO>>> GetAjustes()
        {
            var ajusteLista = await _context.Ajustes.ToListAsync();
            var ajustesDTO = mapper.Map<IEnumerable<AjusteGetDTO>>(ajusteLista);
            return Ok(ajustesDTO);
        }

        // GET: api/Ajustes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AjusteGetDTO>> GetAjuste(int id)
        {
            var ajuste = await _context.Ajustes.FindAsync(id);

            if (ajuste == null)
            {
                return NotFound();
            }
            var ajusteDTO = mapper.Map<AjusteGetDTO>(ajuste);

            return ajusteDTO;
        }

        // PUT: api/Ajustes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAjuste(int id, AjustePutDTO ajusteDTO)
        {
            if (id != ajusteDTO.Id)
            {
                return BadRequest();
            }

            var ajuste = mapper.Map<Ajuste>(ajusteDTO);
            _context.Entry(ajuste).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AjusteExists(id))
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

        // POST: api/Ajustes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ajuste>> PostAjuste(AjusteInsertDTO ajusteDTO)
        {
            var ajuste = mapper.Map<Ajuste>(ajusteDTO);
            _context.Ajustes.Add(ajuste);
            await _context.SaveChangesAsync();

            return Ok(ajuste.Id);
        }

        // DELETE: api/Ajustes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAjuste(int id)
        {
            var ajuste = await _context.Ajustes.FindAsync(id);
            if (ajuste == null)
            {
                return NotFound();
            }

            _context.Ajustes.Remove(ajuste);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AjusteExists(int id)
        {
            return _context.Ajustes.Any(e => e.Id == id);
        }
    }
}
