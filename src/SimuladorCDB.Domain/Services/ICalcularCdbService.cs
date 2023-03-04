using SimuladorCDB.Domain.Entities;

namespace SimuladorCDB.Domain.Services
{
    public interface ICalcularCdbService
    {
        Task<PrevisaoCdb> CalcularPrevisaoCdb(Cdb investimento);
    }
}
