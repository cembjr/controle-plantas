using ControlePlantas.Domain.Core;
using ControlePlantas.Domain.Core.Helper;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace ControlePlantas.Domain
{
    public class EntradaInsumo : Entity<EntradaInsumo>, IGeranciadoPorEmpresa
    {
        protected EntradaInsumo() { }
        public EntradaInsumo(Guid idInsumo, DateTime dataEntrada, decimal quantidade, decimal valor, Guid idFornecedor, string documento, Guid idEmpresa)
        {
            IdInsumo = idInsumo;
            DataEntrada = dataEntrada;
            Quantidade = quantidade;
            ValorUnitario = valor;
            IdFornecedor = idFornecedor;
            Documento = documento;
            IdEmpresa = idEmpresa;
            ValidateAndThrow();
        }

        public Guid IdInsumo { get; private set; }
        public DateTime DataEntrada { get; private set; }
        public decimal Quantidade { get; private set; }
        public decimal ValorUnitario { get; private set; }
        public Guid IdFornecedor { get; private set; }
        public string Documento { get; private set; }
        public Guid IdEmpresa { get; private set; }

        public virtual Empresa Empresa { get; set; }

        public virtual ICollection<UtilizacaoInsumoItem> UtilizacaoInsumoItens { get; set; }
        
        public virtual ICollection<SaidaInsumo> SaidasInsumo { get; set; }
        public virtual Insumo Insumo { get; set; }

        public virtual Fornecedor Fornecedor { get; set; }
        protected override EntradaInsumo Validar()
        {
            RuleFor(x => IdInsumo).NotEqual(Guid.Empty).WithMessage(MensagemPadrao.DeveSerDefinido("Insumo"));

            RuleFor(x => x.DataEntrada).GreaterThanOrEqualTo(new DateTime(2019,01,01)).WithMessage(MensagemPadrao.DeveSerMaiorQue("Data Entrada", "01/01/2019"));

            RuleFor(x => x.Quantidade).GreaterThan(0).WithMessage(MensagemPadrao.DeveSerMaiorQueZero("Quantidade"));

            RuleFor(x => x.ValorUnitario).GreaterThan(0).WithMessage(MensagemPadrao.DeveSerMaiorQueZero("Valor"));

            RuleFor(x => x.IdFornecedor).NotEqual(Guid.Empty).WithMessage(MensagemPadrao.DeveSerDefinido("Fornecedor"));

            RuleFor(x => x.IdEmpresa).NotEqual(Guid.Empty).WithMessage(MensagemPadrao.DeveSerInformado("IdEmpresa"));

            return this;
        }
    }
}
