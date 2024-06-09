using System;
using System.Collections.Generic;

namespace GestionInventario.Models;

public partial class Inventario
{
    public int Id { get; set; }

    public int? IdProducto { get; set; }

    public int? IdAlmacen { get; set; }

    public int CantidadActual { get; set; }

    public DateOnly Fecha { get; set; }

    public virtual Almacen? IdAlmacenNavigation { get; set; }

    public virtual Producto? IdProductoNavigation { get; set; }
}
