using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProveedoresApp.Domain.Commands.Proveedor;
using ProveedoresApp.Entity;
using ProveedoresApp.Infrastructure.Data;

public class UpdateProveedorCommandHandler : IRequestHandler<UpdateProveedorCommand, Unit>
{
    private readonly ProveedoresDbContext _context;
    private readonly ILogger<UpdateProveedorCommandHandler> _logger;

    public UpdateProveedorCommandHandler(ProveedoresDbContext context, ILogger<UpdateProveedorCommandHandler> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<Unit> Handle(UpdateProveedorCommand request, CancellationToken cancellationToken)
    {
        var proveedor = await _context.Proveedores
            .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

        if (proveedor == null)
        {
            _logger.LogWarning("Proveedor no encontrado con ID: {Id}", request.Id);
            throw new Exception($"Proveedor con ID {request.Id} no encontrado");
        }

        var dto = request.UpdateProveedorDto;

        proveedor.RazonSocial = dto.RazonSocial;
        proveedor.NombreComercial = dto.NombreComercial;
        proveedor.IdentificacionTributaria = dto.IdentificacionTributaria;
        proveedor.Telefono = dto.Telefono;
        proveedor.Website = dto.Website;
        proveedor.Email = dto.Email;
        proveedor.Direccion = dto.Direccion;
        proveedor.Pais = dto.Pais;
        proveedor.Facturacion = dto.Facturacion;
        proveedor.UltimaEdicion = DateTime.UtcNow;

        await _context.SaveChangesAsync(cancellationToken);

        _logger.LogInformation("Proveedor actualizado con ID: {Id}", proveedor.Id);
        return Unit.Value;
    }
}
