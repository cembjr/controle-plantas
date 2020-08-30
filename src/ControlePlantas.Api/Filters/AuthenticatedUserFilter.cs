using ControlePlantas.Domain.Core.Helper;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlePlantas.Api.Filters
{
    public class AuthenticatedUserFilter : IActionFilter, IOrderedFilter
    {
        public int Order => -10;
        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            AuthenticatedUser.IdEmpresa = context.HttpContext.User.Claims.Count() > 0 ? Guid.Parse(context.HttpContext.User.Claims.FirstOrDefault(w => w.Type == "Empresa")?.Value) : Guid.Empty;
        }
    }
}
