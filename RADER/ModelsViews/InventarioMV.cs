namespace RADER.ModelsViews
{
    public class InventarioMV
    {
        public int IdInventario { get; set; }

        public string? Descripcion { get; set; }

        public int? Cantidad { get; set; }

        public int? Proveedor { get; set; }

        public string? Nombre_Proveedor { get; set; }

        public int? ComponenteI { get; set; }

        public string? NombreC { get; set; }

        public string? EstadoI { get; set; }
    }
}
