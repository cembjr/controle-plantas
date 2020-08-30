using ControlePlantas.Domain.Contracts;
using ControlePlantas.Domain.Core.Helper;
using ControlePlantas.Domain.Core.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ControlePlantas.Domain.Commands
{
    public class SaidaInsumoCommandHandler : CommandHandler,
        IRequestHandler<RegisterSaidaInsumoCommand, ResponseResult>,
        IRequestHandler<RemoveSaidaInsumoCommand, ResponseResult>
    {
        private readonly ISaidaInsumoRepository _repository;

        public SaidaInsumoCommandHandler(ISaidaInsumoRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResponseResult> Handle(RegisterSaidaInsumoCommand request, CancellationToken cancellationToken)
        {
            var saida = new SaidaInsumo(request.IdEntradaInsumo, request.DataSaida, request.Quantidade, request.Descricao, request.IdEmpresa);

            _repository.Adicionar(saida);

            var sucess = await Commit(_repository) > 0;

            return new ResponseResult(sucess);
        }

        public async Task<ResponseResult> Handle(RemoveSaidaInsumoCommand request, CancellationToken cancellationToken)
        {
            _repository.Deletar(request.Id);

            var sucess = await Commit(_repository) > 0;

            return new ResponseResult(sucess);
        }
    }
}
