using ControlePlantas.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ControlePlantas.Domain.Contracts
{
    public interface IService<TEntity> : IDisposable where TEntity : Entity<TEntity>
    {
        void Salvar(TEntity obj);
        void Atualizar(TEntity obj);
        void Deletar(Guid id);
        Task<TEntity> ObterPorId(Guid id);
        Task<IEnumerable<TEntity>> ObterTodos();
        Task<IEnumerable<TEntity>> Localizar(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> LocalizarUm(Expression<Func<TEntity, bool>> predicate);
    }
}
