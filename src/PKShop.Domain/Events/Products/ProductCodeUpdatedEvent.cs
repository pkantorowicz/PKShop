using System;
using PKShop.Core.Events;

namespace PKShop.Domain.Events.Products
{
    public class ProductCodeUpdatedEvent : Event
    {
        public Guid Id { get; set; }
        public string Name { get; private set; }

        public ProductCodeUpdatedEvent(Guid id, string name)
        {
            Id = id;
            Name = name;
            AggregateId = id;
        }
    }
}