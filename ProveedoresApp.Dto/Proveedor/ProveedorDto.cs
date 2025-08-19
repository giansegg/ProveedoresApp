namespace ProveedoresApp.Dto.Proveedor
{
    public class ProveedorDto
    {
        public string RazonSocial { get; set; }
        public string NombreComercial { get; set; }
        public long IdentificacionTributaria { get; set; }
        public string Telefono { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public string Pais { get; set; }
        public long Facturacion { get; set; }
        public DateTime UltimaEdicion { get; set; }
    }
}

