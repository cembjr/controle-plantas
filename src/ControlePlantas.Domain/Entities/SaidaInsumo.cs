using ControlePlantas.Domain.Core;
using ControlePlantas.Domain.Core.Helper;
using FluentValidation;
using System;

namespace ControlePlantas.Domain
{
    public class SaidaInsumo : Entity<SaidaInsumo>, IGeranciadoPorEmpresa
    {

        public SaidaInsumo(Guid idEntradaInsumo, DateTime dataSaida, decimal quantidade, string descricao, Guid idEmpresa)
        {
            IdEntradaInsumo = idEntradaInsumo;
            DataSaida = dataSaida;
            Quantidade = quantidade;
            Descricao = descricao;
            IdEmpresa = idEmpresa;
            ValidateAndThrow();
        }

        public Guid IdEntradaInsumo { get; private set; }
        public DateTime DataSaida { get; private set; }
        public decimal Quantidade { get; private set; }
        public string Descricao { get; private set; }
        public Guid IdEmpresa { get; private set; }

        public virtual Empresa Empresa { get; set; }
        public virtual EntradaInsumo EntradaInsumo { get; set; }

        protected override SaidaInsumo Validar()
        {
            RuleFor(x => IdEntradaInsumo)
                .NotEqual(Guid.Empty)
                .WithMessage(MensagemPadrao.DeveSerDefinido("Entrada Insumo"));

            RuleFor(x => DataSaida)
                .NotEqual(new DateTime(2019, 01, 01))
                .WithMessage(MensagemPadrao.DeveSerMaiorQue("Data Entrada", "01/01/2019"));

            RuleFor(x => x.Quantidade)
                .GreaterThan(0)
                .WithMessage(MensagemPadrao.DeveSerMaiorQueZero("Quantidade"));

            RuleFor(x => x.IdEmpresa).NotEqual(Guid.Empty).WithMessage(MensagemPadrao.DeveSerInformado("IdEmpresa"));

            return this;
        }
    }
}
