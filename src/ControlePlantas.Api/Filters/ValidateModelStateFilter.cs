using ControlePlantas.Domain.Core.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ControlePlantas.Api.Filters
{
    public class ValidateModelStateFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if(!context.ModelState.IsValid)
                context.Result = new BadRequestObjectResult(new ResponseResultError(false, "Um ou mais erros foram encontrados", context.ModelState));
        }
    }
}
