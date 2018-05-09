using Newtonsoft.Json;
using PKShop.Core.Events;
using PKShop.Domain.DomainClasses.Identity;
using PKShop.Domain.Interfaces;

namespace PKShop.Struct.WriteData.EventSourcing
{
    public class SqlEventStore : IEventStore
    {
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly User _user;

        public SqlEventStore(IEventStoreRepository eventStoreRepository, User user)
        {
            _eventStoreRepository = eventStoreRepository;
            _user = user;
        }

        public void Save<T>(T theEvent) where T : Event
        {
            var serializedData = JsonConvert.SerializeObject(theEvent);

            var storedEvent = new StoredEvent(
                theEvent,
                serializedData,
                _user.Username);

            _eventStoreRepository.Store(storedEvent);
        }
    }
}