using GestionInventario.Share.DTO.AlmacenDTO;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IAlmacenService
{
    Task<List<AlmacenGetDTO>> GetAlmacenes();
    Task<AlmacenGetDTO> GetAlmacen(int id);
    Task CreateAlmacen(AlmacenInsertDTO almacen);
    Task UpdateAlmacen(int id, AlmacenPutDTO almacen);
    Task DeleteAlmacen(int id);
}
