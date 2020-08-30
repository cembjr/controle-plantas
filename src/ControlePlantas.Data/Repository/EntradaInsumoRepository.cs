using ControlePlantas.Domain;
using ControlePlantas.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ControlePlantas.Data
{
    public class EntradaInsumoRepository : Repository<EntradaInsumo>, IEntradaInsumoRepository
    {
        public EntradaInsumoRepository(ControlePlantasContext context) : base(context)
        {
        }

        public Task<IEnumerable<EntradaInsumo>> ListarPorEmpresa(Guid idEmpresa) => Localizar(x => x.IdEmpresa == idEmpresa);
    }
}
