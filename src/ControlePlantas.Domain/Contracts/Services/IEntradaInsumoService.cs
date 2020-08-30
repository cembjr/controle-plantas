using System;
using System.Collections.Generic;
using System.Text;

namespace ControlePlantas.Domain.Contracts
{
    public interface IEntradaInsumoService : IService<EntradaInsumo>
    {
        IEnumerable<EntradaInsumo> ListarPorEmpresa(Guid idEmpresa);
    }

}
