namespace PKShop.Domain.DomainClasses.Abstract
{
    public interface IAggregate<out TId>
    {
        TId Id { get; }
    }
}