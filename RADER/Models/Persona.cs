using System;
using System.Collections.Generic;

namespace RADER.Models;

public partial class Persona
{
    public int IdPersona { get; set; }

    public string? NombreP { get; set; }

    public string? ApellidoP { get; set; }

    public string? DireccionP { get; set; }

    public string? TelefonoP { get; set; }

    public string? CorreoP { get; set; }

    public bool? Estado { get; set; }

    public virtual ICollection<Archivo> Archivos { get; } = new List<Archivo>();

    public virtual ICollection<Empresa> Empresas { get; } = new List<Empresa>();

    public virtual ICollection<Encargado> Encargados { get; } = new List<Encargado>();

    public virtual ICollection<Proveedor> Proveedors { get; } = new List<Proveedor>();

    public virtual ICollection<Usuario> Usuarios { get; } = new List<Usuario>();
}
