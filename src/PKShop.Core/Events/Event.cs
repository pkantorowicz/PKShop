using System;

namespace PKShop.Core.Events
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