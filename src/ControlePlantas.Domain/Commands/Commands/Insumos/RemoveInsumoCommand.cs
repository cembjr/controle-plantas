using ControlePlantas.Domain.Commands.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControlePlantas.Domain.Commands
{
    public class RemoveInsumoCommand : InsumoCommand
    {
        public override bool IsValid
        {
            get
            {
                ValidationResult = new RemoveInsumoCommandValidation().Validate(this);
                return ValidationResult.IsValid;
            }
        }
    }
}
