using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlePlantas.Api
{
    public class SaidaInsumoDTO
    {
        public Guid Id { get; set; }
        public Guid IdEntradaInsumo { get; private set; }
        public DateTime DataSaida { get; private set; }
        public decimal Quantidade { get; private set; }
        public string Descricao { get; private set; }
        public string NomeInsumo { get; set; }

    }
}
