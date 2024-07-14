using GestionInventario.Share.DTO.SalidumDTO;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface ISalidaService
{
    Task<List<SalidumGetDTO>> GetSalidas();
    Task<SalidumGetDTO> GetSalida(int id);
    Task CreateSalida(SalidumInsertDTO salida);
    Task UpdateSalida(int id, SalidumPutDTO salida);
    Task DeleteSalida(int id);
}
