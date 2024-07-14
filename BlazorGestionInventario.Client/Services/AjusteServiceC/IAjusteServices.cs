using GestionInventario.Share.DTO.AjusteDTO;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IAjusteService
{
    Task<List<AjusteGetDTO>> GetAjustes();
    Task<AjusteGetDTO> GetAjuste(int id); // Asegúrate de que este método esté definido
    Task CreateAjuste(AjusteInsertDTO ajuste);
    Task UpdateAjuste(int id, AjustePutDTO ajuste);
    Task DeleteAjuste(int id);
}
