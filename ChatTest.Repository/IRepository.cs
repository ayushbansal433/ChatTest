using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ChatTest.Repository
{
    public interface IRepository<TEntity>
    {
        IQueryable<TEntity> GetDbSet();
        List<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includeProperties);
        Task<List<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] includeProperties);
        Task<List<TEntity>> GetAllAsync(int skip = 0, int take = 0, params Expression<Func<TEntity, object>>[] includeProperties);
        Task<TEntity> FindByIdAsync(object id, params Expression<Func<TEntity, object>>[] includeProperties);
        void Add(TEntity entity);
        Task AddAsync(TEntity entity);
        Task AddManyAsync(List<TEntity> entities);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        void Remove(object id);
        void Dispose();
        void Dispose(bool disposing);

    }
}
