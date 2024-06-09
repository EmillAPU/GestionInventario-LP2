using System;
using System.Collections.Generic;

namespace GestionInventario.Models;

public partial class Proveedor
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Contacto { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
