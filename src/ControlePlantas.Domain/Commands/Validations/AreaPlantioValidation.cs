using ControlePlantas.Domain.Core.Helper;
using FluentValidation;
using System;

namespace ControlePlantas.Domain.Commands.Validations
{
    public class AreaPlantioCommandValidation<T> : AbstractValidator<T>
    where T : AreaPlantioCommand
    {

        protected void ValidarId() =>  RuleFor(x => x.Id).NotEqual(Guid.Empty).WithMessage(MensagemPadrao.NaoDeveSerVazio("Id"));
        protected void ValidarDescricao() => RuleFor(x => x.Descricao).NotEmpty().WithMessage(MensagemPadrao.NaoDeveSerVazio("Descrição"));         
        protected void ValidarTamanhoAlqueires() => RuleFor(x => x.TamanhoAlqueires).GreaterThan(0).WithMessage(MensagemPadrao.DeveSerMaiorQueZero("Tamanho Alqueires"));
        protected void ValidarTamanhoHectares() => RuleFor(x => x.TamanhoHectares).GreaterThan(0).WithMessage(MensagemPadrao.DeveSerMaiorQueZero("Tamanho Hectares"));
        protected void ValidarIdEmpresa() => RuleFor(x => x.IdEmpresa).NotEqual(Guid.Empty).WithMessage(MensagemPadrao.DeveSerInformado("IdEmpresa"));

    }

    public class RegisterAreaPlantioCommandValidation : AreaPlantioCommandValidation<RegisterAreaPlantioCommand>
    {
        public RegisterAreaPlantioCommandValidation()
        {
            ValidarDescricao();
            ValidarTamanhoAlqueires();
            ValidarTamanhoHectares();
            ValidarIdEmpresa();
        }
    }

    public class UpdateAreaPlantioCommandValidation : AreaPlantioCommandValidation<UpdateAreaPlantioCommand>
    {
        public UpdateAreaPlantioCommandValidation()
        {
            ValidarId();
            ValidarDescricao();
            ValidarTamanhoAlqueires();
            ValidarTamanhoHectares();
            ValidarIdEmpresa();
        }
    }

    public class RemoveAreaPlantioCommandValidation : AreaPlantioCommandValidation<RemoveAreaPlantioCommand>
    {
        public RemoveAreaPlantioCommandValidation()
        {
            ValidarId();           
        }
    }

}
