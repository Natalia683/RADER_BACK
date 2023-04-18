using System;
using System.Collections.Generic;

namespace RADER.Models;

public partial class Dispositivo
{
    public int IdDispositivo { get; set; }

    public string? NombreD { get; set; }

    public string? LargoD { get; set; }

    public string? AltoD { get; set; }

    public string? AnchoD { get; set; }

    public string? PesoD { get; set; }

    public int? EmpresaD { get; set; }

    public virtual ICollection<Componente> Componentes { get; } = new List<Componente>();

    public virtual Empresa? EmpresaDNavigation { get; set; }

    public virtual ICollection<Mantenimiento> Mantenimientos { get; } = new List<Mantenimiento>();

    public virtual ICollection<Solicitud> Solicituds { get; } = new List<Solicitud>();
}
