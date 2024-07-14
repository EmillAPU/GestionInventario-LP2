using GestionInventario.Share.DTO.SalidumDTO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

public class SalidaService : ISalidaService
{
    private readonly HttpClient _httpClient;

    public SalidaService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<SalidumGetDTO>> GetSalidas()
    {
        return await _httpClient.GetFromJsonAsync<List<SalidumGetDTO>>("api/Salidums");
    }

    public async Task<SalidumGetDTO> GetSalida(int id)
    {
        return await _httpClient.GetFromJsonAsync<SalidumGetDTO>($"api/Salidums/{id}");
    }

    public async Task CreateSalida(SalidumInsertDTO salida)
    {
        await _httpClient.PostAsJsonAsync("api/Salidums", salida);
    }

    public async Task UpdateSalida(int id, SalidumPutDTO salida)
    {
        await _httpClient.PutAsJsonAsync($"api/Salidums/{id}", salida);
    }

    public async Task DeleteSalida(int id)
    {
        await _httpClient.DeleteAsync($"api/Salidums/{id}");
    }
}
