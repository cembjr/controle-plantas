using ControlePlantas.Domain;
using ControlePlantas.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePlantas.Data
{
    public class InsumoRepository : Repository<Insumo>, IInsumoRepository
    {
        public InsumoRepository(ControlePlantasContext context) : base(context)
        {
        }

        public bool CanBeDeleted(Guid id) => DbSet.Any(x => x.EntradasInsumo.Count == 0);

        public decimal ObterQuantidadeInsumoEmEstoque(Guid idInsumo)
        {
            var ret = Db.Set<EntradaInsumo>()
                           .Where(x => x.IdInsumo == idInsumo)
                           .Sum(s => s.Quantidade);

            ret -= Db.Set<UtilizacaoInsumoItem>()
                             .Where(x => x.EntradaInsumo.IdInsumo == idInsumo)
                             .Sum(s => s.Quantidade);

            ret -= Db.Set<SaidaInsumo>()
                             .Where(x => x.EntradaInsumo.IdInsumo == idInsumo)
                             .Sum(s => s.Quantidade);

            return ret;
        }

        public Task<IEnumerable<Insumo>> ListarPorEmpresa(Guid idEmpresa) => Localizar(x => x.IdEmpresa == idEmpresa);
    }
}
