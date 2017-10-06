using MyApp.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

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

        public IEnumerable<string> GetErrorMessages()
        {
            return this.notifications.GetNotifications().Where(notification => notification.MessageType == "DomainNotification").Select(notification => notification.Value);
        }
    }
}
