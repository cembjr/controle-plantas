using ControlePlantas.Domain;
using System;

namespace ControlePlantas.Api
{
    public class AreaPlantioDTO : IDto
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public decimal TamanhoAlqueires { get; set; }
        public decimal TamanhoHectares { get; set; }

    }
}
