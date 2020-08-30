using ControlePlantas.Domain.Core;
using System;

namespace ControlePlantas.Domain.Contracts
{
    public interface IInsumoRepository : IRepository<Insumo>
    {
        bool CanBeDeleted(Guid id);
        decimal ObterQuantidadeInsumoEmEstoque(Guid idInsumo);

    }
}
