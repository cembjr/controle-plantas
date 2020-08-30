using ControlePlantas.Domain.Commands.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControlePlantas.Domain.Commands
{
    public class RegisterPlantacaoCommand : PlantacaoCommand
    {
        public override bool IsValid
        {
            get
            {
                ValidationResult = new RegisterPlantacaoCommandValidation().Validate(this);
                return ValidationResult.IsValid;
            }
        }
    }
}
