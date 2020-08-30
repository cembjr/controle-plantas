using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ControlePlantas.Domain.Core
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
