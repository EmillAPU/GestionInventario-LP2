using GestionInventario.Share.DTO.InventarioDTO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

public class InventarioService : IInventarioService
{
    private readonly HttpClient _httpClient;

    public InventarioService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<InventarioGetDTO>> GetInventarios()
    {
        return await _httpClient.GetFromJsonAsync<List<InventarioGetDTO>>("api/Inventarios");
    }

    public async Task<InventarioGetDTO> GetInventario(int id)
    {
        return await _httpClient.GetFromJsonAsync<InventarioGetDTO>($"api/Inventarios/{id}");
    }

    public async Task CreateInventario(InventarioInsertDTO inventario)
    {
        await _httpClient.PostAsJsonAsync("api/Inventarios", inventario);
    }

    public async Task UpdateInventario(int id, InventarioPutDTO inventario)
    {
        await _httpClient.PutAsJsonAsync($"api/Inventarios/{id}", inventario);
    }

    public async Task DeleteInventario(int id)
    {
        await _httpClient.DeleteAsync($"api/Inventarios/{id}");
    }
}
