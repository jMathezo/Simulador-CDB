using SimuladorCDB.Domain.Entities;
using SimuladorCDB.Domain.Services;

namespace SimuladorCDB.Application
{
    public class CalcularCdbService : ICalcularCdbService
    {
        public CalcularCdbService() { }

        public async Task<PrevisaoCdb> CalcularPrevisaoCdb(Cdb investimento)
        {
            var previsaoCDB = new PrevisaoCdb(
                investimentoInicial: investimento.ValorAporteInicial,
                prazoParaResgate: investimento.PrazoParaResgate);

            previsaoCDB.CalcularValoresResgate();

            return await Task.FromResult(previsaoCDB);
        }
    }
}
