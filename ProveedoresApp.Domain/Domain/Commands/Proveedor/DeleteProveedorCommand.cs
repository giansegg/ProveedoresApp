using System;
using MediatR;

namespace ProveedoresApp.Domain.Commands.Proveedor
{
    public class DeleteProveedorCommand : IRequest<Unit>
    {
        public Guid Id { get; }

        public DeleteProveedorCommand(Guid id)
        {
            Id = id;
        }
    }
}
