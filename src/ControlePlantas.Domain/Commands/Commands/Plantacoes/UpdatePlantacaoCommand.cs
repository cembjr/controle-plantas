using ControlePlantas.Domain.Commands.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControlePlantas.Domain.Commands
{
    public class UpdatePlantacaoCommand : PlantacaoCommand
    {
        public override bool IsValid
        {
            get
            {
                ValidationResult = new UpdatePlantacaoCommandValidation().Validate(this);
                return ValidationResult.IsValid;
            }
        }
    }
}
