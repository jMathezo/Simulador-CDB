namespace SimuladorCDB.Domain.Entities
{
    public class Cdb : Entity
    {
        public Cdb(double investimentoInicial, int prazoParaResgate)
        {
            ValorAporteInicial = investimentoInicial;
            PrazoParaResgate = prazoParaResgate;
        }

        private readonly double _Cdi = 0.9;
        private readonly double _Tb = 108;
        public double ValorAporteInicial { get; private set; }
        public int PrazoParaResgate { get; private set; }

        public double CalcularValorResgateBruto()
        {
            var valorResgateBruto = ValorAporteInicial;

            for (int mes = 0; mes < PrazoParaResgate; mes++)
                valorResgateBruto *= (1 + ((_Cdi / 100) * (_Tb / 100)));

            return valorResgateBruto;
        }
    }
}
