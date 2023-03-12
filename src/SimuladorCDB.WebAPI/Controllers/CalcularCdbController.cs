using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimuladorCDB.Application.Commands.CalcularPrevisaoCdb;
using SimuladorCDB.Domain.Entities;
using SimuladorCDB.WebAPI.Models;

namespace SimuladorCDB.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalcularCdbController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CalcularCdbController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(PrevisaoCdb), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CalcularCDB([FromQuery] CalcularPrevisaoCdbCommand request)
        {

            var previsaoCDB = await _mediator.Send(request);

            return Ok(previsaoCDB);
        }
    }
}
