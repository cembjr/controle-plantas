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
    public class AreaPlantioController : BaseController
    {
        private readonly IAreaPlantioRepository _areaPlantioRepository;

        public AreaPlantioController(IMediator mediator, IMapper map, IAreaPlantioRepository areaPlantioRepository) : base(mediator, map)
        {
            _areaPlantioRepository = areaPlantioRepository;
        }

        // GET: api/AreaPlantio
        [HttpGet]
        public async Task<IEnumerable<AreaPlantioDTO>> Listar() => _map.Map<IEnumerable<AreaPlantioDTO>>(await _areaPlantioRepository.ListarPorEmpresa(IdEmpresa));

        // GET: api/AreaPlantio/5
        [HttpGet("{id:guid}")]
        public async Task<AreaPlantioDTO> Obter(Guid id) => _map.Map<AreaPlantioDTO>(await _areaPlantioRepository.ObterPorId(id));

        [HttpDelete("{id}")]
        public Task<IActionResult> Deletar(RemoveAreaPlantioCommand command) => Response(_mediator.Send(command));


        [HttpPost]
        public Task<IActionResult> Salvar([FromBody] RegisterAreaPlantioCommand command) => Response(_mediator.Send(command));

        [HttpPut("{id:guid}")]
        public Task<IActionResult> Atualizar(Guid id, [FromBody] UpdateAreaPlantioCommand command)
        {
            command.Id = id;
            return Response(_mediator.Send(command));
        }

    }
}

