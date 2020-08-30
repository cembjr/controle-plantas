using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlePlantas.Api
{
    public class FornecedorDTO : IDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Documento { get; set; }

        public EnderecoDTO Endereco { get; set; }
    }
}
