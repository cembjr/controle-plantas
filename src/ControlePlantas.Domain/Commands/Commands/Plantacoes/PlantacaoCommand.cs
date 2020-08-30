using System;
using System.Collections.Generic;
using System.Text;

namespace ControlePlantas.Domain.Commands
{
    public abstract class PlantacaoCommand : Command
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public Guid IdAreaPlantio { get; set; }
        public DateTime DataInicial { get; set; }
        public Guid IdEmpresa { get; set; }
    }
}
