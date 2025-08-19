using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ProveedoresApp.Entity
{
    public class Proveedor
    {
        public Guid Id { get; set; }
        public string RazonSocial { get; set; }
        public string NombreComercial { get; set; }
        public long IdentificacionTributaria {get; set; }
        public string Telefono { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public string Pais { get; set; }
        public long Facturacion { get; set;}
        public DateTime UltimaEdicion { get; set; }
        [Required]
        public bool IsActive { get; set; }


    }
}
