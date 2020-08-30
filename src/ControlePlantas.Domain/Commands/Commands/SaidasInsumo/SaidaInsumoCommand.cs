using System;
using System.Collections.Generic;
using System.Text;

namespace ControlePlantas.Domain.Commands
{
    public abstract class SaidaInsumoCommand : Command
    {
        public Guid Id { get; set; }
        public Guid IdEntradaInsumo { get; set; }
        public DateTime DataSaida { get; set; }
        public decimal Quantidade { get; set; }
        public string Descricao { get; set; }

        public Guid IdEmpresa { get; set; }
    }
}
