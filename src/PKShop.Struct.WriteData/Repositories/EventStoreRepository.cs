using System;
using System.Linq;
using System.Collections.Generic;
using PKShop.Struct.WriteData.Contexts;
using PKShop.Core.Events;
using PKShop.Domain.Interfaces;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PKShop.Struct.WriteData.Repositories
{
    public class EventStoreRepository : IEventStoreRepository
    {
        private readonly EventStoreContext _context;

        public EventStoreRepository(EventStoreContext context)
        {
            _context = context;
        }

        public IList<StoredEvent> All(Guid aggregateId)
            => (from x in _context.StoredEvent where x.AggregateId == aggregateId select x).ToList();
        
        public async Task<IList<StoredEvent>> AllAsync(Guid aggregateId)
           => await (from x in _context.StoredEvent where x.AggregateId == aggregateId select x).ToListAsync();

        public void Store(StoredEvent theEvent)
        {
            _context.StoredEvent.AddAsync(theEvent);
            _context.SaveChanges();
        }

        public async Task StoreAsync(StoredEvent theEvent)
        {
            await _context.StoredEvent.AddAsync(theEvent);
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}