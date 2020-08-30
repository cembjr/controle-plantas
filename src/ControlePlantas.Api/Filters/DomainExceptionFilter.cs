using ControlePlantas.Domain.Core;
using ControlePlantas.Domain.Core.Helper;
using ControlePlantas.Domain.Core.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;

namespace ControlePlantas.Api.Filters
{
    public class DomainExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order => -10;

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is DomainException exception)
            {
                context.Result = new BadRequestObjectResult(new ResponseResult(false, message: exception.Message, errors: exception.Erros));
                context.ExceptionHandled = true;
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {

        }
    }

    public class ExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order => -9;

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is Exception exception)
            {
                context.Result = new BadRequestObjectResult(new ResponseResult(false, message: "Ocorreu um erro ao executar a operação", error: exception.Message));
                context.ExceptionHandled = true;
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {

        }
    }


}
