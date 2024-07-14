using GestionInventario.Share.DTO.ProductoDTO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

public class ProductoService : IProductoService
{
    private readonly HttpClient _httpClient;

    public ProductoService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<ProductoGetDTO>> GetProductos()
    {
        return await _httpClient.GetFromJsonAsync<List<ProductoGetDTO>>("api/Productoes");
    }

    public async Task<ProductoGetDTO> GetProducto(int id)
    {
        return await _httpClient.GetFromJsonAsync<ProductoGetDTO>($"api/Productoes/{id}");
    }

    public async Task CreateProducto(ProductoInsertDTO producto)
    {
        await _httpClient.PostAsJsonAsync("api/Productoes", producto);
    }

    public async Task UpdateProducto(int id, ProductoPutDTO producto)
    {
        await _httpClient.PutAsJsonAsync($"api/Productoes/{id}", producto);
    }

    public async Task DeleteProducto(int id)
    {
        await _httpClient.DeleteAsync($"api/Productoes/{id}");
    }
}
