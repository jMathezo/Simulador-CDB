using AutoMapper;
using SimuladorCDB.Domain.Entities;
using SimuladorCDB.WebAPI.Models.CalcularCDB;

namespace SimuladorCDB.WebAPI
{
    /// <inheritdoc />
    public class WebApiMapperProfile : Profile
    {
        /// <inheritdoc />
        public WebApiMapperProfile()
        {
            CreateMap<CalcularCdbRequest, Cdb>()
                .ConstructUsing(x => new Cdb(x.ValorAporteInicial, x.PrazoParaResgate))
                .ReverseMap();
        }
    }
}
