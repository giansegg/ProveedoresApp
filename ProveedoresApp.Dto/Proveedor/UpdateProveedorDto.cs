

namespace ProveedoresApp.Dto.Proveedor
{
    public class UpdateProveedorDto : ProveedorDto
    {
        public Guid Id { get; set; }
        public bool IsActive { get; set; } 

      
    }
}
