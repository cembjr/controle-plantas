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
    [Route("api/entradaInsumo")]
    public class EntradaInsumoController : BaseController
    {
        private readonly IEntradaInsumoRepository _repository;

        public EntradaInsumoController(IMediator mediator, IMapper map, IEntradaInsumoRepository repository) : base(mediator,  map)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<EntradaInsumoDTO>> Listar() => _map.Map<IEnumerable<EntradaInsumoDTO>>(await _repository.ListarPorEmpresa(IdEmpresa));

        [HttpGet("{id:guid}")]
        public async Task<EntradaInsumoDTO> Obter(Guid id) => _map.Map<EntradaInsumoDTO>(await _repository.ObterPorId(id));

        [HttpDelete("{id:guid}")]
        public Task<IActionResult> Deletar(RemoveEntradaInsumoCommand command) => Response(_mediator.Send(command));

        [HttpPost]
        public Task<IActionResult> Salvar([FromBody] RegisterEntradaInsumoCommand command) => Response(_mediator.Send(command));
    }
}
