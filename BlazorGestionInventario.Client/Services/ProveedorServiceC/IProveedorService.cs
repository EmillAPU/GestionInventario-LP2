using GestionInventario.Share.DTO.ProveedorDTO;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IProveedorService
{
    Task<List<ProveedorGetDTO>> GetProveedors();
    Task<ProveedorGetDTO> GetProveedor(int id);
    Task CreateProveedor(ProveedorInsertDTO proveedor);
    Task UpdateProveedor(int id, ProveedorPutDTO proveedor);
    Task DeleteProveedor(int id);
}
