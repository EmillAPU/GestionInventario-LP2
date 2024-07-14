using GestionInventario.Share.DTO.EntradumDTO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

public class EntradumService : IEntradumService
{
    private readonly HttpClient _httpClient;

    public EntradumService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<EntradumGetDTO>> GetEntradas()
    {
        return await _httpClient.GetFromJsonAsync<List<EntradumGetDTO>>("api/Entradums");
    }

    public async Task<EntradumGetDTO> GetEntrada(int id)
    {
        return await _httpClient.GetFromJsonAsync<EntradumGetDTO>($"api/Entradums/{id}");
    }

    public async Task CreateEntrada(EntradumInsertDTO entrada)
    {
        await _httpClient.PostAsJsonAsync("api/Entradums", entrada);
    }

    public async Task UpdateEntrada(int id, EntradumPutDTO entrada)
    {
        await _httpClient.PutAsJsonAsync($"api/Entradums/{id}", entrada);
    }

    public async Task DeleteEntrada(int id)
    {
        await _httpClient.DeleteAsync($"api/Entradums/{id}");
    }
}
