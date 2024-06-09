using AutoMapper;
using GestionInventario.DTO.AjusteDTO;
using GestionInventario.DTO.AlmacenDTO;
using GestionInventario.DTO.CategoriumDTO;
using GestionInventario.DTO.EntradumDTO;
using GestionInventario.DTO.InventarioDTO;
using GestionInventario.DTO.ProductoDTO;
using GestionInventario.DTO.ProveedorDTO;
using GestionInventario.DTO.SalidumDTO;
using GestionInventario.Models;

namespace GestionInventario.DTO
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AjusteGetDTO, Ajuste>().ReverseMap();
            CreateMap<AjusteInsertDTO, Ajuste>().ReverseMap();
            CreateMap<AjustePutDTO, Ajuste>().ReverseMap();

            CreateMap<AlmacenGetDTO, Almacen>().ReverseMap();
            CreateMap<AlmacenInsertDTO, Almacen>().ReverseMap();
            CreateMap<AlmacenPutDTO, Almacen>().ReverseMap();

            CreateMap<CategoriumGetDTO, Categorium>().ReverseMap();
            CreateMap<CategoriumInsertDTO, Categorium>().ReverseMap();
            CreateMap<CategoriumPutDTO, Categorium>().ReverseMap();

            CreateMap<EntradumGetDTO, Entradum>().ReverseMap();
            CreateMap<EntradumInsertDTO, Entradum>().ReverseMap();
            CreateMap<EntradumPutDTO, Entradum>().ReverseMap();

            CreateMap<InventarioGetDTO, Inventario>().ReverseMap();
            CreateMap<InventarioInsertDTO, Inventario>().ReverseMap();
            CreateMap<InventarioPutDTO, Inventario>().ReverseMap();

            CreateMap<ProductoGetDTO, Producto>().ReverseMap();
            CreateMap<ProductoInsertDTO, Producto>().ReverseMap();
            CreateMap<ProductoPutDTO, Producto>().ReverseMap();

            CreateMap<ProveedorGetDTO, Proveedor>().ReverseMap();
            CreateMap<ProveedorInsertDTO, Proveedor>().ReverseMap();
            CreateMap<ProveedorPutDTO, Proveedor>().ReverseMap();

            CreateMap<SalidumGetDTO, Salidum>().ReverseMap();
            CreateMap<SalidumInsertDTO, Salidum>().ReverseMap();
            CreateMap<SalidumPutDTO, Salidum>().ReverseMap();
        }

    }
}
