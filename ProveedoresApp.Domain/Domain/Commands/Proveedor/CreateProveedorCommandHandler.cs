using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProveedoresApp.Domain.Commands.Proveedor;
using ProveedoresApp.Entity;
using ProveedoresApp.Infrastructure;
using ProveedoresApp.Infrastructure.Data;


public class CreateProveedorCommandHandler : IRequestHandler<CreateProveedorCommand, Guid>
{
    private readonly ProveedoresDbContext _context;
    private readonly ILogger<CreateProveedorCommandHandler> _logger;

    public CreateProveedorCommandHandler(ProveedoresDbContext context, ILogger<CreateProveedorCommandHandler> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<Guid> Handle(CreateProveedorCommand request, CancellationToken cancellationToken)
    {
        var dto = request.CreateProveedorDto;

        var exists = await _context.Proveedores.AnyAsync(p => p.RazonSocial == dto.RazonSocial, cancellationToken);
        if (exists)
        {
            _logger.LogWarning("Proveedor duplicado con RUC: {RUC}", dto.RazonSocial);
            throw new Exception($"Ya existe un proveedor con el RUC {dto.RazonSocial}");
        }

        var proveedor = new Proveedor
        {
            Id = Guid.NewGuid(),
            RazonSocial = dto.RazonSocial,
            NombreComercial = dto.NombreComercial,
            IdentificacionTributaria = dto.IdentificacionTributaria,
            Telefono = dto.Telefono,
            Website = dto.Website,
            Email = dto.Email,
            Direccion = dto.Direccion,
            Pais = dto.Pais,
            Facturacion = dto.Facturacion,
            UltimaEdicion = DateTime.UtcNow,
            IsActive = true 
            
        };

        _context.Proveedores.Add(proveedor);
        await _context.SaveChangesAsync(cancellationToken);

        _logger.LogInformation("Proveedor creado con ID: {Id}", proveedor.Id);
        return proveedor.Id;
    }
}
