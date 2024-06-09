using GestionInventario.Models;

namespace GestionInventario.DTO.InventarioDTO
{
    public class InventarioGetDTO
    {
        public int Id { get; set; }

        public int? IdProducto { get; set; }

        public int? IdAlmacen { get; set; }

        public int CantidadActual { get; set; }

        public DateOnly Fecha { get; set; }
    }
}
