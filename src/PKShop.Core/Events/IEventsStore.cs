namespace PKShop.Core.Events
{
    public interface IEventsStore
    {
        void Save<T>(T evt) where T : Event;
    }
}