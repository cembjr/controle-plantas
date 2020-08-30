using ControlePlantas.Domain.Commands.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControlePlantas.Domain.Commands
{
    public class RegisterEntradaInsumoCommand : EntradaInsumoCommand
    {
        public override bool IsValid
        {
            get
            {
                ValidationResult = new RegisterEntradaInsumoCommandValidation().Validate(this);
                return ValidationResult.IsValid;
            }
        }
    }
}
