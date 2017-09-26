using MyApp.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Web.Controllers
{
    public class BaseController : Controller
    {
        private readonly DomainNotificationHandler notifications;

        public BaseController(INotificationHandler<DomainNotification> notifications)
        {
            this.notifications = (DomainNotificationHandler)notifications;
        }

        public bool IsValidOperation()
        {
            return (!notifications.HasNotifications());
        }
    }
}
