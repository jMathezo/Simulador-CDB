using FluentValidation;

namespace SimuladorCDB.WebAPI.Models.CalcularCDB
{
    public record CalcularCdbRequest(double ValorAporteInicial, int PrazoParaResgate);

    public class CalcularCdbRequestValidator : AbstractValidator<CalcularCdbRequest>
    {
        public CalcularCdbRequestValidator()
        {
            RuleFor(cdb => cdb.ValorAporteInicial).GreaterThan(0).WithMessage("Por favor insira um valor para aporte inicial.");
            RuleFor(cdb => cdb.PrazoParaResgate).GreaterThan(1).WithMessage("Prazo para resgate deve ser maior que 1(um) mês.");
        }
    }
}