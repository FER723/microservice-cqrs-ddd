using FluentValidation;
using ServicioPrueba.Application.Atributos.AddAtributos;

namespace ServicioLiquidacion.Application.Liquidacion.LiquidacionAgrupada.CrearLiquidacionAgrupada
{
    public class AtributosDeleteCommandValidator : AbstractValidator<AtributosDeleteCommand>
    {
        public AtributosDeleteCommandValidator()
        {
            RuleFor(x => x.AtributoId).NotEmpty().WithMessage("Atributo ID is empty");
        }
    }
}
