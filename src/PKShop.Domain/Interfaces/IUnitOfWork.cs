using System;
using System.Threading.Tasks;

namespace PKShop.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
        Task<bool> CommitAsync();
    }
}