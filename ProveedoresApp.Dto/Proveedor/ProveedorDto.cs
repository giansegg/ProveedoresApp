namespace ProveedoresApp.Dto.Proveedor
{
    public class ProveedorDto
    {
        public string RazonSocial { get; set; }
        public string NombreComercial { get; set; }
        public int IdentificacionTributaria { get; set; }
        public int Telefono { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public string Pais { get; set; }
        public int Facturacion { get; set; }
        public DateTime UltimaEdicion { get; set; }
    }
}
