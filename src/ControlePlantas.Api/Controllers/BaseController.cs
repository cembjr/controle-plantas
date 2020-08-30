using AutoMapper;
using ControlePlantas.Domain.Core.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlePlantas.Api.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IMediator _mediator;
        protected readonly IMapper _map;

        protected BaseController(IMediator mediator, IMapper map)
        {
            _mediator = mediator;
            _map = map;
        }


        protected new async Task<IActionResult> Response(Task<ResponseResult> command)
        {
            var result = await command;

            return Response(result);
        }

        private new IActionResult Response(ResponseResult response)
        {
            if (!response.Success)
                return BadRequest(response.Errors);

            return Ok(response);
        }

        protected new IActionResult Response(bool success, object data = null, string mensagem = "", IDictionary<string, object> errors = null)
        {
            var response = new ResponseResult(success, data, mensagem, errors);
            return Response(response);
        }

        protected new IActionResult Response(bool success, string error)
        {
            var response = new ResponseResult(success, error: error);
            return Response(response);
        }

        protected Guid IdEmpresa { get { return Guid.Parse(HttpContext.User.Claims.FirstOrDefault(w => w.Type == "Empresa")?.Value); } }

    }


}