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
    public class FornecedorController : BaseController
    {
        private readonly IFornecedorRepository _repository;

        public FornecedorController(IMediator mediator, IMapper map, IFornecedorRepository repository) : base(mediator, map)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<FornecedorDTO>> Listar() => _map.Map<IEnumerable<FornecedorDTO>>(await _repository.ListarPorEmpresa(IdEmpresa));

        [HttpGet("{id:guid}")]
        public async Task<FornecedorDTO> Obter(Guid id) => _map.Map<FornecedorDTO>(await _repository.ObterPorId(id));

        [HttpDelete("{id:guid}")]
        public Task<IActionResult> Deletar(RemoveFornecedorCommand command) => Response(_mediator.Send(command));


        [HttpPost]
        public Task<IActionResult> Salvar([FromBody] RegisterFornecedorCommand command) => Response(_mediator.Send(command));
    }
}
