namespace GestionInventario.DTO.AlmacenDTO
{
    public class AlmacenGetDTO
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string? Direccion { get; set; }
    }
}
