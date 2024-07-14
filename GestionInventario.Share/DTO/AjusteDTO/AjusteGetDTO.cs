namespace GestionInventario.Share.DTO.AjusteDTO
{
    public class AjusteGetDTO
    {
        public int Id { get; set; }

        public int? IdProducto { get; set; }

        public int? IdAlmacen { get; set; }

        public int Cantidad { get; set; }

        public string Tipo { get; set; } = null!;

        public string? Motivo { get; set; }

        public DateOnly Fecha { get; set; }
    }
}
