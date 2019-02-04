namespace PKShop.Domain.DomainClasses.Abstract
{
    public interface IAggregate<out TId> : IEditable, ITimestampable
    {
        TId Id { get; }
    }
}