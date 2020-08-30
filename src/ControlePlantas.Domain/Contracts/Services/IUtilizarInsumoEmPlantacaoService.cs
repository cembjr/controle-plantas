using System;
using System.Collections.Generic;
using System.Text;

namespace ControlePlantas.Domain.Contracts
{
    public interface IUtilizarInsumoEmPlantacaoService : IService<UtilizacaoInsumo>
    {
        IEnumerable<UtilizacaoInsumo> ListarPorEmpresa(Guid idEmpresa);
    }
}
