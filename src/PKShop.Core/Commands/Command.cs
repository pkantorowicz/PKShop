using System;
using PKShop.Core.Events;

namespace PKShop.Core.Commands
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