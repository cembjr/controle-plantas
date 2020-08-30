using ControlePlantas.Domain.Core.Helper;
using FluentValidation;
using System;

namespace ControlePlantas.Domain.Commands.Validations
{
    public class PlantacaoCommandValidation<T> : AbstractValidator<T>
    where T : PlantacaoCommand
    {   
        protected void ValidarId() => RuleFor(x => x.Id).NotEqual(Guid.Empty).WithMessage(MensagemPadrao.NaoDeveSerVazio("Id"));
        protected void ValidarDescricao() => RuleFor(x => x.Descricao).NotEmpty().WithMessage(MensagemPadrao.DeveSerInformado("Descrição"));        
        protected void ValidarIdAreaPlantio() => RuleFor(x => x.IdAreaPlantio).NotEqual(Guid.Empty).WithMessage(MensagemPadrao.NaoDeveSerVazio("Id"));
        protected void ValidarDataInicial() => RuleFor(x => x.DataInicial).GreaterThanOrEqualTo(new DateTime(2019, 01, 01)).WithMessage(MensagemPadrao.DeveSerMaiorQue("Data Inicio", "01/01/2019"));
        protected void ValidarIdEmpresa() => RuleFor(x => x.IdEmpresa).NotEqual(Guid.Empty).WithMessage(MensagemPadrao.DeveSerInformado("IdEmpresa"));

    }

    public class RegisterPlantacaoCommandValidation : PlantacaoCommandValidation<PlantacaoCommand>
    {
        public RegisterPlantacaoCommandValidation()
        {
            ValidarId();
            ValidarDescricao();
            ValidarIdAreaPlantio();
            ValidarDataInicial();
            ValidarIdEmpresa();
        }
    }

    public class UpdatePlantacaoCommandValidation : PlantacaoCommandValidation<PlantacaoCommand>
    {
        public UpdatePlantacaoCommandValidation()
        {
            ValidarId();
            ValidarDescricao();
            ValidarIdAreaPlantio();
            ValidarDataInicial();
            ValidarIdEmpresa();
        }
    }

    public class RemovePlantacaoCommandValidation : PlantacaoCommandValidation<PlantacaoCommand>
    {
        public RemovePlantacaoCommandValidation()
        {
            ValidarId();
        }
    }
}
