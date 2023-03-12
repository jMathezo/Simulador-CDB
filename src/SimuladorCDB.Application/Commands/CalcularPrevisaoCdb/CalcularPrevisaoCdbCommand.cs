using MediatR;
using SimuladorCDB.Domain.Entities;

namespace SimuladorCDB.Application.Commands.CalcularPrevisaoCdb
{
    public record CalcularPrevisaoCdbCommand(double ValorAporteInicial, int PrazoParaResgate) : IRequest<PrevisaoCdb>;
}
