using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlePlantas.Api
{
    public class EntradaInsumoDTO :IDto
    {
        public Guid Id { get; set; }
        public Guid IdInsumo { get; set; }
        public Guid IdFornecedor { get; set; }
        public DateTime DataEntrada { get; set; }
        public decimal Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        public string Documento { get; set; }

        public string NomeInsumo { get; set; }

        public decimal ValorTotal { get { return Quantidade * ValorUnitario; } }
    }
}
