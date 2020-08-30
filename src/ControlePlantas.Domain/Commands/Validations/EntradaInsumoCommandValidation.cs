using ControlePlantas.Domain.Core.Helper;
using FluentValidation;
using System;

namespace ControlePlantas.Domain.Commands.Validations
{
    public class EntradaInsumoCommandValidation<T> : AbstractValidator<T>
    where T : EntradaInsumoCommand
    {
        protected void ValidarId() => RuleFor(x => x.Id).NotEqual(Guid.Empty).WithMessage(MensagemPadrao.NaoDeveSerVazio("Id"));
        protected void ValidarIdInsumo() => RuleFor(x => x.IdFornecedor).NotEqual(Guid.Empty).WithMessage(MensagemPadrao.NaoDeveSerVazio("IdInsumo"));
        
        protected void ValidarDataEntrada() => RuleFor(x => x.DataEntrada).GreaterThanOrEqualTo(new DateTime(2019, 01, 01)).WithMessage(MensagemPadrao.DeveSerMaiorQue("Data Entrada", "01/01/2019"));
        protected void ValidarIdFornecedor() => RuleFor(x => x.IdFornecedor).NotEqual(Guid.Empty).WithMessage(MensagemPadrao.NaoDeveSerVazio("IdFornecedor"));
        protected void ValidarQuantidade() => RuleFor(x => x.Quantidade).GreaterThan(0).WithMessage(MensagemPadrao.DeveSerMaiorQueZero("Quantidade"));
        protected void ValidarValorUnitario() => RuleFor(x => x.ValorUnitario).GreaterThan(0).WithMessage(MensagemPadrao.DeveSerMaiorQueZero("ValorUnitario"));
        protected void ValidarIdEmpresa() => RuleFor(x => x.IdEmpresa).NotEqual(Guid.Empty).WithMessage(MensagemPadrao.DeveSerInformado("IdEmpresa"));

    }

    public class RegisterEntradaInsumoCommandValidation : EntradaInsumoCommandValidation<EntradaInsumoCommand>
    {
        public RegisterEntradaInsumoCommandValidation()
        {
            ValidarIdInsumo();
            ValidarIdFornecedor();
            ValidarQuantidade();
            ValidarValorUnitario();
            ValidarIdEmpresa();
        }
    }

    public class RemoveEntradaInsumoCommandValidation : EntradaInsumoCommandValidation<EntradaInsumoCommand>
    {
        public RemoveEntradaInsumoCommandValidation()
        {
            ValidarId();
        }
    }
}

