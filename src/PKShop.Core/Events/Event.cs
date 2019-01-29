using MediatR;
using System;

namespace PKShop.Core.Events
{
    public abstract class Event : Message, INotification
    {
        public DateTime Timestamp { get; set; }

        protected Event()
        {
            Timestamp = DateTime.UtcNow;
        }
    }
}