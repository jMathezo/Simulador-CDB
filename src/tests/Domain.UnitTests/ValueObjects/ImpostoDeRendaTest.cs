using SimuladorCDB.Domain.ValueObjects;

namespace SimuladorCDB.Domain.UnitTests.ValueObjects
{
    public class ImpostoDeRendaTest
    {
        [Theory]
        [InlineData(1, 22.5)]
        [InlineData(9, 20)]
        [InlineData(19, 17.5)]
        [InlineData(30, 15)]
        [Trait(nameof(ImpostoDeRenda), "Success")]
        public void Dado_PrazodeInvestimento_Deve_Retornar_Percentual(int prazoEmMeses, double percentualADebitar)
        {
            //Arrange

            //Act
            var percentual = ImpostoDeRenda.GetPercentualIR(prazoEmMeses);

            //Assert
            Assert.Equal(percentualADebitar, percentual);
        }
    }
}
