using System;
using MediatR;
using ProveedoresApp.Dto.Proveedor;

namespace ProveedoresApp.Domain.Queries.Proveedor
{
    public class GetProveedorCommand : IRequest<ProveedorDto>
    {
        public Guid Id { get; }

        public GetProveedorCommand(Guid id)
        {
            Id = id;
        }
    }
}
