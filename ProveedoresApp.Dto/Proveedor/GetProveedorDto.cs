

namespace ProveedoresApp.Dto.Proveedor
{
    public class GetProveedorDto: ProveedorDto
    {
        public Guid Id { get; set; }
        public bool IsActive { get; set; }
    }
}
