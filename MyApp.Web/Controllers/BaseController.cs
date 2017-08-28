using MyApp.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Web.Controllers
{
    public class BaseController : Controller
    {
        private readonly DomainNotificationHandler _notifications;

        public BaseController(INotificationHandler<DomainNotification> notifications)
        {
            _notifications = (DomainNotificationHandler)notifications;
        }

        public bool IsValidOperation()
        {
            return (!_notifications.HasNotifications());
        }
    }
}
