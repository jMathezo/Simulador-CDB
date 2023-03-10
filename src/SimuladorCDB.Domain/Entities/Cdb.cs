namespace SimuladorCDB.Domain.Entities
{
    public class Cdb : Entity
    {
        public Cdb(double investimentoInicial, int prazoParaResgate)
        {
            ValorAporteInicial = investimentoInicial;
            PrazoParaResgate = prazoParaResgate;
        }

        public double ValorAporteInicial { get; private set; }
        public int PrazoParaResgate { get; private set; }

    }
}
