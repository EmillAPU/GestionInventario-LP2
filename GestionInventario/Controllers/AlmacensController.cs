using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestionInventario.Models;
using AutoMapper;
using GestionInventario.Share.DTO.AlmacenDTO;

namespace GestionInventario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlmacensController : ControllerBase
    {
        private readonly GestionInventariosContext _context;
        private readonly IMapper mapper;

        public AlmacensController(GestionInventariosContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        // GET: api/Almacens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlmacenGetDTO>>> GetAlmacens()
        {
            var AlmacenLista = await _context.Almacens.ToListAsync();
            var AlmacensDTO = mapper.Map<IEnumerable<AlmacenGetDTO>>(AlmacenLista);
            return Ok(AlmacensDTO);
        }

        // GET: api/Almacens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AlmacenGetDTO>> GetAlmacen(int id)
        {
            var almacen = await _context.Almacens.FindAsync(id);

            if (almacen == null)
            {
                return NotFound();
            }
            var almacenDTO = mapper.Map<AlmacenGetDTO>(almacen);

            return almacenDTO;
        }

        // PUT: api/Almacens/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlmacen(int id, AlmacenPutDTO almacenDTO)
        {
            if (id != almacenDTO.Id)
            {
                return BadRequest();
            }

            var almacen = mapper.Map<Almacen>(almacenDTO);
            _context.Entry(almacen).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlmacenExists(id))
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

        // POST: api/Almacens
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Almacen>> PostAlmacen(AlmacenInsertDTO almacenDTO)
        {
            var almacen = mapper.Map<Almacen>(almacenDTO);
            _context.Almacens.Add(almacen);
            await _context.SaveChangesAsync();

            return Ok(almacen.Id);
        }

        // DELETE: api/Almacens/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlmacen(int id)
        {
            var almacen = await _context.Almacens.FindAsync(id);
            if (almacen == null)
            {
                return NotFound();
            }

            _context.Almacens.Remove(almacen);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AlmacenExists(int id)
        {
            return _context.Almacens.Any(e => e.Id == id);
        }
    }
}
