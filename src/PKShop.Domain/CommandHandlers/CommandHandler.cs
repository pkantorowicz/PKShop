using MediatR;
using PKShop.Core.Bus;
using PKShop.Core.Notifications;
using PKShop.Domain.Interfaces;
using System.Threading.Tasks;

namespace PKShop.Domain.CommandHandlers
{
    public class CommandHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly IMediatorHandler _bus;
        private readonly DomainNotificationHandler _notifications;

        public CommandHandler(IUnitOfWork uow, IMediatorHandler bus, INotificationHandler<DomainNotification> notifications)
        {
            _uow = uow;
            _notifications = (DomainNotificationHandler)notifications;
            _bus = bus;
        }

        public async Task<bool> CommitAsync()
        {
            if (_notifications.HasNotifications()) return false;
            if (await _uow.CommitAsync()) return true;

            await _bus.RaiseEvent(new DomainNotification("Commit", "We had a problem during saving your data."));
            return false;
        }
    }
}