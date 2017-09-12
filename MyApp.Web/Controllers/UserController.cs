using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using MyApp.Domain.Core.Notifications;
using MyApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.ViewModels;

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

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(UserViewModel userViewModel)
        {
            if (!ModelState.IsValid) return View(userViewModel);
            userAppService.Create(userViewModel);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var customer = userAppService.GetById(id);
            return View(customer);
        }

        [HttpPost]
        public IActionResult Edit(UserViewModel userViewModel)
        {
            if (!ModelState.IsValid) return View(userViewModel);
            userAppService.Update(userViewModel);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete([FromQuery]Guid id)
        {
            userAppService.Remove(id);
            return RedirectToAction("Index");
        }
    }
}
