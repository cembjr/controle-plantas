using System;
using System.Collections.Generic;
using System.Text;

namespace ControlePlantas.Domain.Commands
{
    public abstract class EntradaInsumoCommand : Command
    {
        public Guid Id { get; set; }
        public Guid IdInsumo { get; set; }
        public Guid IdFornecedor { get; set; }
        public DateTime DataEntrada { get; set; }
        public decimal Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        public string Documento { get; set; }

        public Guid IdEmpresa { get; set; }
    }
}
