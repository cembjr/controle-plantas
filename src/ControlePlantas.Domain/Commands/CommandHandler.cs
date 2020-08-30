using ControlePlantas.Domain.Core;
using ControlePlantas.Domain.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ControlePlantas.Domain.Commands
{
    public class CommandHandler
    {
        protected Task<int> Commit(IRepository repo) => repo.SaveChanges();
        

    }
}
