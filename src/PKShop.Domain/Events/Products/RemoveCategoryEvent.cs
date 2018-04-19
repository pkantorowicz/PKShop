using System;
using PKShop.Core.Events;
using PKShop.Domain.DomainClasses.Products;

namespace PKShop.Domain.Events.Products
{
    public class RemoveCategoryEvent : Event
    {
        public Guid Id { get; set; }

        public RemoveCategoryEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }
    }
}