using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestionInventario.Models;
using AutoMapper;
using GestionInventario.DTO.SalidumDTO;

namespace GestionInventario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalidumsController : ControllerBase
    {
        private readonly GestionInventariosContext _context;
        private readonly IMapper mapper;

        public SalidumsController(GestionInventariosContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        // GET: api/Salidums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalidumGetDTO>>> GetSalida()
        {
            var SalidaLista = await _context.Salida.ToListAsync();
            var SalidaDTO = mapper.Map<IEnumerable<SalidumGetDTO>>(SalidaLista);
            return Ok(SalidaDTO);
        }

        // GET: api/Salidums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SalidumGetDTO>> GetSalidum(int id)
        {
            var salidum = await _context.Salida.FindAsync(id);

            if (salidum == null)
            {
                return NotFound();
            }
            var salidaDTO = mapper.Map<SalidumGetDTO>(salidum);

            return salidaDTO;
        }

        // PUT: api/Salidums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalidum(int id, SalidumPutDTO salidaDTO)
        {
            if (id != salidaDTO.Id)
            {
                return BadRequest();
            }

            var salidum = mapper.Map<Salidum>(salidaDTO);
            _context.Entry(salidum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalidumExists(id))
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

        // POST: api/Salidums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Salidum>> PostSalidum(SalidumInsertDTO salidaDTO)
        {
            var salidum = mapper.Map<Salidum>(salidaDTO);
            _context.Salida.Add(salidum);
            await _context.SaveChangesAsync();

            return Ok(salidum.Id);
        }

        // DELETE: api/Salidums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalidum(int id)
        {
            var salidum = await _context.Salida.FindAsync(id);
            if (salidum == null)
            {
                return NotFound();
            }

            _context.Salida.Remove(salidum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SalidumExists(int id)
        {
            return _context.Salida.Any(e => e.Id == id);
        }
    }
}
