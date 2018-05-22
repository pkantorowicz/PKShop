using MediatR;
using Microsoft.AspNetCore.Mvc;
using PKShop.Core.Notifications;

namespace PKShop.Web.Controllers
{
    public class BaseController : Controller
    {
        private readonly DomainNotificationHandler _notification;

        public BaseController(INotificationHandler<DomainNotification> notification)
        {
            _notification = (DomainNotificationHandler)notification;
        }

        public bool IsValidOperation()
        {
            return (!_notification.HasNotifications());
        }
    }
}