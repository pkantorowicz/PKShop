namespace PKShop.Core.Events
{
    public interface IEventStore
    {
        void Save<T>(T evt) where T : Event;
    }
}