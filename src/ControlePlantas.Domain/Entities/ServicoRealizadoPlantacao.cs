using ControlePlantas.Domain.Core;
using ControlePlantas.Domain.Core.Helper;
using ControlePlantas.Domain.Enums;
using FluentValidation;
using System;

namespace ControlePlantas.Domain
{
    public class ServicoRealizadoPlantacao : Entity<ServicoRealizadoPlantacao>, IGeranciadoPorEmpresa
    {
        protected ServicoRealizadoPlantacao() { }

        public ServicoRealizadoPlantacao(Guid idPlantacao, EnumTipoServicoRealizado tipoServicoRealizado, DateTime dataServico, decimal valorServico, string observacao, Guid idEmpresa)
        {
            IdPlantacao = idPlantacao;
            TipoServicoRealizado = tipoServicoRealizado;
            DataServico = dataServico;
            ValorServico = valorServico;
            Observacao = observacao;
            IdEmpresa = idEmpresa;
            ValidateAndThrow();
        }

        public Guid IdPlantacao { get; private set; }
        public EnumTipoServicoRealizado TipoServicoRealizado { get; private set; }
        public DateTime DataServico { get; private set; }
        public decimal ValorServico { get; set; }
        public string Observacao { get; set; }
        public Guid IdEmpresa { get; private set; }
        public virtual Empresa Empresa { get; set; }

        public virtual Plantacao Plantacao { get; set; }
        protected override ServicoRealizadoPlantacao Validar()
        {

            RuleFor(x => x.IdPlantacao).NotEqual(Guid.Empty).WithMessage(MensagemPadrao.DeveSerInformado("Plantacao"));
            RuleFor(x => x.TipoServicoRealizado).NotEqual(EnumTipoServicoRealizado.Indefinido).WithMessage(MensagemPadrao.DeveSerDefinido("Tipo Serviço Realizado"));
            RuleFor(x => x.DataServico).GreaterThanOrEqualTo(new DateTime(2019, 01, 01)).WithMessage(MensagemPadrao.DeveSerMaiorQue("Data Entrada", "01/01/2019"));
            RuleFor(x => x.IdEmpresa).NotEqual(Guid.Empty).WithMessage(MensagemPadrao.DeveSerInformado("IdEmpresa"));

            return this;
        }
    }
}
