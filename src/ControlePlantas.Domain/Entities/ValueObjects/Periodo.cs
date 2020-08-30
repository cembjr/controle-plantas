using System;
using System.Collections.Generic;
using System.Text;

namespace ControlePlantas.Domain
{
    public class Periodo
    {
        public Periodo(DateTime dataInicial, DateTime dataFinal)
        {
            DataInicial = dataInicial;
            DataFinal = dataFinal;
        }

        public DateTime DataInicial { get; private set; }
        public DateTime DataFinal { get; private set; }

    }
}
