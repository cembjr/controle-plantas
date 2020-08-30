using ControlePlantas.Domain.Core;
using ControlePlantas.Domain.Core.Helper;
using ControlePlantas.Domain.Enums;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControlePlantas.Domain
{
    public class Insumo : Entity<Insumo>, IGeranciadoPorEmpresa
    {
        protected Insumo() { }
        public Insumo(string nome, EnumTipoInsumo tipoInsumo, Guid idEmpresa)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            TipoInsumo = tipoInsumo;
            IdEmpresa = idEmpresa;
            ValidateAndThrow();
        }

        public string Nome { get; private set; }
        public EnumTipoInsumo TipoInsumo { get; private set; }

        public Guid IdEmpresa { get; private set; }
        public virtual Empresa Empresa { get; set; }
        public virtual ICollection<EntradaInsumo> EntradasInsumo { get; set; }

        public decimal QuantidadeEmEstoque { get { return EntradasInsumo.Sum(s => s.Quantidade - s.SaidasInsumo.Sum(ss => ss.Quantidade) - s.UtilizacaoInsumoItens.Sum(ss => ss.Quantidade)); } }

        protected override Insumo Validar()
        {
            RuleFor(r => r.Nome)
                .NotEmpty()
                .WithMessage(MensagemPadrao.NaoDeveSerVazio("Nome"))
                .MinimumLength(3).WithMessage(MensagemPadrao.DeveSerMaiorQue("Nome", "3"));

            RuleFor(r => r.TipoInsumo)
                .NotEqual(EnumTipoInsumo.Indefinido)
                .WithMessage(MensagemPadrao.DeveSerDefinido("Tipo Insumo"));

            RuleFor(x => x.IdEmpresa).NotEqual(Guid.Empty).WithMessage(MensagemPadrao.DeveSerInformado("IdEmpresa"));

            return this;
        }
    }
}
