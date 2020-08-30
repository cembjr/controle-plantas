using ControlePlantas.Domain.Core;
using ControlePlantas.Domain.Core.Helper;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace ControlePlantas.Domain
{
    public class AreaPlantio : Entity<AreaPlantio>, IGeranciadoPorEmpresa
    {
        protected AreaPlantio() { }
        public AreaPlantio(string descricao, decimal tamanhoAlqueires, decimal tamanhoHectares, Guid idEmpresa)
        {
            Id = Guid.NewGuid();
            Descricao = descricao;
            TamanhoAlqueires = tamanhoAlqueires;
            TamanhoHectares = tamanhoHectares;
            IdEmpresa = idEmpresa;
            ValidateAndThrow();
        }
        public string Descricao { get; private set; }
        public decimal TamanhoAlqueires { get; private set; }

        public decimal TamanhoHectares { get; private set; }

        public virtual ICollection<Plantacao> Plantacoes { get; set; }
        public Guid IdEmpresa { get; private set; }

        public void Atualizar(string descricao, decimal tamanhoAlqueires, decimal tamanhoHectares)
        {
            Descricao = descricao;
            TamanhoAlqueires = tamanhoAlqueires;
            TamanhoHectares = tamanhoHectares;
        }

        public virtual Empresa Empresa { get; set; }

        protected override AreaPlantio Validar()
        {
            RuleFor(x => x.Descricao).NotEmpty().WithMessage(MensagemPadrao.NaoDeveSerVazio("Descrição"));

            RuleFor(x => x.TamanhoAlqueires).GreaterThan(0).WithMessage(MensagemPadrao.DeveSerMaiorQueZero("Tamanho Alqueires"));

            RuleFor(x => x.TamanhoHectares).GreaterThan(0).WithMessage(MensagemPadrao.DeveSerMaiorQueZero("Tamanho Hectares"));

            RuleFor(x => x.IdEmpresa).NotEqual(Guid.Empty).WithMessage(MensagemPadrao.DeveSerInformado("IdEmpresa"));

            return this;
        }
    }
}
