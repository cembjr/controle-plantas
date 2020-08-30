using ControlePlantas.Domain.Core.Helper;
using FluentValidation;
using System;

namespace ControlePlantas.Domain.Commands.Validations
{
    class FornecedorCommandValidation
    {
    }

    public class FornecedorCommandValidation<T> : AbstractValidator<T>
    where T : FornecedorCommand
    {
        protected void ValidarId() => RuleFor(x => x.Id).NotEqual(Guid.Empty).WithMessage(MensagemPadrao.NaoDeveSerVazio("Id"));
        protected void ValidarNome() => RuleFor(x => x.Nome).NotEmpty().WithMessage(MensagemPadrao.DeveSerInformado("Nome"));
        protected void ValidarEnderecoLogradouro() => RuleFor(x => x.Endereco.Logradouro).NotEmpty().WithMessage(MensagemPadrao.DeveSerInformado("Logradouro"));
        protected void ValidarEnderecoCEP() => RuleFor(x => x.Endereco.CEP).Length(8).WithMessage(MensagemPadrao.DeveConterXCaracteres("CEP",8));
        protected void ValidarIdEmpresa() => RuleFor(x => x.IdEmpresa).NotEqual(Guid.Empty).WithMessage(MensagemPadrao.DeveSerInformado("IdEmpresa"));
    }

    public class RegisterFornecedorCommandValidation : FornecedorCommandValidation<FornecedorCommand>
    {
        public RegisterFornecedorCommandValidation()
        {
            ValidarNome();
            ValidarEnderecoLogradouro();
            ValidarEnderecoCEP();
            ValidarIdEmpresa();
        }
    }

    public class RemoveFornecedorCommandValidation : FornecedorCommandValidation<FornecedorCommand>
    {
        public RemoveFornecedorCommandValidation()
        {
            ValidarId();
        }
    }
}
