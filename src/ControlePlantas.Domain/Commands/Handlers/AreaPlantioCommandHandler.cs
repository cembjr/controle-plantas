using ControlePlantas.Domain.Contracts;
using ControlePlantas.Domain.Core.Helper;
using ControlePlantas.Domain.Core.Model;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ControlePlantas.Domain.Commands
{
    public class AreaPlantioCommandHandler : CommandHandler,
        IRequestHandler<RegisterAreaPlantioCommand, ResponseResult>,
        IRequestHandler<UpdateAreaPlantioCommand, ResponseResult>,
        IRequestHandler<RemoveAreaPlantioCommand, ResponseResult>
    {
        private readonly IAreaPlantioRepository _repository;

        public AreaPlantioCommandHandler(IAreaPlantioRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResponseResult> Handle(RegisterAreaPlantioCommand request, CancellationToken cancellationToken)
        {
            request.IdEmpresa = AuthenticatedUser.IdEmpresa;

            if (!request.IsValid) return new ResponseResult(false, errors: request.Erros);
                        
            var areaPlantio = new AreaPlantio(request.Descricao, request.TamanhoAlqueires, request.TamanhoHectares, request.IdEmpresa);

            _repository.Adicionar(areaPlantio);

            await Commit(_repository);

            return new ResponseResult(true);
        }

        public async Task<ResponseResult> Handle(UpdateAreaPlantioCommand request, CancellationToken cancellationToken)
        {
            request.IdEmpresa = AuthenticatedUser.IdEmpresa;

            if (!request.IsValid) return new ResponseResult(false, errors: request.Erros);

            var areaPlantio = await _repository.ObterPorId(request.Id);
            if (areaPlantio == null) return new ResponseResult(false, error: "Área de plantio não encontrada");

            areaPlantio.Atualizar(request.Descricao, request.TamanhoAlqueires, request.TamanhoHectares);

            _repository.Atualizar(areaPlantio);

            await Commit(_repository);

            return new ResponseResult(true);
        }

        public async Task<ResponseResult> Handle(RemoveAreaPlantioCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid) return new ResponseResult(false, errors: request.Erros);

            var areaPlantio = await _repository.ObterPorId(request.Id);
            if (areaPlantio == null) return new ResponseResult(false, error: "Área de plantio não encontrada");

            _repository.Deletar(request.Id);

            await Commit(_repository);

            return new ResponseResult(true);
        }
    }
}
