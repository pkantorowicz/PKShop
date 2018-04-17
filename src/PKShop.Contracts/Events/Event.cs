using System;

namespace PKShop.Contracts.Events
{
    public abstract class Event : Message
    {
        public DateTime Timestamp { get; set; }

        public Event()
        {
            Timestamp = DateTime.UtcNow;
        }
    }
}