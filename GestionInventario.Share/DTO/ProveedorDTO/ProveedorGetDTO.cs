﻿namespace GestionInventario.Share.DTO.ProveedorDTO
{
    public class ProveedorGetDTO
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string? Contacto { get; set; }
    }
}
