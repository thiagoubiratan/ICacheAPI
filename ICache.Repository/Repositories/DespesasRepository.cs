using ICache.Core.Context;
using ICache.Core.Entities;
using ICache.Core.Interfaces.Repositories;
using ICache.Repository.Repositories.Base;

namespace ICache.Repository.Repositories
{
    public class DespesasRepository : RepositoryBase<Despesas>, IDespesasRepository
    {
        public DespesasRepository(ICacheContext context) : base(context)
        {
        }
    }
}
