using System;
using System.Collections.Generic;

namespace RADER.Models;

public partial class Inventario
{
    public int IdInventario { get; set; }

    public string? DescripcionI { get; set; }

    public int? CantidadI { get; set; }

    public int? ProveedorI { get; set; }

    public int? ComponenteI { get; set; }

    public string? EstadoI { get; set; }

    public virtual Componente? ComponenteINavigation { get; set; }

    public virtual Proveedor? ProveedorINavigation { get; set; }
}
