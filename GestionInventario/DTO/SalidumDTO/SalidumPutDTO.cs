using GestionInventario.Models;

namespace GestionInventario.DTO.SalidumDTO
{
    public class SalidumPutDTO
    {
        public int Id { get; set; }

        public int? IdProducto { get; set; }

        public int? IdAlmacen { get; set; }

        public int Cantidad { get; set; }

        public DateOnly Fecha { get; set; }
    }
}
