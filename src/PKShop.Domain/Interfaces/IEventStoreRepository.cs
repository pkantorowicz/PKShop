using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PKShop.Core.Events;

namespace PKShop.Domain.Interfaces
{
    public interface IEventStoreRepository : IDisposable
    {
        void Store(StoredEvent theEvent);
        Task StoreAsync(StoredEvent theEvent);
        IList<StoredEvent> All(Guid aggregateId);
        Task<IList<StoredEvent>> AllAsync(Guid aggregateId);
    }
}