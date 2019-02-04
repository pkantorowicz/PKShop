using System;
namespace PKShop.Domain.DomainClasses.Abstract
{
    public interface IEntity : IIdentifiable, IEditable, ITimestampable
    {
    }
}
