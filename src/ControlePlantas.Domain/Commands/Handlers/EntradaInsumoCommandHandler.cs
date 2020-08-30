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
    public class EntradaInsumoCommandHandler : CommandHandler,
        IRequestHandler<RegisterEntradaInsumoCommand, ResponseResult>,
        IRequestHandler<RemoveEntradaInsumoCommand, ResponseResult>
    {
        private readonly IEntradaInsumoRepository _repository;

        public EntradaInsumoCommandHandler(IEntradaInsumoRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResponseResult> Handle(RegisterEntradaInsumoCommand request, CancellationToken cancellationToken)
        {
            var entradaInsumo = new EntradaInsumo(request.IdInsumo, request.DataEntrada, request.Quantidade, request.ValorUnitario, request.IdFornecedor, request.Documento, request.IdEmpresa);

            _repository.Adicionar(entradaInsumo);

            var sucess = await Commit(_repository) > 0;

            return new ResponseResult(sucess);
        }

        public async Task<ResponseResult> Handle(RemoveEntradaInsumoCommand request, CancellationToken cancellationToken)
        {
            _repository.Deletar(request.Id);

            var sucess = await Commit(_repository) > 0;

            return new ResponseResult(sucess);
        }
    }
}
