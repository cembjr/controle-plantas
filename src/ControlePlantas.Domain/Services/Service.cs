using ControlePlantas.Domain.Contracts;
using ControlePlantas.Domain.Core;
using ControlePlantas.Domain.Core.Helper;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ControlePlantas.Domain
{
    public abstract class Service<TEntity> : IService<TEntity>
        where TEntity : Entity<TEntity>
    {
        private readonly IRepository<TEntity> _repository;

        protected Service(IRepository<TEntity> repository)
            => _repository = repository;

        public virtual void Salvar(TEntity obj)
        {
            _repository.Add(obj);
        }
        public virtual void Atualizar(TEntity obj)
        {
            _repository.Update(obj);
        }
        public virtual void Deletar(Guid id)
        {
            _repository.Delete(id);
        }


        public void Dispose() => _repository.Dispose();

        public Task<IEnumerable<TEntity>> Localizar(Expression<Func<TEntity, bool>> predicate)
            => _repository.Localizar(predicate);

        public Task<TEntity> ObterPorId(Guid id) => _repository.ObterPorId(id);

        public Task<IEnumerable<TEntity>> ObterTodos() => _repository.ObterTodos();
        
        public Task<TEntity> LocalizarUm(Expression<Func<TEntity, bool>> predicate) => _repository.LocalizarUm(predicate);

    }
}
