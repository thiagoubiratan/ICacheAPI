using ICache.Core.Context;
using ICache.Core.Interfaces.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICache.Repository.Repositories.Base
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly ICacheContext _context;

        public RepositoryBase()
        {
        }

        public RepositoryBase(ICacheContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TEntity obj)
        {
            await _context.Set<TEntity>().AddAsync(obj);
        }

        public async Task<TEntity> FindByIdAsync(long id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> ListAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public void Remove(TEntity obj)
        {
            _context.Set<TEntity>().Remove(obj);
        }

        public void Update(TEntity obj)
        {
            _context.Set<TEntity>().Update(obj);
        }
    }
}
