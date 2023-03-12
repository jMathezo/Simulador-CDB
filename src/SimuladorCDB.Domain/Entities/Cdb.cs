using SimuladorCDB.Domain.Exceptions;

namespace SimuladorCDB.Domain.Entities
{
    public class Cdb : Entity
    {
        public Cdb(double valorAporteInicial, int prazoParaResgate)
        {
            ValorAporteInicial = valorAporteInicial;
            PrazoParaResgate = prazoParaResgate;

            Validate();
        }

        public double ValorAporteInicial { get; private set; }
        public int PrazoParaResgate { get; private set; }

        public void Validate()
        {
            if (ValorAporteInicial <= 0)
                throw new AppException("Por favor insira um valor para aporte inicial.");

            if (PrazoParaResgate <= 1)
                throw new AppException("Prazo para resgate deve ser maior que 1(um) mês.");
        }
    }
}
