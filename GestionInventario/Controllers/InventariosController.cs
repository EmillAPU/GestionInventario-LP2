using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestionInventario.Models;
using AutoMapper;
using GestionInventario.DTO.InventarioDTO;

namespace GestionInventario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventariosController : ControllerBase
    {
        private readonly GestionInventariosContext _context;
        private readonly IMapper mapper;

        public InventariosController(GestionInventariosContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        // GET: api/Inventarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InventarioGetDTO>>> GetInventarios()
        {
            var InventarioLista = await _context.Inventarios.ToListAsync();
            var InventariosDTO = mapper.Map<IEnumerable<InventarioGetDTO>>(InventarioLista);
            return Ok(InventariosDTO);
        }

        // GET: api/Inventarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InventarioGetDTO>> GetInventario(int id)
        {
            var inventario = await _context.Inventarios.FindAsync(id);

            if (inventario == null)
            {
                return NotFound();
            }
            var inventarioDTO = mapper.Map<InventarioGetDTO>(inventario);

            return inventarioDTO;
        }

        // PUT: api/Inventarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInventario(int id, InventarioPutDTO inventarioDTO)
        {
            if (id != inventarioDTO.Id)
            {
                return BadRequest();
            }

            var inventario = mapper.Map<Inventario>(inventarioDTO);
            _context.Entry(inventario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InventarioExists(id))
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

        // POST: api/Inventarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Inventario>> PostInventario(InventarioInsertDTO inventarioDTO)
        {
            var inventario = mapper.Map<Inventario>(inventarioDTO);
            _context.Inventarios.Add(inventario);
            await _context.SaveChangesAsync();

            return Ok(inventario.Id);
        }

        // DELETE: api/Inventarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInventario(int id)
        {
            var inventario = await _context.Inventarios.FindAsync(id);
            if (inventario == null)
            {
                return NotFound();
            }

            _context.Inventarios.Remove(inventario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InventarioExists(int id)
        {
            return _context.Inventarios.Any(e => e.Id == id);
        }
    }
}
