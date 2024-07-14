using BlazorGestionInventario.Client;
using GestionInventario.Share.DTO.AlmacenDTO;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

public class AlmacenService : IAlmacenService
{
    private readonly HttpClient _httpClient;

    public AlmacenService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<AlmacenGetDTO>> GetAlmacenes()
    {
        return await _httpClient.GetFromJsonAsync<List<AlmacenGetDTO>>("api/almacens");
    }

    public async Task<AlmacenGetDTO> GetAlmacen(int id)
    {
        return await _httpClient.GetFromJsonAsync<AlmacenGetDTO>($"api/almacens/{id}");
    }

    public async Task CreateAlmacen(AlmacenInsertDTO almacen)
    {
        await _httpClient.PostAsJsonAsync("api/almacens", almacen);
    }

    public async Task UpdateAlmacen(int id, AlmacenPutDTO almacen)
    {
        await _httpClient.PutAsJsonAsync($"api/almacens/{id}", almacen);
    }

    public async Task DeleteAlmacen(int id)
    {
        await _httpClient.DeleteAsync($"api/almacens/{id}");
    }

    public Task<List<AlmacenGetDTO>> GetAlmacenesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<AlmacenGetDTO> GetAlmacenByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> CreateAlmacenAsync(AlmacenInsertDTO almacen)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAlmacenAsync(int id, AlmacenPutDTO almacen)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAlmacenAsync(int id)
    {
        throw new NotImplementedException();
    }
}
