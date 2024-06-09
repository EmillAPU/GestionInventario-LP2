using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestionInventario.Models;
using AutoMapper;
using GestionInventario.DTO.CategoriumDTO;

namespace GestionInventario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriumsController : ControllerBase
    {
        private readonly GestionInventariosContext _context;
        private readonly IMapper mapper;

        public CategoriumsController(GestionInventariosContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        // GET: api/Categoriums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriumGetDTO>>> GetCategoria()
        {
            var CategoriaLista = await _context.Categoria.ToListAsync();
            var CategoriaDTO = mapper.Map<IEnumerable<CategoriumGetDTO>>(CategoriaLista);
            return Ok(CategoriaDTO);
        }

        // GET: api/Categoriums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriumGetDTO>> GetCategorium(int id)
        {
            var categorium = await _context.Categoria.FindAsync(id);

            if (categorium == null)
            {
                return NotFound();
            }
            var categoriaDTO = mapper.Map<CategoriumGetDTO>(categorium);

            return categoriaDTO;
        }

        // PUT: api/Categoriums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategorium(int id, CategoriumPutDTO categoriaDTO)
        {
            if (id != categoriaDTO.Id)
            {
                return BadRequest();
            }

            var categorium = mapper.Map<Categorium>(categoriaDTO);
            _context.Entry(categorium).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriumExists(id))
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

        // POST: api/Categoriums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Categorium>> PostCategorium(CategoriumInsertDTO categoriaDTO)
        {
            var categorium = mapper.Map<Categorium>(categoriaDTO);
            _context.Categoria.Add(categorium);
            await _context.SaveChangesAsync();

            return Ok(categorium.Id);
        }

        // DELETE: api/Categoriums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategorium(int id)
        {
            var categorium = await _context.Categoria.FindAsync(id);
            if (categorium == null)
            {
                return NotFound();
            }

            _context.Categoria.Remove(categorium);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoriumExists(int id)
        {
            return _context.Categoria.Any(e => e.Id == id);
        }
    }
}
