using System.Threading.Tasks;
using PKShop.Core.Commands;
using PKShop.Core.Events;

namespace PKShop.Contracts.Bus
{
    public interface IMediatrHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task SendEvent<T>(T @event) where T : Event;
    }
}