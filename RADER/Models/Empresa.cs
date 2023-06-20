using System;
using System.Collections.Generic;

namespace RADER.Models;

public partial class Empresa
{
    public int IdEmpresa { get; set; }

    public string? NombreE { get; set; }

    public string? NitE { get; set; }

    public string? DireccionE { get; set; }

    public string? TelefonoE { get; set; }

    public string? LocalidadE { get; set; }

    public int? PersonaE { get; set; }

    public DateTime? FechaVinculacionE { get; set; }

    public bool? Estado { get; set; }

    public virtual ICollection<Dispositivo> Dispositivos { get; } = new List<Dispositivo>();

    public virtual Persona? PersonaENavigation { get; set; }
}
