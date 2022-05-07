using MediatR;
using Microsoft.AspNetCore.Mvc;
using Reservas.Aplicacion.Dtos.Reservas;
using Reservas.Aplicacion.UsesCases.Commands.Pagos.CrearFactura;
using Reservas.Aplicacion.UsesCases.Commands.Pagos.CrearPago;
using Reservas.Aplicacion.UsesCases.Commands.Reservas.CancelarReserva;
using Reservas.Aplicacion.UsesCases.Commands.Reservas.CrearReserva;
using Reservas.Aplicacion.UsesCases.Queries.Pagos.BuscarPagosReserva;
using Reservas.Aplicacion.UsesCases.Queries.Reservas.ObtenerReservaId;
using System;
using System.Threading.Tasks;

namespace Reservas.WebApi.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ReservaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReservaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CrearReservaCommand command)
        {
            Guid id = await _mediator.Send(command);

            if (id == Guid.Empty)
                return BadRequest();

            return Ok(id);
        }
        [Route("Pago")]
        [HttpPost]
        public async Task<IActionResult> CreatePago([FromBody] CrearPagoCommand command)
        {
            Guid id = await _mediator.Send(command);

            if (id == Guid.Empty)
                return BadRequest();

            return Ok(id);
        }
        [Route("CancelarReserva")]
        [HttpPost]
        public async Task<IActionResult> CreateFactura([FromBody] CancelarReservaCommand command)
        {
            Guid id = await _mediator.Send(command);

            if (id == Guid.Empty)
                return BadRequest();

            return Ok(id);
        }

        [Route("{id:guid}")]
        [HttpGet]
        public async Task<IActionResult> ObtenerReservaPorId([FromRoute] ObtenerReservaIdQuery command)
        {
            ReservaDto result = await _mediator.Send(command);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
        [Route("BuscarPagos")]
        [HttpPost]
        public async Task<IActionResult> Search([FromBody] BuscarPagosReservaQuery query)
        {
            var pedidos = await _mediator.Send(query);

            if (pedidos == null)
                return BadRequest();

            return Ok(pedidos);
        }



    }
}
