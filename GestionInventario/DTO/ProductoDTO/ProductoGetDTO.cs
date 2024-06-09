namespace GestionInventario.DTO.ProductoDTO
{
    public class ProductoGetDTO
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string? Descripcion { get; set; }

        public int? IdProveedor { get; set; }

        public int? IdCategoria { get; set; }
    }
}
