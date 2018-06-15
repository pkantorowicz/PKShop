using System;
using PKShop.Core.Events;

namespace PKShop.Domain.Events.Products
{
    public class ProductDeletedEvent : Event
    {
        public Guid Id { get; set; }

        public ProductDeletedEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }
    }
}