using ControlePlantas.Domain.Commands.Validations;

namespace ControlePlantas.Domain.Commands
{
    public class UpdateAreaPlantioCommand : AreaPlantioCommand
    {
        public override bool IsValid
        {
            get
            {
                ValidationResult = new UpdateAreaPlantioCommandValidation().Validate(this);
                return ValidationResult.IsValid;
            }
        }


    }
}
