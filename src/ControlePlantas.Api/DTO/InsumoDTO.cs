using ControlePlantas.Domain;
using ControlePlantas.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace ControlePlantas.Api
{
    public class InsumoDTO : IDto
    {
        public Guid Id { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Nome deve ter no mínimo 3 Caracteres")]
        public string Nome { get; set; }
        [Required]
        [Range(1, 50, ErrorMessage = "Tipo deve ser válido")]
        public EnumTipoInsumo TipoInsumo { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Quantidade deve ser válida")]
        public decimal QuantidadeEmEstoque { get; set; }

        public string DescricaoTipoInsumo { get; set; }

    }
}
