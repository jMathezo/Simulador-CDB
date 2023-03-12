using AutoMapper;
using FluentAssertions;
using MediatR;
using Moq;
using SimuladorCDB.Application;
using SimuladorCDB.Application.Commands.CalcularPrevisaoCdb;
using SimuladorCDB.Application.Handlers.CalcularPrevisaoCdb;
using SimuladorCDB.Domain.Entities;
using SimuladorCDB.Domain.Services;

namespace Application.UnitTests.Commands
{
    public class CalcularCdbCommandTest
    {
        private readonly IMapper _mapper;
        private readonly CalcularCdbService _calcularCdb;

        public CalcularCdbCommandTest()
        {
            var configuration = new MapperConfiguration(config =>
               config.AddProfile<ApplicationMapperProfile>());

            _mapper = configuration.CreateMapper();

            _calcularCdb = new CalcularCdbService();
        }

        [Fact]
        [Trait(nameof(CalcularPrevisaoCdbCommand), "Success")]
        public async Task Enviado_CalcularPrevisaoCdbCommand_Sem_Mapper_Deve_Retornar_ArgumentNullException()
        {
            //Arrange
            var command = new CalcularPrevisaoCdbCommand(1000, 2);
            var handler = new CalcularPrevisaoCdbCommandHandler(_calcularCdb, _mapper);

            //Act
            var response = await handler.Handle(command, It.IsAny<CancellationToken>());

            //Assert
            Assert.Multiple(() =>
            {
                response.ValorTotalInvestimentoBruto.Should().Be(1019.5344783999999);
                response.ValorRendimentoBruto.Should().Be(19.534478399999898);
                response.ValorIRDebitar.Should().Be(4.395257639999977);
                response.ValorTotalInvestimentoLiquido.Should().Be(1015.13922076);
                response.ValorRendimentoLiquido.Should().Be(15.139220759999944);
            });
        }

        [Fact]
        [Trait(nameof(CalcularPrevisaoCdbCommand), "Success")]
        public async Task Enviado_CalcularPrevisaoCdbCommand_Deve_Retornar_PrevisaoCdb()
        {
            //Arrange
            var command = new CalcularPrevisaoCdbCommand(1000, 2);
            var handler = new CalcularPrevisaoCdbCommandHandler(_calcularCdb, _mapper);

            //Act
            var response = await handler.Handle(command, It.IsAny<CancellationToken>());
            
            //Assert
            Assert.Multiple(() =>
            {
                response.ValorTotalInvestimentoBruto.Should().Be(1019.5344783999999);
                response.ValorRendimentoBruto.Should().Be(19.534478399999898);
                response.ValorIRDebitar.Should().Be(4.395257639999977);
                response.ValorTotalInvestimentoLiquido.Should().Be(1015.13922076);
                response.ValorRendimentoLiquido.Should().Be(15.139220759999944);
            });
        }
    }
}
