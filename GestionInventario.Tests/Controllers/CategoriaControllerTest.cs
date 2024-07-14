using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestionInventario.Controllers;
using GestionInventario.DTO;
using GestionInventario.Share.DTO;
using GestionInventario.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using GestionInventario.Share.DTO.CategoriumDTO;

namespace GestionInventario.UnitTest
{
    public class CategoriaControllerTest
    {
        private CategoriumsController _controller;
        private DbTestFixture<GestionInventariosContext> _fixture;

        public CategoriaControllerTest()
        {
            _fixture = new DbTestFixture<GestionInventariosContext>();
            _controller = new CategoriumsController(_fixture.Context, _fixture.Mapper);
        }

        [Fact]
        public void Setup()
        {
            var categorias = new List<Categorium>
            {
                new Categorium { Nombre = "Categoría A" },
                new Categorium { Nombre = "Categoría B" }
            };
            _fixture.Context.Categoria.AddRange(categorias);
            _fixture.Context.SaveChanges();
        }

        

        [Fact]
        public async Task PostCategoria_ReturnsOkResult_WithValidData()
        {
            // Arrange
            Setup();
            var categoriaDto = new CategoriumInsertDTO { Nombre = "Categoría C" };

            // Act
            var result = await _controller.PostCategorium(categoriaDto);

            // Assert
            var okResult = Xunit.Assert.IsType<OkObjectResult>(result.Result);
            Xunit.Assert.IsType<int>(okResult.Value);
        }

        [Fact]
        public async Task PutCategoria_ReturnsNoContent_WithValidId()
        {
            // Arrange
            Setup();
            var categoriaInsertDto = new CategoriumInsertDTO { Nombre = "Categoría D"};
            await _controller.PostCategorium(categoriaInsertDto);

            // Desatachar la entidad que se acaba de insertar para evitar conflictos
            var insertedCategoria = _fixture.Context.Categoria.Local.FirstOrDefault(c => c.Nombre == "Categoría D");
            if (insertedCategoria != null)
            {
                _fixture.Context.Entry(insertedCategoria).State = EntityState.Detached;
            }

            var categoriaDto = new CategoriumPutDTO { Id = insertedCategoria.Id, Nombre = "Categoría Modificada" };

            // Act
            var result = await _controller.PutCategorium(insertedCategoria.Id, categoriaDto);

            // Assert
            Xunit.Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DeleteCategoria_ReturnsNoContent_WithValidId()
        {
            // Arrange
            Setup();
            var categoria = _fixture.Context.Categoria.First(); // Obtener la primera categoría para borrar

            // Act
            var result = await _controller.DeleteCategorium(categoria.Id);

            // Assert
            Xunit.Assert.IsType<NoContentResult>(result);
        }
    }
}
