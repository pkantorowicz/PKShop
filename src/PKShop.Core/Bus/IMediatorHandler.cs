using System.Threading.Tasks;
using PKShop.Core.Commands;
using PKShop.Core.Events;

namespace PKShop.Core.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}