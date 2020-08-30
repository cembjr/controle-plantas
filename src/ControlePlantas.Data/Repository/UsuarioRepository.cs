using ControlePlantas.Domain;
using ControlePlantas.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControlePlantas.Data
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(ControlePlantasContext context) : base(context)
        {
        }

        public IEnumerable<Usuario> ListarPorEmpresa(Guid idEmpresa) => DbSet.Where(x => x.IdEmpresa == idEmpresa);
    }
}
