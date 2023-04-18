using System;
using System.Collections.Generic;

namespace RADER.Models;

public partial class Permiso
{
    public int IdPermiso { get; set; }

    public string? RolPermiso { get; set; }

    public string? ModuloPermiso { get; set; }

    public string? GetPermiso { get; set; }

    public string? PostPermiso { get; set; }

    public string? PutPermiso { get; set; }

    public string? DeletePermiso { get; set; }
}
