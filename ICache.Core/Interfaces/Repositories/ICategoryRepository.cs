using System.Collections.Generic;
using System.Threading.Tasks;
using ICache.Core.Entities;
using ICache.Core.Interfaces.Base;

namespace ICache.Core.Interfaces.Repositories
{
    public interface ICategoryRepository : IRepositoryBase<Category>
    {
        Task CreateAsync(Category category);
        Task<IEnumerable<Category>> GetAllAsync();
    }
}
