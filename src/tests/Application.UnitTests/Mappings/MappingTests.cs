using AutoMapper;
using SimuladorCDB.Application;
using SimuladorCDB.Application.Commands.CalcularPrevisaoCdb;
using SimuladorCDB.Domain.Entities;

namespace Application.UnitTests.Mappings
{
    public class MappingTests
    {
        private readonly IConfigurationProvider _configuration;
        private readonly IMapper _mapper;

        public MappingTests()
        {
            _configuration = new MapperConfiguration(config =>
                config.AddProfile<ApplicationMapperProfile>());

            _mapper = _configuration.CreateMapper();
        }

        [Fact]
        [Trait(nameof(ApplicationMapperProfile), "Success")]
        public void Dado_CalcularPrevisaoCdbCommand_Deve_Retornar_Cdb()
        {
            var retorno = _mapper.Map<Cdb>(new CalcularPrevisaoCdbCommand(1000, 2));

            Assert.True(retorno.GetType() == typeof(Cdb));
        }
    }
}
