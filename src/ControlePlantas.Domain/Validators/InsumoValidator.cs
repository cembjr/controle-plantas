using ControlePlantas.Domain.Core.Enums;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControlePlantas.Domain.Validators
{
    public class InsumoValidator : AbstractValidator<Insumo>
    {
        public InsumoValidator()
        {
            RuleSet(EnumValidationType.Deletar.ToString(), ValidarDelecao);
        }

        private void ValidarDelecao()
        {
            
        }
    }
}
