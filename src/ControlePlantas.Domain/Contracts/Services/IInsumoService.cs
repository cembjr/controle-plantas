using System;
using System.Collections.Generic;
using System.Text;

namespace ControlePlantas.Domain.Contracts
{
    public interface IInsumoService : IService<Insumo>
    {
        IEnumerable<Insumo> ListarPorEmpresa(Guid idEmpresa);
        decimal ObterQuantidadeInsumoEmEstoque(Guid idInsumo);
    }
}
