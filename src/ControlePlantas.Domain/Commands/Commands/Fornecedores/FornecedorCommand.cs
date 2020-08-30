using System;
using System.Collections.Generic;
using System.Text;

namespace ControlePlantas.Domain.Commands
{
    public abstract class FornecedorCommand : Command
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Documento { get; set; }
        public EnderecoCommand Endereco { get; set; }

        public Guid IdEmpresa { get; set; }
    }
}
