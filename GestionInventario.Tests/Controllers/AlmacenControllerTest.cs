using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestionInventario.Controllers;
using GestionInventario.Share.DTO.AlmacenDTO;
using GestionInventario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace GestionInventario.UnitTest
{
    public class AlmacenControllerTest
    {
        private AlmacensController _controller;
        private DbTestFixture<GestionInventariosContext> _fixture;

        public AlmacenControllerTest()
        {
            _fixture = new DbTestFixture<GestionInventariosContext>();
            _controller = new AlmacensController(_fixture.Context, _fixture.Mapper);
        }

        [Fact]
        public void Setup()
        {
            var almacenes = new List<Almacen>
            {
                new Almacen { Nombre = "Almacén Santo Domingo", Direccion = "Calle Central, Santo Domingo" },
                new Almacen { Nombre = "Almacén Santiago", Direccion = "Calle Norte, Santiago" }
            };
            _fixture.Context.Almacens.AddRange(almacenes);
            _fixture.Context.SaveChanges();
        }

        [Fact]
        public async Task GetAlmacen_ReturnsOkResult()
        {
            // Arrange
            Setup();

            // Act
            var result = await _controller.GetAlmacens();

            // Assert
            Xunit.Assert.IsType<OkObjectResult>(result.Result);
            Xunit.Assert.NotNull(result.Result);

            var okResult = result.Result as OkObjectResult;
            Xunit.Assert.NotNull(okResult);

            var almacenes = okResult.Value as IEnumerable<AlmacenGetDTO>;
            Xunit.Assert.NotNull(almacenes);
            Xunit.Assert.Equal(2, almacenes.Count()); // Verificar que se devuelvan todos los almacenes
        }

        [Fact]
        public async Task PostAlmacen_ReturnsOkResult_WithValidData()
        {
            // Arrange
            Setup();
            var almacenDto = new AlmacenInsertDTO { Nombre = "Almacén Puerto Plata", Direccion = "Calle Marítima, Puerto Plata" };

            // Act
            var result = await _controller.PostAlmacen(almacenDto);

            // Assert
            var okResult = Xunit.Assert.IsType<OkObjectResult>(result.Result);
            Xunit.Assert.IsType<int>(okResult.Value);
        }

        [Fact]
        public async Task PutAlmacen_ReturnsNoContent_WithValidId()
        {
            // Arrange
            Setup();
            var almacenInsertDto = new AlmacenInsertDTO { Nombre = "Almacén La Vega", Direccion = "Calle Principal, La Vega" };
            await _controller.PostAlmacen(almacenInsertDto);

            // Desatachar la entidad que se acaba de insertar para evitar conflictos
            var insertedAlmacen = _fixture.Context.Almacens.Local.FirstOrDefault(a => a.Nombre == "Almacén La Vega");
            if (insertedAlmacen != null)
            {
                _fixture.Context.Entry(insertedAlmacen).State = EntityState.Detached;
            }

            var almacenDto = new AlmacenPutDTO { Id = insertedAlmacen.Id, Nombre = "Almacén La Vega Modificado", Direccion = "Calle Principal, La Vega" };

            // Act
            var result = await _controller.PutAlmacen(insertedAlmacen.Id, almacenDto);

            // Assert
            Xunit.Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DeleteAlmacen_ReturnsNoContent_WithValidId()
        {
            // Arrange
            Setup();
            var result = await _controller.DeleteAlmacen(1);

            // Assert
            Xunit.Assert.IsType<NoContentResult>(result);
        }
    }
}
