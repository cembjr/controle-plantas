using ControlePlantas.Domain;
using ControlePlantas.Domain.Contracts;
using System;
using System.Linq;
using System.Text;

namespace ControlePlantas.Data
{
    public class EmpresaRepository : Repository<Empresa>, IEmpresaRepository
    {
        public EmpresaRepository(ControlePlantasContext context) : base(context)
        {
        }

        public Empresa ObterPorIdUsuario(Guid idUsuario) => DbSet.FirstOrDefault(f => f.Usuarios.Any(a => a.Id == idUsuario));
    }
}
