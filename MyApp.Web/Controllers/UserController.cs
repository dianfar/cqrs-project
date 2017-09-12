using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using MyApp.Domain.Core.Notifications;
using MyApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Web.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserAppService userAppService;

        public UserController(IUserAppService userAppService, INotificationHandler<DomainNotification> notifications) : base(notifications)
        {
            this.userAppService = userAppService;
        }

        public IActionResult Index()
        {
            var users = userAppService.GetAll();
            return View(users);
        }
    }
}
