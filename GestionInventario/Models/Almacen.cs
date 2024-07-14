using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GestionInventario.Models;

public partial class Almacen
{
    [Required]
    public int Id { get; set; }

    [Required]
    public string Nombre { get; set; } = null!;

    [Required]
    public string? Direccion { get; set; }

    public virtual ICollection<Ajuste> Ajustes { get; set; } = new List<Ajuste>();

    public virtual ICollection<Entradum> Entrada { get; set; } = new List<Entradum>();

    public virtual ICollection<Inventario> Inventarios { get; set; } = new List<Inventario>();

    public virtual ICollection<Salidum> Salida { get; set; } = new List<Salidum>();
}
