namespace GestionInventario.Share.DTO.AlmacenDTO
{
    public class AlmacenPutDTO
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string? Direccion { get; set; }
    }
}
