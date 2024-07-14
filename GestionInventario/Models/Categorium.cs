using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GestionInventario.Models;

public partial class Categorium
{
    [Required]
    public int Id { get; set; }

    [Required]
    public string Nombre { get; set; } = null!;

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
