using ControlePlantas.Domain.Commands.Validations;

namespace ControlePlantas.Domain.Commands
{
    public class RemoveEntradaInsumoCommand : EntradaInsumoCommand
    {
        public override bool IsValid
        {
            get
            {
                ValidationResult = new RemoveEntradaInsumoCommandValidation().Validate(this);
                return ValidationResult.IsValid;
            }
        }
    }
}
