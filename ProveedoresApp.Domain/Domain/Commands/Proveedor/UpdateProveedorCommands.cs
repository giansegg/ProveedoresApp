using System;
using MediatR;
using ProveedoresApp.Dto.Proveedor;

namespace ProveedoresApp.Domain.Commands.Proveedor
{
    public class UpdateProveedorCommand : IRequest<Unit>
    {
        public Guid Id { get; }
        public UpdateProveedorDto UpdateProveedorDto { get; }

        public UpdateProveedorCommand(Guid id, UpdateProveedorDto updateDto)
        {
            Id = id;
            UpdateProveedorDto = updateDto;
        }
    }
}
