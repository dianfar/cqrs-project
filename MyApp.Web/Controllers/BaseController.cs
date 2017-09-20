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
        private readonly DomainNotificationHandler notifications;

        protected Guid UserId;

        public BaseController(INotificationHandler<DomainNotification> notifications)
        {
            this.notifications = (DomainNotificationHandler)notifications;
            UserId = Guid.Parse("4B691A00-D828-4360-9B9D-12655741CF06");
        }

        public bool IsValidOperation()
        {
            return (!notifications.HasNotifications());
        }
    }
}
