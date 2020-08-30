using ControlePlantas.Domain.Core;
using ControlePlantas.Domain.Core.Helper;
using FluentValidation;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace ControlePlantas.Domain
{
    public class Empresa : Entity<Empresa>
    {
        protected Empresa() { }

        public Empresa(string nome, string documento, string telefone, Endereco endereco)
        {
            Nome = nome;
            Documento = documento;
            Telefone = telefone;
            Endereco = endereco;
            ValidateAndThrow();
        }

        public string Nome { get; private set; }
        public string Documento { get; private set; }
        public string Telefone { get; private set; }
        public virtual Endereco Endereco { get; private set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
        public virtual ICollection<AreaPlantio> AreasPlantio { get; set; }
        public virtual ICollection<EntradaInsumo> EntradaInsumos { get; set; }
        public virtual ICollection<SaidaInsumo> SaidaInsumos { get; set; }
        public virtual ICollection<Fornecedor> Fornecedores { get; set; }
        public virtual ICollection<Insumo> Insumos { get; set; }
        public virtual ICollection<Plantacao> Plantacoes { get; set; }
        public virtual ICollection<ServicoRealizadoPlantacao> ServicoRealizadoPlantacoes { get; set; }
        public virtual ICollection<UtilizacaoInsumo> UtilizacaoInsumos { get; set; }



        protected override Empresa Validar()
        {
            RuleFor(x => x.Nome).NotEmpty().WithMessage(MensagemPadrao.DeveSerInformado("Nome"));
            RuleFor(x => x.Documento).NotEmpty().WithMessage(MensagemPadrao.DeveSerInformado("Documento"));
            RuleFor(x => x.Telefone).NotEmpty().WithMessage(MensagemPadrao.DeveSerInformado("Telefone"));
            RuleFor(x => x.Endereco.Logradouro).NotEmpty().WithMessage(MensagemPadrao.DeveSerInformado("Logradouro"));
            RuleFor(x => x.Endereco.CEP).Length(8).WithMessage(MensagemPadrao.DeveConterXCaracteres("CEP", 8));
            return this;
        }
    }
}
