using System;
using PKShop.Contracts.Events;

namespace PKShop.Contracts.Commands
{
    public abstract class Command : Message
    {
        public DateTime Timestamp { get; private set; }
        
        public Command()
        {
            Timestamp = DateTime.UtcNow;
        }
    }
}