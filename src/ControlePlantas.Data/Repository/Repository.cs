using ControlePlantas.Domain.Contracts;
using ControlePlantas.Domain.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ControlePlantas.Data
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity<TEntity>
    {
        protected ControlePlantasContext Db;
        protected DbSet<TEntity> DbSet;

        protected Repository(ControlePlantasContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public void Adicionar(TEntity obj) => DbSet.Add(obj);
        public void Atualizar(TEntity obj) => DbSet.Update(obj);
        public void Deletar(Guid id) => DbSet.Remove(DbSet.Find(id));
        public async Task<IEnumerable<TEntity>> Localizar(Expression<Func<TEntity, bool>> predicate) => await DbSet.Where(predicate).ToListAsync();
        public Task<TEntity> LocalizarUm(Expression<Func<TEntity, bool>> predicate) => DbSet.Where(predicate).FirstOrDefaultAsync();
        public Task<TEntity> ObterPorId(Guid id) => DbSet.FirstOrDefaultAsync(t => t.Id == id);
        public async Task<IEnumerable<TEntity>> ObterTodos() => await DbSet.ToListAsync();
        public void Dispose() => Db.Dispose();

        public Task<int> SaveChanges() => Db.SaveChangesAsync();
    }
}
