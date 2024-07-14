namespace GestionInventario.Share.DTO.SalidumDTO
{
    public class SalidumInsertDTO
    {
        public int? IdProducto { get; set; }

        public int? IdAlmacen { get; set; }

        public int Cantidad { get; set; }

        public DateOnly Fecha { get; set; }
    }
}
