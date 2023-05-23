using RADER.Models;

namespace RADER.ModelsViews
{
    public class MantenimientoMV
    {
        public int IdMantenimiento { get; set; }

        public string? EstadoM { get; set; }

        public DateTime? FechaRevisionM { get; set; }

        public string? DescripcionM { get; set; }

        public int? EncargadoM { get; set; }

        public int? DispositivoM { get; set; }

        public string? NombreD { get; set; }

    }
}
