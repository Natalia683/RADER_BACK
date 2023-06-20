using System;
using System.Collections.Generic;

namespace RADER.Models;

public partial class Proveedor
{
    public int IdProveedor { get; set; }

    public string? NombreP { get; set; }

    public string? NitP { get; set; }

    public string? DireccionP { get; set; }

    public string? TelefonoP { get; set; }

    public int? PersonaP { get; set; }

    public DateTime? FechaVinculacionP { get; set; }

    public bool? Estado { get; set; }

    public virtual ICollection<Inventario> Inventarios { get; } = new List<Inventario>();

    public virtual Persona? PersonaPNavigation { get; set; }
}
