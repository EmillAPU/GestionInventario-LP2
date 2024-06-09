using GestionInventario.Models;

namespace GestionInventario.DTO.ProveedorDTO
{
    public class ProveedorInsertDTO
    { 
        public string Nombre { get; set; } = null!;

        public string? Contacto { get; set; }
    }
}
