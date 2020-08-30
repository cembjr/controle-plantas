using ControlePlantas.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlePlantas.Api
{
    public class PlantacaoDTO : IDto
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public Guid IdAreaPlantio { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
        public string DescricaoAreaPlantio { get; set; }
    }
}
