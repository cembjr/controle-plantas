using System;
using System.Collections.Generic;
using System.Text;

namespace ControlePlantas.Domain.Commands
{
    public abstract class AreaPlantioCommand : Command
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public decimal TamanhoAlqueires { get; set; }
        public decimal TamanhoHectares { get; set; }

        public Guid IdEmpresa { get; set; }
    }
}
