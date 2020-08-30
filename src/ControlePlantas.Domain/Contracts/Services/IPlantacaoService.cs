using System;
using System.Collections.Generic;
using System.Text;

namespace ControlePlantas.Domain.Contracts
{
    public interface IPlantacaoService : IService<Plantacao>
    {
        IEnumerable<Plantacao> ListarPorEmpresa(Guid idEmpresa);
    }
}
