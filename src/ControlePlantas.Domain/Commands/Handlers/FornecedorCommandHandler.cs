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
    public class FornecedorCommandHandler : CommandHandler,
        IRequestHandler<RegisterFornecedorCommand, ResponseResult>,
        IRequestHandler<RemoveFornecedorCommand, ResponseResult>
    {
        private readonly IFornecedorRepository _repository;

        public FornecedorCommandHandler(IFornecedorRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResponseResult> Handle(RemoveFornecedorCommand request, CancellationToken cancellationToken)
        {
            _repository.Deletar(request.Id);

            var success = await Commit(_repository) > 0;

            return new ResponseResult(success);
        }

        public async Task<ResponseResult> Handle(RegisterFornecedorCommand request, CancellationToken cancellationToken)
        {
            var fornecedor = new Fornecedor(request.Nome, request.Documento,
                                            new Endereco(request.Endereco.CEP,
                                                         request.Endereco.Logradouro,
                                                         request.Endereco.Numero,
                                                         request.Endereco.Complemento,
                                                         request.Endereco.Cidade),
                                                         request.IdEmpresa);

            _repository.Adicionar(fornecedor);

            var success = await Commit(_repository) > 0;

            return new ResponseResult(success);
        }
    }
}
