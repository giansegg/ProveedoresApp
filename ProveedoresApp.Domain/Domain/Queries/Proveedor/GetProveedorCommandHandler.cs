using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProveedoresApp.Infrastructure;
using ProveedoresApp.Dto.Proveedor;
using ProveedoresApp.Infrastructure.Data;

namespace ProveedoresApp.Domain.Queries.Proveedor
{
    public class GetProveedorCommandHandler : IRequestHandler<GetProveedorCommand, ProveedorDto>
    {
        private readonly ProveedoresDbContext _context;

        public GetProveedorCommandHandler(ProveedoresDbContext context)
        {
            _context = context;
        }

        public async Task<ProveedorDto> Handle(GetProveedorCommand request, CancellationToken cancellationToken)
        {
            var proveedor = await _context.Proveedores
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == request.Id && p.IsActive, cancellationToken);

            if (proveedor == null)
                return null;

            return new GetProveedorDto
            {
                Id = proveedor.Id,
                RazonSocial = proveedor.RazonSocial,
                NombreComercial = proveedor.NombreComercial,
                IdentificacionTributaria = proveedor.IdentificacionTributaria,
                Telefono = proveedor.Telefono,
                Website = proveedor.Website,
                Email = proveedor.Email,
                Direccion = proveedor.Direccion,
                Pais = proveedor.Pais,
                Facturacion = proveedor.Facturacion,
                UltimaEdicion = proveedor.UltimaEdicion,
                IsActive = proveedor.IsActive
            };
        }
    }
}
