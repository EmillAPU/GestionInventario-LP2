using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GestionInventario.Models;

public partial class Inventario
{
    [Required]
    public int Id { get; set; }

    [Required]
    public int? IdProducto { get; set; }

    [Required]
    public int? IdAlmacen { get; set; }

    [Required]
    public int CantidadActual { get; set; }

    [Required]
    public DateOnly Fecha { get; set; }

    public virtual Almacen? IdAlmacenNavigation { get; set; }

    public virtual Producto? IdProductoNavigation { get; set; }
}
