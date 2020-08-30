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
    public class InsumoCommandHandler : CommandHandler,
        IRequestHandler<RegisterInsumoCommand, ResponseResult>,
        IRequestHandler<RemoveInsumoCommand, ResponseResult>
    {
        private readonly IInsumoRepository _repository;

        public InsumoCommandHandler(IInsumoRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResponseResult> Handle(RemoveInsumoCommand request, CancellationToken cancellationToken)
        {
            _repository.Deletar(request.Id);
            
            var sucess = await Commit(_repository) > 0;
            
            return new ResponseResult(sucess);
        }

        public async Task<ResponseResult> Handle(RegisterInsumoCommand request, CancellationToken cancellationToken)
        {
            var entity = new Insumo(request.Nome, request.TipoInsumo, request.IdEmpresa);
            
            _repository.Adicionar(entity);
            
            var sucess = await Commit(_repository) > 0;
            
            return new ResponseResult(sucess);
        }
    }
}
