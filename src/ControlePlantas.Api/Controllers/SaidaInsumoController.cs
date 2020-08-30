using AutoMapper;
using ControlePlantas.Domain.Commands;
using ControlePlantas.Domain.Contracts;
using ControlePlantas.Domain.Core.Helper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControlePlantas.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class SaidaInsumoController : BaseController
    {
        private readonly ISaidaInsumoRepository _repository;

        public SaidaInsumoController(IMediator mediator, IMapper map, ISaidaInsumoRepository repository) : base(mediator, map)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<SaidaInsumoDTO>> Listar() => _map.Map<IEnumerable<SaidaInsumoDTO>>(await _repository.ListarPorEmpresa(IdEmpresa));

        [HttpGet("{id:guid}")]
        public async Task<SaidaInsumoDTO> Obter(Guid id) => _map.Map<SaidaInsumoDTO>(await _repository.ObterPorId(id));

        [HttpDelete("{id:guid}")]
        public Task<IActionResult> Deletar(RemoveSaidaInsumoCommand command) => Response(_mediator.Send(command));

        [HttpPost]
        public Task<IActionResult> Salvar([FromBody] RegisterSaidaInsumoCommand command) => Response(_mediator.Send(command));
    }
}
