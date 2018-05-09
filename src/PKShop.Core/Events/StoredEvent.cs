using System;

namespace PKShop.Core.Events
{
    public class StoredEvent : Event
    {
        public Guid Id { get; private set; }
        public string Data { get; private set; }
        public string User { get; private set; }

        protected StoredEvent()
        {         
        }

        public StoredEvent(Event evt, string data, string user)
        {
            Id = Guid.NewGuid();
            AggregateId = evt.AggregateId;
            MessageType = evt.MessageType;
            Data = data;
            User = user;
        }
    }
}