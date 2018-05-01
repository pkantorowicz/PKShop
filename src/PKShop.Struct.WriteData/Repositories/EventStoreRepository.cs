using System;
using System.Linq;
using System.Collections.Generic;
using PKShop.Struct.WriteData.Context;
using PKShop.Core.Events;
using PKShop.Domain.Interfaces;

namespace PKShop.Struct.WriteData.Repositories
{
    public class EventStoreSQLRepository : IEventStoreRepository
    {
        private readonly EventStoreContext _context;

        public EventStoreSQLRepository(EventStoreContext context)
        {
            _context = context;
        }

        public IList<StoredEvent> All(Guid aggregateId)
        {
            return (from x in _context.StoredEvent where x.AggregateId == aggregateId select x).ToList();
        }

        public void Store(StoredEvent theEvent)
        {
            _context.StoredEvent.Add(theEvent);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}