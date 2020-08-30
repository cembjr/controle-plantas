using ControlePlantas.Domain.Contracts;
using System;
using System.Collections.Generic;

namespace ControlePlantas.Domain
{
    public class UsuarioService : Service<Usuario>, IUsuarioService
    {

        private readonly IUsuarioRepository _repository;
        public UsuarioService(IUsuarioRepository repository) : base(repository)
        {
            _repository = repository;
        }


    }
}
