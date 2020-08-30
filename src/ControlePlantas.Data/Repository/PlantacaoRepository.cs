using ControlePlantas.Domain;
using ControlePlantas.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlePlantas.Data
{
    public class PlantacaoRepository : Repository<Plantacao>, IPlantacaoRepository
    {
        public PlantacaoRepository(ControlePlantasContext context) : base(context)
        {
        }

        public bool CanBeDeleted(Guid id)
        {
            return DbSet.Any(x => x.InsumosUtilizado.Count() == 0 && x.ServicosRealizados.Count() == 0 && x.Id == id);
        }

        public Task<IEnumerable<Plantacao>> ListarPorEmpresa(Guid idEmpresa) => Localizar(x => x.IdEmpresa == idEmpresa);
    }
}
