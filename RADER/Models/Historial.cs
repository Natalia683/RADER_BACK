using System;
using System.Collections.Generic;

namespace RADER.Models;

public partial class Historial
{
    public int IdHistorial { get; set; }

    public DateTime? FechaH { get; set; }

    public string? NovedadH { get; set; }

    public string? SugerenciaUsuarioH { get; set; }

    public string? IncidenciasH { get; set; }

    public int? ComponenteH { get; set; }

    public int? UsuarioH { get; set; }

    public bool? Estado { get; set; }

    public virtual Componente? ComponenteHNavigation { get; set; }

    public virtual Usuario? UsuarioHNavigation { get; set; }
}
