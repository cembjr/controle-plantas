using ControlePlantas.Domain.Contracts;
using System;
using System.Collections.Generic;

namespace ControlePlantas.Domain
{
    public class FornecedorService : Service<Fornecedor>, IFornecedorService
    {
        private readonly IFornecedorRepository _repository;
        public FornecedorService(IFornecedorRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
