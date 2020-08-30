using ControlePlantas.Domain.Commands.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControlePlantas.Domain.Commands
{
    public class RegisterFornecedorCommand : FornecedorCommand
    {
        public override bool IsValid
        {
            get
            {
                ValidationResult = new RegisterFornecedorCommandValidation().Validate(this);
                return ValidationResult.IsValid;
            }
        }
    }
}
