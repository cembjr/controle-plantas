using AutoMapper;
using ControlePlantas.Domain.Commands;
using ControlePlantas.Domain.Contracts;
using ControlePlantas.Domain.Core.Helper;
using ControlePlantas.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControlePlantas.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class InsumoController : BaseController
    {
        private readonly IInsumoRepository _repository;

        public InsumoController(IMediator mediator, IMapper map, IInsumoRepository repository) : base(mediator, map)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<InsumoDTO>> Listar() => _map.Map<IEnumerable<InsumoDTO>>(await _repository.ListarPorEmpresa(IdEmpresa));

        [HttpGet]
        [Route("listarTiposInsumo")]
        public IEnumerable<KeyValuePair<int, string>> ListarTiposInsumo() => EnumHelper.ToKeyValuePair<EnumTipoInsumo>();

        [HttpGet("{id:guid}")]
        public async Task<InsumoDTO> Obter(Guid id) => _map.Map<InsumoDTO>(await _repository.ObterPorId(id));


        [HttpPost]
        public Task<IActionResult> Salvar([FromBody] RegisterInsumoCommand command) => Response(_mediator.Send(command));


        [HttpDelete("{id:guid}")]
        public Task<IActionResult> Deletar(RemoveInsumoCommand command) => Response(_mediator.Send(command));


    }
}