using GestionInventario.Share.DTO.ProductoDTO;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IProductoService
{
    Task<List<ProductoGetDTO>> GetProductos();
    Task<ProductoGetDTO> GetProducto(int id);
    Task CreateProducto(ProductoInsertDTO producto);
    Task UpdateProducto(int id, ProductoPutDTO producto);
    Task DeleteProducto(int id);
}
