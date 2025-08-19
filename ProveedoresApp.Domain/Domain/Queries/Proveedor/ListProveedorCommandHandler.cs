using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProveedoresApp.Infrastructure;
using ProveedoresApp.Dto.Proveedor;
using System;
using ProveedoresApp.Infrastructure.Data;

namespace ProveedoresApp.Domain.Queries.Proveedor
{
    public class ListProveedorCommandHandler : IRequestHandler<ListProveedorCommand, List<GetProveedorDto>>
    {
        private readonly ProveedoresDbContext _context;

        public ListProveedorCommandHandler(ProveedoresDbContext context)
        {
            _context = context;
        }

        public async Task<List<GetProveedorDto>> Handle(ListProveedorCommand request, CancellationToken cancellationToken)
        {
            var proveedores = await _context.Proveedores
                .AsNoTracking()
                .Where(p => p.IsActive)
                .Select(p => new GetProveedorDto
                {
                    Id = p.Id,
                    RazonSocial = p.RazonSocial,
                    NombreComercial = p.NombreComercial,
                    IdentificacionTributaria = p.IdentificacionTributaria,
                    Telefono = p.Telefono,
                    Website = p.Website,
                    Email = p.Email,
                    Direccion = p.Direccion,
                    Pais = p.Pais,
                    Facturacion = p.Facturacion,
                    UltimaEdicion = p.UltimaEdicion,
                    IsActive = p.IsActive
                })
                .ToListAsync(cancellationToken);

            return proveedores;
        }
    }
}
