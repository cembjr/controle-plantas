using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using FluentValidation.Results;

namespace ControlePlantas.Domain.Core
{
    public class DomainException : Exception
    {
        public IDictionary<string, object> Erros { get; set; }
        public DomainException()
        {
            Erros = new Dictionary<string, object>();
        }

        public DomainException(string message) : base(message)
        {
            Erros = new Dictionary<string, object>();
        }

        public DomainException(string message, Exception innerException) : base(message, innerException)
        {
            Erros = new Dictionary<string, object>();
        }

        public DomainException(IEnumerable<ValidationFailure> lstFailure, string message = "Um ou mais erros foram encontrados") :
            base(message)
        {
            Erros = new Dictionary<string, object>();
            lstFailure.ToList().ForEach(fail => Erros.Add(fail.PropertyName, fail.ErrorMessage));
        }

        public DomainException AddError(string chave, string mensagem)
        {
            Erros.Add(chave, mensagem);
            return this;
        }
    }
}
