using ControlePlantas.Domain.Core.Model;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePlantas.Domain.Commands
{
    public abstract class Command : IRequest<ResponseResult>
    {
        public abstract bool IsValid { get; }
        public ValidationResult ValidationResult { get; set; }

        public IDictionary<string, object> Erros
        {
            get
            {
                return ValidationResult?.Errors?.ToDictionary(x => x.PropertyName, x => (object) x.ErrorMessage);
            }
        }
    }
}
