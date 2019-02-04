using System;

namespace PKShop.Domain.DomainClasses.Abstract
{
    public interface IEditable
    {
        DateTime UpdatedAt { get; }
    }
}
