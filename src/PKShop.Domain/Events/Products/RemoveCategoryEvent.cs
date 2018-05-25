using System;
using PKShop.Core.Events;

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