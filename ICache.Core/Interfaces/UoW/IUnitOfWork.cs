using System;
using System.Threading.Tasks;

namespace ICache.Core.Interfaces.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> Commit();
        Task Rollback();
    }
}
