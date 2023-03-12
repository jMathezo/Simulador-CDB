using FluentAssertions;
using SimuladorCDB.Application;
using SimuladorCDB.Domain.Entities;
using SimuladorCDB.Domain.Services;

namespace Application.UnitTests.Services
{
    public class CalcularCdbServiceTests
    {
        private readonly CalcularCdbService _calcularCdb;

        public CalcularCdbServiceTests()
        {
            _calcularCdb = new CalcularCdbService();
        }

        [Theory]
        [InlineData(1000, 2)]
        [Trait(nameof(ICalcularCdbService.CalcularPrevisaoCdb), "Success")]
        public async Task Dado_AporteInicial_PrazoInvestimento_Ate_6_meses_Deve_RetornarPrevisaoCDB(double valorAporteInicial, int prazoEmMeses)
        {
            //Arrange
            var cdb = new Cdb(valorAporteInicial, prazoEmMeses);

            //Act
            var previsaoCDB = await _calcularCdb.CalcularPrevisaoCdb(cdb);

            //Assert
            Assert.Multiple(() =>
            {
                previsaoCDB.ValorTotalInvestimentoBruto.Should().Be(1019.5344783999999);
                previsaoCDB.ValorRendimentoBruto.Should().Be(19.534478399999898);
                previsaoCDB.ValorIRDebitar.Should().Be(4.395257639999977);
                previsaoCDB.ValorTotalInvestimentoLiquido.Should().Be(1015.13922076);
                previsaoCDB.ValorRendimentoLiquido.Should().Be(15.139220759999944);
            });
        }
    }
}
