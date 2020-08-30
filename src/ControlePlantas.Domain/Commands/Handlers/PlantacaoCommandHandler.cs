using ControlePlantas.Domain.Contracts;
using ControlePlantas.Domain.Core.Helper;
using ControlePlantas.Domain.Core.Model;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ControlePlantas.Domain.Commands
{
    public class PlantacaoCommandHandler : CommandHandler,
        IRequestHandler<RegisterPlantacaoCommand, ResponseResult>,
        IRequestHandler<UpdatePlantacaoCommand, ResponseResult>,
        IRequestHandler<RemovePlantacaoCommand, ResponseResult>
    {
        private readonly IPlantacaoRepository _repository;
        public PlantacaoCommandHandler(IPlantacaoRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResponseResult> Handle(RegisterPlantacaoCommand request, CancellationToken cancellationToken)
        {
            var plantacao = new Plantacao(new Periodo(request.DataInicial, request.DataInicial), request.IdAreaPlantio, request.Descricao, request.IdEmpresa);

            _repository.Adicionar(plantacao);

            var sucess = await Commit(_repository) > 0;

            return new ResponseResult(sucess);
        }

        public async Task<ResponseResult> Handle(UpdatePlantacaoCommand request, CancellationToken cancellationToken)
        {
            var plantacao = new Plantacao(new Periodo(request.DataInicial, request.DataInicial), request.IdAreaPlantio, request.Descricao, request.IdEmpresa);

            _repository.Atualizar(plantacao);

            var sucess = await Commit(_repository) > 0;

            return new ResponseResult(sucess);
        }

        public async Task<ResponseResult> Handle(RemovePlantacaoCommand request, CancellationToken cancellationToken)
        {
            _repository.Deletar(request.Id);

            var sucess = await Commit(_repository) > 0;

            return new ResponseResult(sucess);
        }
    }
}
