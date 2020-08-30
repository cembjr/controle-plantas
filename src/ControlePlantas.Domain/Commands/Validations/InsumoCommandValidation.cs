using ControlePlantas.Domain.Core.Helper;
using ControlePlantas.Domain.Enums;
using FluentValidation;
using System;

namespace ControlePlantas.Domain.Commands.Validations
{
    public class InsumoCommandValidation<T> : AbstractValidator<T>
    where T : InsumoCommand
    {                  
        protected void ValidarId() => RuleFor(x => x.Id).NotEqual(Guid.Empty).WithMessage(MensagemPadrao.NaoDeveSerVazio("Id"));
        protected void ValidarNome() => RuleFor(r => r.Nome).NotEmpty().WithMessage(MensagemPadrao.NaoDeveSerVazio("Nome")).MinimumLength(3).WithMessage(MensagemPadrao.DeveSerMaiorQue("Nome", "3"));
        protected void ValidarTipoInsumo() => RuleFor(r => r.TipoInsumo).NotEqual(EnumTipoInsumo.Indefinido).WithMessage(MensagemPadrao.DeveSerDefinido("Tipo Insumo"));
        protected void ValidarIdEmpresa() => RuleFor(x => x.IdEmpresa).NotEqual(Guid.Empty).WithMessage(MensagemPadrao.DeveSerInformado("IdEmpresa"));

    }

    public class RegisterInsumoCommandValidation : InsumoCommandValidation<InsumoCommand>
    {
        public RegisterInsumoCommandValidation()
        {
            ValidarNome();
            ValidarTipoInsumo();
            ValidarIdEmpresa();
        }
    }

    public class RemoveInsumoCommandValidation : InsumoCommandValidation<InsumoCommand>
    {
        public RemoveInsumoCommandValidation()
        {
            ValidarId();
        }
    }
}
