using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MyApp.Domain.Core.Notifications;
using System.Security.Claims;
using MediatR;

namespace MyApp.WebApi.Controllers.api
{
    public class BaseApiController : Controller
    {
        private readonly DomainNotificationHandler notifications;
        protected Guid UserId
        {
            get
            {
                return Guid.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
            }
        }

        public BaseApiController(INotificationHandler<DomainNotification> notifications)
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
