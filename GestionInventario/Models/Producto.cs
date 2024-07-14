using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GestionInventario.Models;

public partial class Producto
{
    [Required]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Nombre { get; set; } = null!;

    [Required]
    [MaxLength(250)]
    public string? Descripcion { get; set; }

    [Required]
    public int? IdProveedor { get; set; }

    [Required]
    public int? IdCategoria { get; set; }

    public virtual ICollection<Ajuste> Ajustes { get; set; } = new List<Ajuste>();

    public virtual ICollection<Entradum> Entrada { get; set; } = new List<Entradum>();

    public virtual Categorium? IdCategoriaNavigation { get; set; }

    public virtual Proveedor? IdProveedorNavigation { get; set; }

    public virtual ICollection<Inventario> Inventarios { get; set; } = new List<Inventario>();

    public virtual ICollection<Salidum> Salida { get; set; } = new List<Salidum>();
}
