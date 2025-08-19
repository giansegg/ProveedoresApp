using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using ProveedoresApp.Domain.Commands.Proveedor;
using ProveedoresApp.Domain.Queries.Proveedor;
using ProveedoresApp.Dto.Proveedor;

namespace ProveedoresApp.Api.Controllers
{
    [ApiController]
    [Route("api/proveedores")]
    public class ProveedoresController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProveedoresController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProveedorDto dto)
        {
            var command = new CreateProveedorCommand(dto);
            var id = await _mediator.Send(command);

            var query = new GetProveedorCommand(id);
            var proveedorCreado = await _mediator.Send(query);

            return CreatedAtAction(nameof(Get), new { id }, proveedorCreado);
        }

            [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateProveedorDto dto)
        {
            var command = new UpdateProveedorCommand(id, dto);
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetProveedorDto>> Get(Guid id)
        {
            var query = new GetProveedorCommand(id);
            var result = await _mediator.Send(query);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<GetProveedorDto>>> List()
        {
            var query = new ListProveedorCommand();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteProveedorCommand(id);
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
