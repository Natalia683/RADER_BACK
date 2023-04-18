using System;
using System.Collections.Generic;

namespace RADER.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string? NombreU { get; set; }

    public string? ContraseñaU { get; set; }

    public int? PersonaU { get; set; }

    public string? RolU { get; set; }

    public virtual ICollection<Historial> Historials { get; } = new List<Historial>();

    public virtual Persona? PersonaUNavigation { get; set; }

    public virtual ICollection<Solicitud> Solicituds { get; } = new List<Solicitud>();
}
