using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GestionInventario.Models;

public partial class Proveedor
{
    [Required]
    public int Id { get; set; }

    [Required]
    public string Nombre { get; set; } = null!;

    [Required]
    [MaxLength(100)]
    public string? Contacto { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
