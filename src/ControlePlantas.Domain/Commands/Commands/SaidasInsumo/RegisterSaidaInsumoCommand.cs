using ControlePlantas.Domain.Commands.Validations.AreaPlantio;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControlePlantas.Domain.Commands
{
    public class RegisterSaidaInsumoCommand : SaidaInsumoCommand
    {
        public override bool IsValid
        {
            get
            {
                ValidationResult = new RegisterSaidaInsumoCommandValidation().Validate(this);
                return ValidationResult.IsValid;
            }
        }
    }
}
