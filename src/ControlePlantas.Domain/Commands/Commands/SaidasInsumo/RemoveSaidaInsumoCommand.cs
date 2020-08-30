using ControlePlantas.Domain.Commands.Validations.AreaPlantio;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControlePlantas.Domain.Commands
{
    public class RemoveSaidaInsumoCommand : SaidaInsumoCommand
    {
        public override bool IsValid
        { 
            get
            {
                ValidationResult = new RemoveSaidaInsumoCommandValidation().Validate(this);
                return ValidationResult.IsValid;
            }
        }

    }
}
