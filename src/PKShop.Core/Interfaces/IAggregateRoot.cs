using System;

namespace PKShop.Core.Interfaces
{
    public interface IAggregateRoot 
    {
        Guid Id { get; }
    }
}
