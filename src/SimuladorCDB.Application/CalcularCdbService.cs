using SimuladorCDB.Domain.Entities;
using SimuladorCDB.Domain.Services;
using SimuladorCDB.Domain.ValueObjects;

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

            previsaoCDB.ValorTotalInvestimentoBruto = investimento.CalcularValorResgateBruto();
            previsaoCDB.ValorRendimentoBruto = previsaoCDB.ValorTotalInvestimentoBruto - previsaoCDB.ValorAporteInicial;
            previsaoCDB.ValorIRDebitar = CalculaImposto(investimento.PrazoParaResgate, previsaoCDB.ValorRendimentoBruto);
            previsaoCDB.ValorTotalInvestimentoLiquido = previsaoCDB.ValorTotalInvestimentoBruto - previsaoCDB.ValorIRDebitar;
            previsaoCDB.ValorRendimentoLiquido = previsaoCDB.ValorTotalInvestimentoLiquido - previsaoCDB.ValorAporteInicial;

            return await Task.FromResult(previsaoCDB);
        }

        private static double CalculaImposto(int prazoParaResgate, double valorRendimentoBruto)
        {
            var percentualIR = ImpostoDeRenda.GetPercentualIR(prazoParaResgate);

            return valorRendimentoBruto * (percentualIR / 100);
        }
    }
}
