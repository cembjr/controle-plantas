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
    [Route("api/[controller]")]
    [Authorize]
    public class PlantacaoController : BaseController
    {
        private readonly IPlantacaoRepository _repository;

        public PlantacaoController(IMediator mediator, IMapper map, IPlantacaoRepository repository) : base(mediator, map)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<PlantacaoDTO>> Listar() => _map.Map<IEnumerable<PlantacaoDTO>>(await _repository.ListarPorEmpresa(IdEmpresa));

        [HttpGet("{id:guid}")]
        public async Task<PlantacaoDTO> Obter(Guid id) => _map.Map<PlantacaoDTO>(await _repository.ObterPorId(id));

        [HttpDelete("{id:guid}")]
        public Task<IActionResult> Deletar(RemovePlantacaoCommand command) => Response(_mediator.Send(command));

        [HttpPost]
        public Task<IActionResult> Salvar([FromBody] RegisterPlantacaoCommand command) => Response(_mediator.Send(command));
    }
}