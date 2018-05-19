using System;
using PKShop.Core.Events;

namespace PKShop.Domain.Events.Products
{
    public class ProductCodeDeletedEvent : Event
    {
        public Guid Id { get; set; }

        public ProductCodeDeletedEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }
    }
}