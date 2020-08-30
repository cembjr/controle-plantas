using ControlePlantas.Domain.Core;
using ControlePlantas.Domain.Core.Helper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlePlantas.Domain
{
    public class Plantacao : Entity<Plantacao>, IGeranciadoPorEmpresa
    {
        protected Plantacao() { }

        public Plantacao(Periodo periodo, Guid idAreaPlantio, string descricao, Guid idEmpresa)
        {
            Periodo = periodo;
            IdAreaPlantio = idAreaPlantio;
            Descricao = descricao;
            IdEmpresa = idEmpresa;
            ValidateAndThrow();
        }

        public string Descricao { get; private set; }
        public virtual Periodo Periodo { get; private set; }
        public Guid IdAreaPlantio { get; private set; }
        public Guid IdEmpresa { get; private set; }
        
        [NotMapped]
        public string DescricaoAreaPlantio { get { return AreaPlantio.Descricao; } }

        public virtual AreaPlantio AreaPlantio { get; set; }

        public virtual IEnumerable<ServicoRealizadoPlantacao> ServicosRealizados { get; set; }
        public virtual IEnumerable<UtilizacaoInsumo> InsumosUtilizado { get; set; }

        public virtual Empresa Empresa { get; set; }
        protected override Plantacao Validar()
        {
            RuleFor(x => x.Periodo.DataInicial)
                .GreaterThanOrEqualTo(new DateTime(2019, 01, 01))
                .WithMessage(MensagemPadrao.DeveSerMaiorQue("Data de Inicio de Plantio", "01/01/2019"));

            RuleFor(x => x.Periodo.DataFinal)
                .GreaterThan(x => x.Periodo.DataInicial)
                .WithMessage(MensagemPadrao.DeveSerMaiorQue("Data de Final de Plantio", "Data Inicial"));

            RuleFor(x => x.Descricao.Length)
                .GreaterThan(3)
                .WithMessage(MensagemPadrao.DeveConterMaisQueXCaracteres("Descrição", 3));

            RuleFor(x => x.IdEmpresa).NotEqual(Guid.Empty).WithMessage(MensagemPadrao.DeveSerInformado("IdEmpresa"));

            return this;
        }
    }
}

