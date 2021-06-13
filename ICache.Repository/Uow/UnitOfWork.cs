using ICache.Core.Context;
using ICache.Core.Interfaces.UoW;
using System.Threading.Tasks;

namespace ICache.Repository.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ICacheContext _context;

        public UnitOfWork(ICacheContext context) => _context = context;

        public void Dispose() => _context.Dispose();

        public async Task<bool> Commit()
        {
            var success = (await _context.SaveChangesAsync()) > 0;
            // Possibility to dispatch domain events, etc
            return success;
        }

        public Task Rollback()
        {
            // Rollback anything, if necessary
            return Task.CompletedTask;
        }

        
    }
}
