
using System;
using MediatR;
using ProveedoresApp.Domain.Commands.Proveedor;
using ProveedoresApp.Dto.Proveedor;

namespace ProveedoresApp.Domain.Commands.Proveedor
{
   

public class CreateProveedorCommand : IRequest<Guid>
    {
        public CreateProveedorDto CreateProveedorDto { get; }

        public CreateProveedorCommand(CreateProveedorDto createDto)
        {
            CreateProveedorDto = createDto;
        }
    }
}