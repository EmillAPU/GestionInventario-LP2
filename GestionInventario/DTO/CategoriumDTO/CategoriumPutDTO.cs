using GestionInventario.Models;

namespace GestionInventario.DTO.CategoriumDTO
{
    public class CategoriumPutDTO
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;
    }
}
