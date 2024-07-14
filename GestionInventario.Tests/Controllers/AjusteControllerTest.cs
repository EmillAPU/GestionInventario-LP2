using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestionInventario.Controllers;
using GestionInventario.Share.DTO.AjusteDTO;
using GestionInventario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace GestionInventario.UnitTest
{
    public class AjusteControllerTest
    {
        private AjustesController _controller;
        private DbTestFixture<GestionInventariosContext> _fixture;

        public AjusteControllerTest()
        {
            _fixture = new DbTestFixture<GestionInventariosContext>();
            _controller = new AjustesController(_fixture.Context, _fixture.Mapper);
        }

        [Fact]
        public void Setup()
        {
            var productos = new List<Producto>
            {
                new Producto { Nombre = "Producto A", Descripcion = "Descripcion A", IdCategoria = 1, IdProveedor = 1 },
                new Producto { Nombre = "Producto B", Descripcion = "Descripcion B", IdCategoria = 1, IdProveedor = 1 }
            };
            _fixture.Context.Productos.AddRange(productos);
            _fixture.Context.SaveChanges();

            var almacenes = new List<Almacen>
            {
                new Almacen { Nombre = "Almacen A", Direccion = "Direccion A" },
                new Almacen { Nombre = "Almacen B", Direccion = "Direccion B" }
            };
            _fixture.Context.Almacens.AddRange(almacenes);
            _fixture.Context.SaveChanges();

            var ajustes = new List<Ajuste>
            {
                new Ajuste { IdProducto = 1, IdAlmacen = 1, Cantidad = 10, Tipo = "Entrada", Motivo = "Motivo A", Fecha = DateOnly.FromDateTime(DateTime.Now) },
                new Ajuste { IdProducto = 2, IdAlmacen = 2, Cantidad = 5, Tipo = "Salida", Motivo = "Motivo B", Fecha = DateOnly.FromDateTime(DateTime.Now) }
            };
            _fixture.Context.Ajustes.AddRange(ajustes);
            _fixture.Context.SaveChanges();
        }

        [Fact]
        public async Task GetAjustes_ReturnsOkResult()
        {
            // Arrange
            Setup();

            // Act
            var result = await _controller.GetAjustes();

            // Assert
            Xunit.Assert.IsType<OkObjectResult>(result.Result);
            Xunit.Assert.NotNull(result.Result);

            var okResult = result.Result as OkObjectResult;
            Xunit.Assert.NotNull(okResult);

            var ajustes = okResult.Value as IEnumerable<AjusteGetDTO>;
            Xunit.Assert.NotNull(ajustes);
            Xunit.Assert.Equal(2, ajustes.Count()); // Verificar que se devuelvan todos los ajustes
        }

        [Fact]
        public async Task PostAjuste_ReturnsOkResult_WithValidData()
        {
            // Arrange
            Setup();
            var ajusteDto = new AjusteInsertDTO { IdProducto = 1, IdAlmacen = 2, Cantidad = 15, Tipo = "Entrada", Motivo = "Motivo C", Fecha = DateOnly.FromDateTime(DateTime.Now) };

            // Act
            var result = await _controller.PostAjuste(ajusteDto);

            // Assert
            var okResult = Xunit.Assert.IsType<OkObjectResult>(result.Result);
            Xunit.Assert.IsType<int>(okResult.Value);
        }

        [Fact]
        public async Task PutAjuste_ReturnsNoContent_WithValidId()
        {
            // Arrange
            Setup();
            var ajusteInsertDto = new AjusteInsertDTO { IdProducto = 1, IdAlmacen = 1, Cantidad = 20, Tipo = "Entrada", Motivo = "Motivo D", Fecha = DateOnly.FromDateTime(DateTime.Now) };
            await _controller.PostAjuste(ajusteInsertDto);

            // Desatachar la entidad que se acaba de insertar para evitar conflictos
            var insertedAjuste = _fixture.Context.Ajustes.Local.FirstOrDefault(a => a.Cantidad == 20);
            if (insertedAjuste != null)
            {
                _fixture.Context.Entry(insertedAjuste).State = EntityState.Detached;
            }

            var ajusteDto = new AjustePutDTO { Id = insertedAjuste.Id, IdProducto = 2, IdAlmacen = 2, Cantidad = 25, Tipo = "Salida", Motivo = "Motivo E", Fecha = DateOnly.FromDateTime(DateTime.Now) };

            // Act
            var result = await _controller.PutAjuste(insertedAjuste.Id, ajusteDto);

            // Assert
            Xunit.Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DeleteAjuste_ReturnsNoContent_WithValidId()
        {
            // Arrange
            Setup();
            var result = await _controller.DeleteAjuste(1);

            // Assert
            Xunit.Assert.IsType<NoContentResult>(result);
        }
    }
}
