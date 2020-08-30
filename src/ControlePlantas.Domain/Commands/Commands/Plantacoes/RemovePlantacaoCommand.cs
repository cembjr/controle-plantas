using ControlePlantas.Domain.Commands.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControlePlantas.Domain.Commands
{
    public class RemovePlantacaoCommand : PlantacaoCommand
    {
        public override bool IsValid
        {
            get
            {
                ValidationResult = new RemovePlantacaoCommandValidation().Validate(this);
                return ValidationResult.IsValid;
            }
        }
    }
}
