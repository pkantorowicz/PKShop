namespace PKShop.Domain.DomainClasses.Abstract
{
    public abstract class AggregateBase<TId> : IAggregate<TId>
    {
        public TId Id { get; protected set; }
    }
}
