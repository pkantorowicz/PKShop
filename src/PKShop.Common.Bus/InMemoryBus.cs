using System.Threading.Tasks;
using PKShop.Core.Bus;
using PKShop.Core.Commands;
using PKShop.Core.Events;
using MediatR;

namespace PKShop.Common.Bus
{
    public sealed class InMemoryBus : IMediatorHandler
    {
        private readonly IMediator _mediator;
        private readonly IEventStore _eventStore;

        public InMemoryBus(IEventStore eventStore, IMediator mediator)
        {
            _eventStore = eventStore;
            _mediator = mediator;
        }

        public async Task SendCommand<T>(T command) where T : Command
            => await _mediator.Send(command);
        

        public async Task RaiseEvent<T>(T @event) where T : Event
        {
            if (!@event.MessageType.Equals("DomainNotification"))
                _eventStore?.Save(@event);

            await _mediator.Publish(@event);
        }
    }
}