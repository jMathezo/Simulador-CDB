using SimuladorCDB.Domain.ValueObjects;

namespace SimuladorCDB.Domain.Entities
{
    public class PrevisaoCdb : Cdb
    {
        public PrevisaoCdb(double investimentoInicial, int prazoParaResgate) : 
            base(investimentoInicial, prazoParaResgate)
        {
        }
        public double ValorTotalInvestimentoBruto { get; private set; }
        public double ValorRendimentoBruto { get; private set; }
        public double ValorIRDebitar { get; private set; }
        public double ValorTotalInvestimentoLiquido { get; private set; }
        public double ValorRendimentoLiquido { get; private set; }

        public void CalcularValoresResgate()
        {
            ValorTotalInvestimentoBruto = CalcularValorResgateBruto();
            ValorRendimentoBruto = ValorTotalInvestimentoBruto - ValorAporteInicial;
            ValorIRDebitar = CalcularImposto(PrazoParaResgate, ValorRendimentoBruto);
            ValorTotalInvestimentoLiquido = ValorTotalInvestimentoBruto - ValorIRDebitar;
            ValorRendimentoLiquido = ValorTotalInvestimentoLiquido - ValorAporteInicial;
        }

        private double CalcularValorResgateBruto()
        {
            var valorResgateBruto = ValorAporteInicial;

            for (int mes = 0; mes < PrazoParaResgate; mes++)
                valorResgateBruto *= (1 + ((Taxas.Cdi / 100) * (Taxas.Tb / 100)));

            return valorResgateBruto;
        }

        private double CalcularImposto(int prazoParaResgate, double valorRendimentoBruto)
        {
            var percentualIR = ImpostoDeRenda.GetPercentualIR(prazoParaResgate);

            return valorRendimentoBruto * (percentualIR / 100);
        }
    }
}