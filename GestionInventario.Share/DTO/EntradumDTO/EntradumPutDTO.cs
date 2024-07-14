namespace GestionInventario.Share.DTO.EntradumDTO
{
    public class EntradumPutDTO
    {
        public int Id { get; set; }

        public int? IdProducto { get; set; }

        public int? IdAlmacen { get; set; }

        public int Cantidad { get; set; }

        public DateOnly Fecha { get; set; }
    }
}
