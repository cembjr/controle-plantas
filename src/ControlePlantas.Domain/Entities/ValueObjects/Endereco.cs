using System;
using System.Collections.Generic;
using System.Text;

namespace ControlePlantas.Domain
{
    public class Endereco
    {
        public Endereco(string cEP, string logradouro, string numero, string complemento, string cidade)
        {
            CEP = cEP.Replace(".","").Replace("-","").Replace("/","");
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Cidade = cidade;
        }

        public string CEP { get; private set; }
        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Cidade { get; private set; }

    }
}
