using System;
using PKShop.Core.Events;

namespace PKShop.Domain.Events.Products
{
    public class ProductCreatedEvent : Event
    {
        public Guid Id { get; set; }
        public string Name { get; private set; }
        public bool Active { get; private set; }
        public int Quantity { get; private set; }
        public decimal Cost { get; private set; }

        public ProductCreatedEvent(Guid id, string name, int quantity, decimal cost)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
            Cost = cost;
            AggregateId = id;
        }
    }
}