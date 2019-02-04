using System;

namespace PKShop.Domain.DomainClasses.Abstract
{
    public abstract class EntityBase : IEntity
    {
        public Guid Id { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }
        public DateTime CreatedAt { get; protected set; }

        protected void SetUpdatedDate()
        {
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
