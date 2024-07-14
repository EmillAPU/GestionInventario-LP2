namespace GestionInventario.Share.DTO.ProductoDTO
{
    public class ProductoInsertDTO
    {
        public string Nombre { get; set; } = null!;

        public string? Descripcion { get; set; }

        public int? IdProveedor { get; set; }

        public int? IdCategoria { get; set; }
    }
}
