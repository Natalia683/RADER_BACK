using System;
using System.Collections.Generic;

namespace RADER.Models;

public partial class Mantenimiento
{
    public int IdMantenimiento { get; set; }

    public string? EstadoM { get; set; }

    public DateTime? FechaRevisionM { get; set; }

    public string? DescripcionM { get; set; }

    public int? EncargadoM { get; set; }

    public int? DispositivoM { get; set; }

    public virtual Dispositivo? DispositivoMNavigation { get; set; }

    public virtual Encargado? EncargadoMNavigation { get; set; }
}
