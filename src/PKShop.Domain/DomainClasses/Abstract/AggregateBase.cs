using System;
using PKShop.Domain.DomainClasses.Products;

namespace PKShop.Domain.DomainClasses.Abstract
{
    public abstract class AggregateBase<TId> : IAggregate<TId>
    {
        public TId Id { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }
        public DateTime CreatedAt { get; protected set; }

        protected void SetUpdatedDate()
        {
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
