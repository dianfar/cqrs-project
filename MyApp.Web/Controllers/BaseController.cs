using MyApp.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Security.Claims;

namespace MyApp.Web.Controllers
{
    public class BaseController : Controller
    {
        private readonly DomainNotificationHandler notifications;
        protected Guid UserId
        {
            get {
                return Guid.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
            }
        }

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
