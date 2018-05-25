using System;
using PKShop.Core.Events;

namespace PKShop.Domain.Events.Products
{
    public class AddCategoryEvent : Event
    {
        public Guid Id { get; set; }
        public string Name { get; private set; }

        public AddCategoryEvent(Guid id, string name)
        {
            Id = id;
            Name = name;
            AggregateId = id;
        }
    }
}