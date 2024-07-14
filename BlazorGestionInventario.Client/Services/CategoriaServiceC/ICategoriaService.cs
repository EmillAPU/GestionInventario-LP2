using GestionInventario.Share.DTO.CategoriumDTO;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface ICategoriaService
{
    Task<List<CategoriumGetDTO>> GetCategorias();
    Task<CategoriumGetDTO> GetCategoria(int id);
    Task CreateCategoria(CategoriumInsertDTO categoria);
    Task UpdateCategoria(int id, CategoriumPutDTO categoria);
    Task DeleteCategoria(int id);
}
