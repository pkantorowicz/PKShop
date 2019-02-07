using System;
namespace PKShop.Core.Types
{
    public interface IIdentifiable
    {
        Guid Id { get; }
    }
}
