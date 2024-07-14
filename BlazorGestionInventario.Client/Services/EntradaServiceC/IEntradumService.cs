using GestionInventario.Share.DTO.EntradumDTO;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IEntradumService
{
    Task<List<EntradumGetDTO>> GetEntradas();
    Task<EntradumGetDTO> GetEntrada(int id);
    Task CreateEntrada(EntradumInsertDTO entrada);
    Task UpdateEntrada(int id, EntradumPutDTO entrada);
    Task DeleteEntrada(int id);
}
