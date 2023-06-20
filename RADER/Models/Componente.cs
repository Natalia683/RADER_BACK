using System;
using System.Collections.Generic;

namespace RADER.Models;

public partial class Componente
{
    public int IdComponente { get; set; }

    public string? NombreC { get; set; }

    public string? DescripcionC { get; set; }

    public DateTime? FechaCompraC { get; set; }

    public DateTime? FechaVidaUC { get; set; }

    public string? AccionesC { get; set; }

    public int? DispositivoC { get; set; }

    public bool? Estado { get; set; }

    public virtual Dispositivo? DispositivoCNavigation { get; set; }

    public virtual ICollection<Historial> Historials { get; } = new List<Historial>();

    public virtual ICollection<Inventario> Inventarios { get; } = new List<Inventario>();
}
