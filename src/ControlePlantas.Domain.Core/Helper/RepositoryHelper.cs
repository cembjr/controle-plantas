using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControlePlantas.Domain.Core.Helper
{
    public static class RepositoryHelper
    {
        public static Task<IEnumerable<TEnt>> ListarPorEmpresa<TEnt>(this IRepository<TEnt> repo, Guid idEmpresa)
            where TEnt : Entity<TEnt>, IGeranciadoPorEmpresa
        {
            return repo.Localizar(x => x.IdEmpresa == idEmpresa);
        }
    }
}
