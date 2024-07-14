using BlazorGestionInventario.Client;
using GestionInventario.Share.DTO.CategoriumDTO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

public class CategoriaService : ICategoriaService
{
    private readonly HttpClient _httpClient;

    public CategoriaService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<CategoriumGetDTO>> GetCategorias()
    {
        return await _httpClient.GetFromJsonAsync<List<CategoriumGetDTO>>("api/categoriums");
    }

    public async Task<CategoriumGetDTO> GetCategoria(int id)
    {
        return await _httpClient.GetFromJsonAsync<CategoriumGetDTO>($"api/categoriums/{id}");
    }

    public async Task CreateCategoria(CategoriumInsertDTO categoria)
    {
        await _httpClient.PostAsJsonAsync("api/categoriums", categoria);
    }

    public async Task UpdateCategoria(int id, CategoriumPutDTO categoria)
    {
        await _httpClient.PutAsJsonAsync($"api/categoriums/{id}", categoria);
    }

    public async Task DeleteCategoria(int id)
    {
        await _httpClient.DeleteAsync($"api/categoriums/{id}");
    }
}
