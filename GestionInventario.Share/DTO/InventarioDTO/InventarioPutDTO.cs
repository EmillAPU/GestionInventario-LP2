﻿namespace GestionInventario.Share.DTO.InventarioDTO
{
    public class InventarioPutDTO
    {
        public int Id { get; set; }

        public int? IdProducto { get; set; }

        public int? IdAlmacen { get; set; }

        public int CantidadActual { get; set; }

        public DateOnly Fecha { get; set; }

    }
}
