using System;
using PKShop.Core.Events;

namespace PKShop.Domain.Events.Products
{
    public class ProductCodeCreatedEvent : Event
    {
        public Guid Id { get; set; }
        public string Name { get; private set; }

        public ProductCodeCreatedEvent(Guid id, string name)
        {
            Id = id;
            Name = name;
            AggregateId = id;
        }
    }
}