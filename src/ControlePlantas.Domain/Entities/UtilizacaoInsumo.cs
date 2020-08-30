using ControlePlantas.Domain.Core;
using ControlePlantas.Domain.Core.Helper;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace ControlePlantas.Domain
{
    public class UtilizacaoInsumo : Entity<UtilizacaoInsumo>, IGeranciadoPorEmpresa
    {
        protected UtilizacaoInsumo() { }
        public UtilizacaoInsumo(Guid idPlantacao, DateTime dataUtilizacao, string observacao, Guid idEmpresa)
        {
            IdPlantacao = idPlantacao;
            DataUtilizacao = dataUtilizacao;
            Observacao = observacao;
            ItensUtilizacao = new List<UtilizacaoInsumoItem>();
            IdEmpresa = idEmpresa;
            ValidateAndThrow();
        }

        public Guid IdPlantacao { get; private set; }
        public DateTime DataUtilizacao { get; private set; }
        public string Observacao { get; private set; }
        public Guid IdEmpresa { get; private set; }
        public virtual Empresa Empresa { get; set; }
        public virtual ICollection<UtilizacaoInsumoItem> ItensUtilizacao { get; private set; }
        public virtual Plantacao Plantacao { get; set; }        
        protected override UtilizacaoInsumo Validar()
        {
            RuleFor(x => IdPlantacao).NotEqual(Guid.Empty).WithMessage(MensagemPadrao.DeveSerDefinido("Plantação"));

            RuleFor(x => x.DataUtilizacao).GreaterThan(new DateTime(2019, 01, 01)).WithMessage(MensagemPadrao.DeveSerMaiorQue("Data Utilização", "01/01/2019"));

            RuleFor(x => x.IdEmpresa).NotEqual(Guid.Empty).WithMessage(MensagemPadrao.DeveSerInformado("IdEmpresa"));

            return this;
        }

        public void AdicionarItensUtilizados(Guid idEntradaInsumo, decimal quantidade) => ItensUtilizacao.Add( new UtilizacaoInsumoItem(Id, idEntradaInsumo, quantidade));
    }
}
