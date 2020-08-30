using ControlePlantas.Domain.Core;
using System;

namespace ControlePlantas.Domain.Contracts
{
    public interface IAreaPlantioRepository : IRepository<AreaPlantio>
    {
        bool CanBeDeleted(Guid id);
    }
}
