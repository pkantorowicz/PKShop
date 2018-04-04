using System;

namespace CompanyCars.Core.Interfaces
{
    public interface IAggregateRoot 
    {
        Guid Id { get; }
    }
}
