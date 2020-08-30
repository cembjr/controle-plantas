using ControlePlantas.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControlePlantas.Domain.Commands
{
    public abstract class InsumoCommand : Command
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public EnumTipoInsumo TipoInsumo { get; set; }
        public Guid IdEmpresa { get; set; }
    }
}
