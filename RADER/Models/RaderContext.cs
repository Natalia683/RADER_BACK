using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RADER.Models;

public partial class RaderContext : DbContext
{
    public RaderContext()
    {
    }

    public RaderContext(DbContextOptions<RaderContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Archivo> Archivos { get; set; }

    public virtual DbSet<Componente> Componentes { get; set; }

    public virtual DbSet<Dispositivo> Dispositivos { get; set; }

    public virtual DbSet<Empresa> Empresas { get; set; }

    public virtual DbSet<Encargado> Encargados { get; set; }

    public virtual DbSet<Historial> Historials { get; set; }

    public virtual DbSet<Inventario> Inventarios { get; set; }

    public virtual DbSet<Mantenimiento> Mantenimientos { get; set; }

    public virtual DbSet<Permiso> Permisos { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<Proveedor> Proveedors { get; set; }

    public virtual DbSet<Solicitud> Solicituds { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-HBQJQEE\\SQLEXPRESS; Database=RADER; Trusted_Connection=True; TrustServerCertificate=Yes ");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Archivo>(entity =>
        {
            entity.HasKey(e => e.IdArchivo);

            entity.ToTable("Archivo");

            entity.Property(e => e.IdArchivo).HasColumnName("Id_Archivo");
            entity.Property(e => e.CapacidadA)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Capacidad_A");
            entity.Property(e => e.ExtencionA)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Extencion_A");
            entity.Property(e => e.NombreA)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Nombre_A");
            entity.Property(e => e.PersonaA).HasColumnName("Persona_A");
            entity.Property(e => e.UbicacionA)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Ubicacion_A");

            entity.HasOne(d => d.PersonaANavigation).WithMany(p => p.Archivos)
                .HasForeignKey(d => d.PersonaA)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Archivo_Persona");
        });

        modelBuilder.Entity<Componente>(entity =>
        {
            entity.HasKey(e => e.IdComponente);

            entity.ToTable("Componente");

            entity.Property(e => e.IdComponente).HasColumnName("Id_Componente");
            entity.Property(e => e.AccionesC)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Acciones_C");
            entity.Property(e => e.DescripcionC)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Descripcion_C");
            entity.Property(e => e.DispositivoC).HasColumnName("Dispositivo_C");
            entity.Property(e => e.FechaCompraC)
                .HasColumnType("date")
                .HasColumnName("Fecha_Compra_C");
            entity.Property(e => e.FechaVidaUC)
                .HasColumnType("date")
                .HasColumnName("Fecha_VidaU_C");
            entity.Property(e => e.NombreC)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Nombre_C");

            entity.HasOne(d => d.DispositivoCNavigation).WithMany(p => p.Componentes)
                .HasForeignKey(d => d.DispositivoC)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Componente_Dispositivo1");
        });

        modelBuilder.Entity<Dispositivo>(entity =>
        {
            entity.HasKey(e => e.IdDispositivo).HasName("PK_Dispositivo_1");

            entity.ToTable("Dispositivo");

            entity.Property(e => e.IdDispositivo).HasColumnName("Id_Dispositivo");
            entity.Property(e => e.AltoD)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Alto_D");
            entity.Property(e => e.AnchoD)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Ancho_D");
            entity.Property(e => e.EmpresaD).HasColumnName("Empresa_D");
            entity.Property(e => e.LargoD)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Largo_D");
            entity.Property(e => e.NombreD)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Nombre_D");
            entity.Property(e => e.PesoD)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Peso_D");

            entity.HasOne(d => d.EmpresaDNavigation).WithMany(p => p.Dispositivos)
                .HasForeignKey(d => d.EmpresaD)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Dispositivo_Empresa1");
        });

        modelBuilder.Entity<Empresa>(entity =>
        {
            entity.HasKey(e => e.IdEmpresa);

            entity.ToTable("Empresa");

            entity.Property(e => e.IdEmpresa).HasColumnName("Id_Empresa");
            entity.Property(e => e.DireccionE)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Direccion_E");
            entity.Property(e => e.FechaVinculacionE)
                .HasColumnType("date")
                .HasColumnName("Fecha_Vinculacion_E");
            entity.Property(e => e.LocalidadE)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Localidad_E");
            entity.Property(e => e.NitE)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NIT_E");
            entity.Property(e => e.NombreE)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Nombre_E");
            entity.Property(e => e.PersonaE).HasColumnName("Persona_E");
            entity.Property(e => e.TelefonoE)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("Telefono_E");

            entity.HasOne(d => d.PersonaENavigation).WithMany(p => p.Empresas)
                .HasForeignKey(d => d.PersonaE)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Empresa_Persona");
        });

        modelBuilder.Entity<Encargado>(entity =>
        {
            entity.HasKey(e => e.IdEncargado);

            entity.ToTable("Encargado");

            entity.Property(e => e.IdEncargado).HasColumnName("Id_Encargado");
            entity.Property(e => e.DescripcionE)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Descripcion_E");
            entity.Property(e => e.FormacionE)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Formacion_E");
            entity.Property(e => e.PersonaEnc).HasColumnName("Persona_Enc");
            entity.Property(e => e.VehiculoE)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Vehiculo_E");

            entity.HasOne(d => d.PersonaEncNavigation).WithMany(p => p.Encargados)
                .HasForeignKey(d => d.PersonaEnc)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Encargado_Persona");
        });

        modelBuilder.Entity<Historial>(entity =>
        {
            entity.HasKey(e => e.IdHistorial);

            entity.ToTable("Historial");

            entity.Property(e => e.IdHistorial).HasColumnName("Id_Historial");
            entity.Property(e => e.ComponenteH).HasColumnName("Componente_H");
            entity.Property(e => e.FechaH)
                .HasColumnType("date")
                .HasColumnName("Fecha_H");
            entity.Property(e => e.IncidenciasH)
                .IsUnicode(false)
                .HasColumnName("Incidencias_H");
            entity.Property(e => e.NovedadH)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Novedad_H");
            entity.Property(e => e.SugerenciaUsuarioH)
                .IsUnicode(false)
                .HasColumnName("Sugerencia_usuario_H");
            entity.Property(e => e.UsuarioH).HasColumnName("Usuario_H");

            entity.HasOne(d => d.ComponenteHNavigation).WithMany(p => p.Historials)
                .HasForeignKey(d => d.ComponenteH)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Historial_Componente");

            entity.HasOne(d => d.UsuarioHNavigation).WithMany(p => p.Historials)
                .HasForeignKey(d => d.UsuarioH)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Historial_Usuario");
        });

        modelBuilder.Entity<Inventario>(entity =>
        {
            entity.HasKey(e => e.IdInventario);

            entity.ToTable("Inventario");

            entity.Property(e => e.IdInventario).HasColumnName("Id_Inventario");
            entity.Property(e => e.CantidadI).HasColumnName("Cantidad_I");
            entity.Property(e => e.ComponenteI).HasColumnName("Componente_I");
            entity.Property(e => e.DescripcionI)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Descripcion_I");
            entity.Property(e => e.EstadoI)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Estado_I");
            entity.Property(e => e.ProveedorI).HasColumnName("Proveedor_I");

            entity.HasOne(d => d.ComponenteINavigation).WithMany(p => p.Inventarios)
                .HasForeignKey(d => d.ComponenteI)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Inventario_Componente");

            entity.HasOne(d => d.ProveedorINavigation).WithMany(p => p.Inventarios)
                .HasForeignKey(d => d.ProveedorI)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Inventario_Proveedor");
        });

        modelBuilder.Entity<Mantenimiento>(entity =>
        {
            entity.HasKey(e => e.IdMantenimiento);

            entity.ToTable("Mantenimiento");

            entity.Property(e => e.IdMantenimiento).HasColumnName("Id_Mantenimiento");
            entity.Property(e => e.DescripcionM)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Descripcion_M");
            entity.Property(e => e.DispositivoM).HasColumnName("Dispositivo_M");
            entity.Property(e => e.EncargadoM).HasColumnName("Encargado_M");
            entity.Property(e => e.EstadoM)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Estado_M");
            entity.Property(e => e.FechaRevisionM)
                .HasColumnType("date")
                .HasColumnName("Fecha_Revision_M");

            entity.HasOne(d => d.DispositivoMNavigation).WithMany(p => p.Mantenimientos)
                .HasForeignKey(d => d.DispositivoM)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Mantenimiento_Dispositivo1");

            entity.HasOne(d => d.EncargadoMNavigation).WithMany(p => p.Mantenimientos)
                .HasForeignKey(d => d.EncargadoM)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Mantenimiento_Encargado");
        });

        modelBuilder.Entity<Permiso>(entity =>
        {
            entity.HasKey(e => e.IdPermiso);

            entity.ToTable("Permiso");

            entity.Property(e => e.IdPermiso)
                .ValueGeneratedNever()
                .HasColumnName("Id_Permiso");
            entity.Property(e => e.DeletePermiso)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Delete_Permiso");
            entity.Property(e => e.GetPermiso)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Get_Permiso");
            entity.Property(e => e.ModuloPermiso)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Modulo_Permiso");
            entity.Property(e => e.PostPermiso)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Post_Permiso");
            entity.Property(e => e.PutPermiso)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Put_Permiso");
            entity.Property(e => e.RolPermiso)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Rol_Permiso");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.IdPersona);

            entity.ToTable("Persona");

            entity.Property(e => e.IdPersona).HasColumnName("Id_Persona");
            entity.Property(e => e.ApellidoP)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Apellido_P");
            entity.Property(e => e.CorreoP)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Correo_P");
            entity.Property(e => e.DireccionP)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Direccion_P");
            entity.Property(e => e.NombreP)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Nombre_P");
            entity.Property(e => e.TelefonoP)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("Telefono_P");
        });

        modelBuilder.Entity<Proveedor>(entity =>
        {
            entity.HasKey(e => e.IdProveedor);

            entity.ToTable("Proveedor");

            entity.Property(e => e.IdProveedor).HasColumnName("Id_Proveedor");
            entity.Property(e => e.DireccionP)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("Direccion_P");
            entity.Property(e => e.FechaVinculacionP)
                .HasColumnType("date")
                .HasColumnName("Fecha_Vinculacion_P");
            entity.Property(e => e.NitP)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NIT_P");
            entity.Property(e => e.NombreP)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Nombre_P");
            entity.Property(e => e.PersonaP).HasColumnName("Persona_P");
            entity.Property(e => e.TelefonoP)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Telefono_P");

            entity.HasOne(d => d.PersonaPNavigation).WithMany(p => p.Proveedors)
                .HasForeignKey(d => d.PersonaP)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Proveedor_Persona");
        });

        modelBuilder.Entity<Solicitud>(entity =>
        {
            entity.HasKey(e => e.IdSolicitud);

            entity.ToTable("Solicitud");

            entity.Property(e => e.IdSolicitud).HasColumnName("Id_Solicitud");
            entity.Property(e => e.DescripcionS)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Descripcion_S");
            entity.Property(e => e.DispositivoS).HasColumnName("Dispositivo_S");
            entity.Property(e => e.TipoS)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Tipo_S");
            entity.Property(e => e.UsuarioS).HasColumnName("Usuario_S");

            entity.HasOne(d => d.DispositivoSNavigation).WithMany(p => p.Solicituds)
                .HasForeignKey(d => d.DispositivoS)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Solicitud_Dispositivo1");

            entity.HasOne(d => d.UsuarioSNavigation).WithMany(p => p.Solicituds)
                .HasForeignKey(d => d.UsuarioS)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Solicitud_Usuario");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario);

            entity.ToTable("Usuario");

            entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");
            entity.Property(e => e.ContraseñaU)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Contraseña_U");
            entity.Property(e => e.NombreU)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Nombre_U");
            entity.Property(e => e.PersonaU).HasColumnName("Persona_U");
            entity.Property(e => e.RolU)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Rol_U");

            entity.HasOne(d => d.PersonaUNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.PersonaU)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Usuario_Persona");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
