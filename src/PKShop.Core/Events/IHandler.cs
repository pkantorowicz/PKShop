using System.Threading.Tasks;

namespace PKShop.Core.Events
{
    public interface IHandler<in T> where T : Message
    {
        Task HandleAsync(T message);
    }
}