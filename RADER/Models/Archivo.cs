using System;
using System.Collections.Generic;

namespace RADER.Models;

public partial class Archivo
{
    public int IdArchivo { get; set; }

    public string? NombreA { get; set; }

    public string? ExtencionA { get; set; }

    public string? CapacidadA { get; set; }

    public string? UbicacionA { get; set; }

    public int? PersonaA { get; set; }

    public bool? Estado { get; set; }

    public virtual Persona? PersonaANavigation { get; set; }
}
