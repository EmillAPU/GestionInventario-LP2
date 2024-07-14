using GestionInventario.Share.DTO.ProveedorDTO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

public class ProveedorService : IProveedorService
{
    private readonly HttpClient _httpClient;

    public ProveedorService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<ProveedorGetDTO>> GetProveedors()
    {
        return await _httpClient.GetFromJsonAsync<List<ProveedorGetDTO>>("api/Proveedors");
    }

    public async Task<ProveedorGetDTO> GetProveedor(int id)
    {
        return await _httpClient.GetFromJsonAsync<ProveedorGetDTO>($"api/Proveedors/{id}");
    }

    public async Task CreateProveedor(ProveedorInsertDTO proveedor)
    {
        await _httpClient.PostAsJsonAsync("api/Proveedors", proveedor);
    }

    public async Task UpdateProveedor(int id, ProveedorPutDTO proveedor)
    {
        await _httpClient.PutAsJsonAsync($"api/Proveedors/{id}", proveedor);
    }

    public async Task DeleteProveedor(int id)
    {
        await _httpClient.DeleteAsync($"api/Proveedors/{id}");
    }
}
