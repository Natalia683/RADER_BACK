using System;
using System.Collections.Generic;

namespace RADER.Models;

public partial class Solicitud
{
    public int IdSolicitud { get; set; }

    public string? TipoS { get; set; }

    public string? DescripcionS { get; set; }

    public int? UsuarioS { get; set; }

    public int? DispositivoS { get; set; }

    public virtual Dispositivo? DispositivoSNavigation { get; set; }

    public virtual Usuario? UsuarioSNavigation { get; set; }
}
