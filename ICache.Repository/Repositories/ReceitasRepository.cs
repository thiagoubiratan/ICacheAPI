using ICache.Core.Context;
using ICache.Core.Entities;
using ICache.Core.Interfaces.Repositories;
using ICache.Repository.Repositories.Base;

namespace ICache.Repository.Repositories
{
    public class ReceitasRepository : RepositoryBase<Receitas>, IReceitasRepository
    {
        public ReceitasRepository(ICacheContext context) : base(context)
        {
        }
    }
}
