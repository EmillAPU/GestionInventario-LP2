using System;
using System.Collections.Generic;

namespace GestionInventario.Models;

public partial class Producto
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public int? IdProveedor { get; set; }

    public int? IdCategoria { get; set; }

    public virtual ICollection<Ajuste> Ajustes { get; set; } = new List<Ajuste>();

    public virtual ICollection<Entradum> Entrada { get; set; } = new List<Entradum>();

    public virtual Categorium? IdCategoriaNavigation { get; set; }

    public virtual Proveedor? IdProveedorNavigation { get; set; }

    public virtual ICollection<Inventario> Inventarios { get; set; } = new List<Inventario>();

    public virtual ICollection<Salidum> Salida { get; set; } = new List<Salidum>();
}
