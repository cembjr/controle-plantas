using ControlePlantas.Domain.Core;
using ControlePlantas.Domain.Core.Helper;
using FluentValidation;
using System;

namespace ControlePlantas.Domain
{
    public class UtilizacaoInsumoItem : Entity<UtilizacaoInsumoItem>
    {
        protected UtilizacaoInsumoItem() { }
        public UtilizacaoInsumoItem(Guid idUtilizacao, Guid idEntradaInsumo, decimal quantidade)
        {
            IdUtilizacaoInsumo = idUtilizacao;
            IdEntradaInsumo = idEntradaInsumo;
            Quantidade = quantidade;

            ValidateAndThrow();
        }

        public Guid IdUtilizacaoInsumo { get; private set; }
        public Guid IdEntradaInsumo { get; private set; }
        public decimal Quantidade { get; private set; }

        public virtual UtilizacaoInsumo UtilizacaoInsumo { get; protected set; }
        public virtual EntradaInsumo EntradaInsumo { get; protected set; }

        public virtual Insumo Insumo { get { return EntradaInsumo.Insumo; } }
        protected override UtilizacaoInsumoItem Validar()
        {
            RuleFor(x => IdUtilizacaoInsumo).NotEqual(Guid.Empty).WithMessage(MensagemPadrao.DeveSerDefinido("Utilização"));

            RuleFor(x => IdEntradaInsumo).NotEqual(Guid.Empty).WithMessage(MensagemPadrao.DeveSerDefinido("Entrada Insumo"));

            RuleFor(x => x.Quantidade).GreaterThan(0).WithMessage(MensagemPadrao.DeveSerMaiorQueZero("Quantidade"));

            return this;
        }
    }
}
