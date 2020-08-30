using ControlePlantas.Domain.Core;
using ControlePlantas.Domain.Core.Helper;
using ControlePlantas.Domain.Enums;
using FluentValidation;
using System;

namespace ControlePlantas.Domain
{
    public class Usuario : Entity<Usuario>, IGeranciadoPorEmpresa
    {
        public Usuario(string nome, string login, string senha, Guid idEmpresa)
        {
            Nome = nome;
            Login = login;
            Senha = senha;
            IdEmpresa = idEmpresa;
            ValidateAndThrow();
        }

        public string Nome { get; private set; }
        public string Login { get; private set; }
        public string Senha { get; private set; }
        public Guid IdEmpresa { get; private set; }
        public TipoUsuario TipoUsuario { get; set; }

        public virtual Empresa Empresa { get; set; }

        protected override Usuario Validar()
        {
            RuleFor(x => x.Nome).NotEmpty().WithMessage(MensagemPadrao.DeveSerDefinido("Nome"));
            RuleFor(x => x.Login).NotEmpty().WithMessage(MensagemPadrao.DeveSerDefinido("Login"));
            RuleFor(x => x.Senha).NotEmpty().WithMessage(MensagemPadrao.DeveSerDefinido("Senha"));
            RuleFor(x => x.IdEmpresa).NotEqual(Guid.Empty).WithMessage(MensagemPadrao.DeveSerInformado("IdEmpresa"));

            return this;
        }
    }
}
