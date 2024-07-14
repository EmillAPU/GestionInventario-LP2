using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GestionInventario.Models;

public partial class Ajuste
{
    [Required]
    public int Id { get; set; }

    [Required]
    public int? IdProducto { get; set; }

    [Required]
    public int? IdAlmacen { get; set; }

    [Required]
    public int Cantidad { get; set; }

    [Required]
    public string Tipo { get; set; } = null!;

    [Required]
    public string? Motivo { get; set; }

    [Required]
    public DateOnly Fecha { get; set; }

    public virtual Almacen? IdAlmacenNavigation { get; set; }

    public virtual Producto? IdProductoNavigation { get; set; }
}
