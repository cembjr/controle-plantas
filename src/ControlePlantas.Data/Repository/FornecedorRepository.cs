using ControlePlantas.Domain;
using ControlePlantas.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePlantas.Data
{
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(ControlePlantasContext context) : base(context)
        {
        }
        public Task<IEnumerable<Fornecedor>> ListarPorEmpresa(Guid idEmpresa) => Localizar(x => x.IdEmpresa == idEmpresa);
    }
}
