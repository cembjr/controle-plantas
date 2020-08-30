using ControlePlantas.Domain.Core;
using ControlePlantas.Domain.Core.Helper;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace ControlePlantas.Domain
{
    public class Fornecedor : Entity<Fornecedor>, IGeranciadoPorEmpresa
    {
        protected Fornecedor()
        {

        }
        public Fornecedor(string nome, string documento, Endereco endereco, Guid idEmpresa)
        {
            Nome = nome;
            Documento = documento;
            Endereco = endereco;
            IdEmpresa = idEmpresa;
            ValidateAndThrow();
        }

        public string Nome { get; private set; }
        public string Documento { get; private set; }
        public Guid IdEmpresa { get; private set; }
        public virtual Endereco Endereco { get; set; }

        public virtual Empresa Empresa { get; set; }

        public virtual IEnumerable<EntradaInsumo> EntradasInsumos { get; set; }

        protected override Fornecedor Validar()
        {            
            RuleFor(x => x.Nome).NotEmpty().WithMessage(MensagemPadrao.DeveSerInformado("Nome"));

            RuleFor(x => x.Endereco.Logradouro).NotEmpty().WithMessage(MensagemPadrao.DeveSerInformado("Logradouro"));

            RuleFor(x => x.Endereco.CEP).Length(8).WithMessage(MensagemPadrao.DeveConterXCaracteres("CEP", 8));

            RuleFor(x => x.IdEmpresa).NotEqual(Guid.Empty).WithMessage(MensagemPadrao.DeveSerInformado("IdEmpresa"));

            return this;
        }
    }
}
