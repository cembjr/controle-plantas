using ControlePlantas.Domain.Core.Helper;
using FluentValidation;
using System;

namespace ControlePlantas.Domain.Commands.Validations.AreaPlantio
{
    public class SaidaInsumoCommandValidation<T> : AbstractValidator<T>
    where T : SaidaInsumoCommand
    {
        protected void ValidarId() => RuleFor(x => x.Id).NotEqual(Guid.Empty).WithMessage(MensagemPadrao.NaoDeveSerVazio("Id"));
        protected void ValidarIdEntradaInsumo() => RuleFor(x => x.IdEntradaInsumo).NotEqual(Guid.Empty).WithMessage(MensagemPadrao.NaoDeveSerVazio("IdEntradaInsumo"));
        protected void ValidarQuantidade() => RuleFor(x => x.Quantidade).GreaterThan(0).WithMessage(MensagemPadrao.DeveSerMaiorQueZero("Quantidade"));
        protected void ValidarDataSaida() => RuleFor(x => x.DataSaida).NotEqual(new DateTime(2019, 01, 01)).WithMessage(MensagemPadrao.DeveSerMaiorQue("Data Entrada", "01/01/2019"));
        protected void ValidarIdEmpresa() => RuleFor(x => x.IdEmpresa).NotEqual(Guid.Empty).WithMessage(MensagemPadrao.DeveSerInformado("IdEmpresa"));
    }

    public class RegisterSaidaInsumoCommandValidation : SaidaInsumoCommandValidation<RegisterSaidaInsumoCommand>
    {
        public RegisterSaidaInsumoCommandValidation()
        {
            ValidarIdEntradaInsumo();
            ValidarQuantidade();
            ValidarDataSaida();
            ValidarIdEmpresa();
        }
    }

    public class RemoveSaidaInsumoCommandValidation : SaidaInsumoCommandValidation<RemoveSaidaInsumoCommand>
    {
        public RemoveSaidaInsumoCommandValidation()
        {
            ValidarId();
        }
    }
}



