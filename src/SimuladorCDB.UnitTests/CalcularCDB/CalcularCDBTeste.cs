using FluentAssertions;
using SimuladorCDB.Application;
using SimuladorCDB.Domain.Entities;
using SimuladorCDB.Domain.Services;

namespace SimuladorCDB.UnitTests.CalcularCDB
{
    public class CalcularCdbTeste
    {
        private readonly ICalcularCdbService _calcularCDB;

        public CalcularCdbTeste()
        {
            _calcularCDB = new CalcularCdbService();
        }

        [Theory]
        [InlineData(1000,1)]
        [Trait(nameof(ICalcularCdbService.CalcularPrevisaoCdb), "Success")]
        public async Task Dado_AporteInicial_PrazoInvestimento_Ate_6_meses_Deve_RetornarPrevisaoCDB(double valorAporteInicial, int prazoEmMeses)
        {
            //Arrange
            var cdb = new Cdb(valorAporteInicial, prazoEmMeses);

            //Act
            var previsaoCDB = await _calcularCDB.CalcularPrevisaoCdb(cdb);

            //Assert
            Assert.Multiple(() =>
            {
                previsaoCDB.ValorTotalInvestimentoBruto.Should().Be(1009.7199999999999);
                previsaoCDB.ValorRendimentoBruto.Should().Be(9.719999999999914);
                previsaoCDB.ValorIRDebitar.Should().Be(2.1869999999999807);
                previsaoCDB.ValorTotalInvestimentoLiquido.Should().Be(1007.5329999999999);
                previsaoCDB.ValorRendimentoLiquido.Should().Be(7.532999999999902);
            });
        }
    }
}
