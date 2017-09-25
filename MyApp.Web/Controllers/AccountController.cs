using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using MyApp.Domain.Core.Notifications;
using MyApp.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Web.Controllers
{
    public class AccountController : BaseController
    {
        public AccountController(INotificationHandler<DomainNotification> notifications) : base(notifications)
        {
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);

            return RedirectToAction("Index");
        }
    }
}
