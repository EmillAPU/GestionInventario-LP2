using GestionInventario.Share.DTO.InventarioDTO;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IInventarioService
{
    Task<List<InventarioGetDTO>> GetInventarios();
    Task<InventarioGetDTO> GetInventario(int id);
    Task CreateInventario(InventarioInsertDTO inventario);
    Task UpdateInventario(int id, InventarioPutDTO inventario);
    Task DeleteInventario(int id);
}
