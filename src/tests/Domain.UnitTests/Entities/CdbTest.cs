using SimuladorCDB.Domain.Entities;
using SimuladorCDB.Domain.Exceptions;

namespace SimuladorCDB.Domain.UnitTests.Entities
{
    public class CdbTest
    {
        [Fact]
        [Trait(nameof(Cdb), "Success")]
        public void Dado_ValorAporteInicial_Igual_Ou_Menorque_0_Deve_Retornar_AppException()
        {
            //Arrange

            //Act
            var error =  Assert.ThrowsAny<AppException>(
                () => new Cdb(valorAporteInicial: 0, prazoParaResgate: 1));

            //Assert
            Assert.IsType<AppException>(error);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [Trait(nameof(Cdb), "Success")]
        public void Dado_PrazodeInvestimento_Igual_Ou_Menorque_1_Deve_Retornar_AppException(int prazoResgate)
        {
            //Arrange

            //Act
            var error = Assert.ThrowsAny<AppException>(
                () => new Cdb(valorAporteInicial: 10, prazoParaResgate: prazoResgate));

            //Assert
            Assert.IsType<AppException>(error);
        }
    }
}
