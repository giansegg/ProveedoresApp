using System.Collections.Generic;
using MediatR;
using ProveedoresApp.Dto.Proveedor;

namespace ProveedoresApp.Domain.Queries.Proveedor
{
    public class ListProveedorCommand : IRequest<List<GetProveedorDto>>
    {
    }
}
