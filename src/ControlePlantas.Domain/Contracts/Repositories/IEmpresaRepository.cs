using ControlePlantas.Domain.Core;
using System;

namespace ControlePlantas.Domain.Contracts
{
    public interface IEmpresaRepository : IRepository<Empresa>
    {
        Empresa ObterPorIdUsuario(Guid idUsuario);
    }
}
