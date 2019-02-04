using System;

namespace PKShop.Domain.DomainClasses.Abstract
{
    public interface ITimestampable
    {
        DateTime CreatedAt { get; }
    }
}
