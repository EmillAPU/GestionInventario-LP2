using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestionInventario.Controllers;
using GestionInventario.DTO;
using GestionInventario.DTO.AlmacenDTO;
using GestionInventario.Models;
using System;
using System.Collections.Generic;
using Xunit;
using Gestion_de_Hospitales.UnitTest; // Agrega el namespace para los atributos de las pruebas unitarias

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
                new Almacen { Nombre = "Almacén Santo Domingo" },
                new Almacen { Nombre = "Almacén Santiago" }
            };
            _fixture.Context.Almacens.AddRange(almacenes);
            _fixture.Context.SaveChanges();

            var almacen = new List<Almacen>
            {
                new Almacen { Nombre = "Almacén Santo Domingo", Direccion = "Calle Central, Santo Domingo"},
                new Almacen { Nombre = "Almacén Santo Domingo", Direccion = "Calle Central, Santo Domingo"}
            };
            _fixture.Context.Ajustes.AddRange();
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

            // Verificar que el valor devuelto no es nulo
            Xunit.Assert.NotNull(result.Result);

            // Verificar los datos devueltos
            var okResult = result.Result as OkObjectResult;
            Xunit.Assert.NotNull(okResult);

            var ajustes = okResult.Value as IEnumerable<AlmacenGetDTO>;
            Xunit.Assert.NotNull(ajustes);

            Xunit.Assert.Equal(2, ajustes.Count()); // Verificar que se devuelvan todos los ajustes
        }

        [Fact]
        public async Task PostAlmacen_ReturnsOkResult_WithValidData()
        {
            // Arrange
            Setup();
            var almacenDto = new AlmacenInsertDTO  { Nombre = "Almacén Santo Domingo", Direccion = "Calle Central, Santo Domingo"};

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
            var AlmacenInsertDto = new AlmacenInsertDTO  { Nombre = "Almacén Santo Domingo", Direccion = "Calle Central, Santo Domingo"};
            await _controller.PostAlmacen(AlmacenInsertDto);

            // Desatachar la entidad que se acaba de insertar para evitar conflictos
            var insertedAlmacen = _fixture.Context.Ajustes.Local.FirstOrDefault(a => a.Cantidad == 20);
            if (insertedAlmacen != null)
            {
                _fixture.Context.Entry(insertedAlmacen).State = EntityState.Detached;
            }

            var ajusteDto = new AlmacenPutDTO { Id = 1, Nombre = "Almacén Santo Domingo", Direccion = "Calle Central, Santo Domingo"};

           
        }

        [Fact]
        public async Task DeleteAlmacen_ReturnsNoContent_WithValidId()
        {
            // Act
            Setup();
            var result = await _controller.DeleteAlmacen(1);

            // Assert
            Xunit.Assert.IsType<NoContentResult>(result);
        }

        // Agrega más pruebas según sea necesario...
    }
}
