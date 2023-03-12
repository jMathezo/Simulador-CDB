using AutoMapper;
using MediatR;
using SimuladorCDB.Application.Commands.CalcularPrevisaoCdb;
using SimuladorCDB.Domain.Entities;
using SimuladorCDB.Domain.Services;

namespace SimuladorCDB.Application.Handlers.CalcularPrevisaoCdb
{
    public class CalcularPrevisaoCdbCommandHandler : IRequestHandler<CalcularPrevisaoCdbCommand, PrevisaoCdb>
    {
        private readonly ICalcularCdbService _calcularCdb;
        private readonly IMapper _mapper;

        public CalcularPrevisaoCdbCommandHandler(ICalcularCdbService calcularCdbService,
             IMapper mapper)
        {
            _calcularCdb = calcularCdbService ??
                throw new ArgumentNullException(nameof(calcularCdbService));

            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<PrevisaoCdb> Handle(CalcularPrevisaoCdbCommand request,
            CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await _calcularCdb.CalcularPrevisaoCdb(_mapper.Map<Cdb>(request));
        }
    }
}
