using System;
using System.Collections.Generic;

namespace RADER.Models;

public partial class Encargado
{
    public int IdEncargado { get; set; }

    public string? FormacionE { get; set; }

    public string? VehiculoE { get; set; }

    public string? DescripcionE { get; set; }

    public int? PersonaEnc { get; set; }

    public virtual ICollection<Mantenimiento> Mantenimientos { get; } = new List<Mantenimiento>();

    public virtual Persona? PersonaEncNavigation { get; set; }
}
