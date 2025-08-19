using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using ProveedoresApp.Entity;
using ProveedoresApp.Infrastructure;
using ProveedoresApp.Infrastructure.Data;

namespace ProveedoresApp.Domain.Commands.Proveedor
{
    public class DeleteProveedorCommandHandler : IRequestHandler<DeleteProveedorCommand, Unit>
    {
        private readonly ProveedoresDbContext _context;
        private readonly ILogger<DeleteProveedorCommandHandler> _logger;

        public DeleteProveedorCommandHandler(ProveedoresDbContext context, ILogger<DeleteProveedorCommandHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteProveedorCommand request, CancellationToken cancellationToken)
        {
            var proveedor = await _context.Proveedores
                .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

            if (proveedor == null)
            {
                _logger.LogWarning("Proveedor no encontrado con ID: {Id}", request.Id);
                throw new Exception($"Proveedor con ID {request.Id} no encontrado");
            }

            proveedor.IsActive = false;
            await _context.SaveChangesAsync(cancellationToken);

            _logger.LogInformation("Proveedor desactivado (eliminación lógica) con ID: {Id}", proveedor.Id);
            return Unit.Value;
        }
    }
}
