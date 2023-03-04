namespace SimuladorCDB.Domain.Entities
{
    public class PrevisaoCdb : Cdb
    {
        public PrevisaoCdb(double investimentoInicial, int prazoParaResgate) : 
            base(investimentoInicial, prazoParaResgate)
        {
        }
        public double ValorTotalInvestimentoBruto { get; set; }
        public double ValorRendimentoBruto { get; set; }
        public double ValorRendimentoLiquido { get; set; }
        public double ValorTotalInvestimentoLiquido { get; set; }
        public double ValorIRDebitar { get; set; }
    }
}