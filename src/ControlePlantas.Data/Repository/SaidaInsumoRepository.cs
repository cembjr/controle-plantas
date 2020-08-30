using ControlePlantas.Domain;
using ControlePlantas.Domain.Contracts;

namespace ControlePlantas.Data
{
    public class SaidaInsumoRepository : Repository<SaidaInsumo>, ISaidaInsumoRepository
    {
        public SaidaInsumoRepository(ControlePlantasContext context) : base(context)
        {
        }
    }
}
