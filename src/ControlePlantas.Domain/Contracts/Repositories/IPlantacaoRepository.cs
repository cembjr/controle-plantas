using ControlePlantas.Domain.Core;
using System;

namespace ControlePlantas.Domain.Contracts
{
    public interface IPlantacaoRepository : IRepository<Plantacao>
    {
        bool CanBeDeleted(Guid id);
    }
}
