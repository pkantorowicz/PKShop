using System;
using PKShop.Core.Commands;

namespace PKShop.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        CommandResponse Commit();
    }
}