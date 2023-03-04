using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SimuladorCDB.Domain.Entities;
using SimuladorCDB.Domain.Services;
using SimuladorCDB.WebAPI.Models.CalcularCDB;
using SimuladorCDB.WebAPI.Models.Error;

namespace SimuladorCDB.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalcularCdbController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICalcularCdbService _calcularCDB;
        private readonly IValidator<CalcularCdbRequest> _calcularCDBValidator;

        public CalcularCdbController(
            ICalcularCdbService calcularCDB,
            IValidator<CalcularCdbRequest> calcularCDBValidator,
            IMapper mapper)
        {
            _calcularCDB = calcularCDB ??
                throw new ArgumentNullException(nameof(calcularCDB));
            _calcularCDBValidator = calcularCDBValidator ??
                throw new ArgumentNullException(nameof(calcularCDBValidator));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<IActionResult> CalcularCDB([FromQuery] CalcularCdbRequest request)
        {
            var validationResult = _calcularCDBValidator.Validate(request);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.ToCustomValidationFailure());
            }

            var previsaoCDB = await _calcularCDB.CalcularPrevisaoCdb(_mapper.Map<Cdb>(request));

            return Ok(previsaoCDB);
        }
    }
}
