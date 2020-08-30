using ControlePlantas.Domain.Commands.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControlePlantas.Domain.Commands
{
    public class RegisterInsumoCommand : InsumoCommand
    {
        public override bool IsValid
        {
            get
            {
                ValidationResult = new RegisterInsumoCommandValidation().Validate(this);
                return ValidationResult.IsValid;
            }
        }
    }
}
