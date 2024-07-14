namespace GestionInventario.Share.DTO.EntradumDTO
{
    public class EntradumInsertDTO
    {

        public int? IdProducto { get; set; }

        public int? IdAlmacen { get; set; }

        public int Cantidad { get; set; }

        public DateOnly Fecha { get; set; }
    }
}
