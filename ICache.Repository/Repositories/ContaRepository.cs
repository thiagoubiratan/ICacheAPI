using ICache.Core.Context;
using ICache.Core.Entities;
using ICache.Core.Interfaces.Repositories;
using ICache.Repository.Repositories.Base;

namespace ICache.Repository.Repositories
{
    public class ContaRepository : RepositoryBase<Conta>, IContaRepository
    {
        public ContaRepository(ICacheContext context) : base(context)
        {
        }
    }
}
