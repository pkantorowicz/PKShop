using System;

namespace PKShop.Core.Types
{
    public interface ITimestampable
    {
        DateTime CreatedAt { get; }
    }
}
