using ControlePlantas.Domain.Commands.Validations;

namespace ControlePlantas.Domain.Commands
{
    public class RemoveAreaPlantioCommand : AreaPlantioCommand
    {
        public override bool IsValid
        {
            get
            {
                ValidationResult = new RemoveAreaPlantioCommandValidation().Validate(this);
                return ValidationResult.IsValid;
            }
        }
    }
}
