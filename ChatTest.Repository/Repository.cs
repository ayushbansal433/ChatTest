using ChatTest.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ChatTest.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly SignalDbContext _signalDbContext;
        private DbSet<TEntity> _set;
        private bool _disposed;

        public Repository(SignalDbContext signalDbContext)
        {
            this._signalDbContext = signalDbContext;
        }

        protected DbSet<TEntity> Set
        {
            get { return _set ?? (_set = _signalDbContext.Set<TEntity>()); }
        }

        public IQueryable<TEntity> GetDbSet()
        {
            return Set;
        }

        public List<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            foreach(var includeProperty in includeProperties)
            {
                Set.Include(includeProperty);
            }
            return Set.ToList();
        }

        public async Task<List<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            foreach(var includeProperty in includeProperties)
            {
                Set.Include(includeProperty);
            }
            return await Set.ToListAsync();
        }

        public async Task<List<TEntity>> GetAllAsync(int skip=0, int take=0, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            foreach(var includeProperty in includeProperties)
            {
                Set.Include(includeProperty);
            }
            return await Set.Skip(skip).Take(take).ToListAsync();
        }

        public async Task<TEntity> FindByIdAsync(object id, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            foreach(var includeProperty in includeProperties)
            {
                Set.Include(includeProperty);
            }
            return await Set.FindAsync(id);
        }

        public void Add(TEntity entity)
        {
            Set.Add(entity);
        }

        public async Task AddAsync(TEntity entity)
        {
            await Set.AddAsync(entity);
        }

        public async Task AddManyAsync(List<TEntity> entities)
        {
            await Set.AddRangeAsync(entities);
        }

        public void Update(TEntity entity)
        {
            var entry = _signalDbContext.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                Set.Attach(entity);
                entry = _signalDbContext.Entry(entity);
            }
            entry.State = EntityState.Modified;
        }

        public void Remove(TEntity entity)
        {
            Set.Remove(entity);
        }

        public void Remove(object id)
        {
            var entity = Set.Find(id);
            Set.Remove(entity);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _signalDbContext.Dispose();
            }
            _disposed = true;
        }
    }
}
