using System.Collections.Generic;
using System.Threading.Tasks;
using ICache.Core.Entities;

namespace ICache.Core.Interfaces.Base
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> ListAsync();
        Task AddAsync(TEntity obj);
        Task<TEntity> FindByIdAsync(long id);
        void Update(TEntity obj);
        void Remove(TEntity obj);
    }
}
