using ControlePlantas.Domain.Commands.Validations;

namespace ControlePlantas.Domain.Commands
{
    public class RegisterAreaPlantioCommand : AreaPlantioCommand
    {
        public override bool IsValid
        {
            get
            {
                ValidationResult = new RegisterAreaPlantioCommandValidation().Validate(this);
                return ValidationResult.IsValid;
            }
        }
    }
}
