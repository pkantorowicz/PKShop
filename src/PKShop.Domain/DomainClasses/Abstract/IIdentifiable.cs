using System;
namespace PKShop.Domain.DomainClasses.Abstract
{
    public interface IIdentifiable
    {
        Guid Id { get; }
    }
}
