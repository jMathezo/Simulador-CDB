using AutoMapper;
using SimuladorCDB.Application.Commands.CalcularPrevisaoCdb;
using SimuladorCDB.Domain.Entities;

/// <inheritdoc />
namespace SimuladorCDB.Application
{
    public class ApplicationMapperProfile : Profile
    {
        /// <inheritdoc />
        public ApplicationMapperProfile()
        {
            CreateMap<CalcularPrevisaoCdbCommand, Cdb>()
                .ConstructUsing(x => new Cdb(x.ValorAporteInicial, x.PrazoParaResgate))
                .ReverseMap();
        }
    }
}
