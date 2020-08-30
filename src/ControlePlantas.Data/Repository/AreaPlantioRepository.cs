using ControlePlantas.Domain;
using ControlePlantas.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlePlantas.Data
{
    public class AreaPlantioRepository : Repository<AreaPlantio>, IAreaPlantioRepository
    {
        public AreaPlantioRepository(ControlePlantasContext context) : base(context)
        {

        }
        public bool CanBeDeleted(Guid id)
            => DbSet.Any(x => x.Plantacoes.Count == 0 && x.Id == id);

        public Task<IEnumerable<AreaPlantio>> ListarPorEmpresa(Guid idEmpresa) => Localizar(x => x.IdEmpresa == idEmpresa);
        
    }
}
