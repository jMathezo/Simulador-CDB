using SimuladorCDB.Domain.Entities;

namespace SimuladorCDB.Domain.Services
{
    public interface ICalcularCdbService
    {
        /// <summary>
        /// Calcula valores da previsão
        /// </summary>
        /// <param name="investimento"> objeto do tipo cdb </param>
        /// <returns> objeto do tipo Previsão Cdb </returns>
        Task<PrevisaoCdb> CalcularPrevisaoCdb(Cdb investimento);
    }
}
