using GestionInventario.Share.DTO.AjusteDTO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

public class AjusteService : IAjusteService
{
    private readonly HttpClient _httpClient;

    public AjusteService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<AjusteGetDTO>> GetAjustes()
    {
        return await _httpClient.GetFromJsonAsync<List<AjusteGetDTO>>("api/ajustes");
    }

    public async Task<AjusteGetDTO> GetAjuste(int id)
    {
        return await _httpClient.GetFromJsonAsync<AjusteGetDTO>($"api/ajustes/{id}");
    }

    public async Task CreateAjuste(AjusteInsertDTO ajuste)
    {
        await _httpClient.PostAsJsonAsync("api/ajustes", ajuste);
    }

    public async Task UpdateAjuste(int id, AjustePutDTO ajuste)
    {
        await _httpClient.PutAsJsonAsync($"api/ajustes/{id}", ajuste);
    }

    public async Task DeleteAjuste(int id)
    {
        await _httpClient.DeleteAsync($"api/ajustes/{id}");
    }
}
