using System;
using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using MediatR;
using Domain.Core.Notifications;
using Application.ViewModels;

namespace MyApp.Web.Controllers
{
    public class ProductController : BaseController
    {
        public ProductController(INotificationHandler<DomainNotification> notifications) : base(notifications)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
