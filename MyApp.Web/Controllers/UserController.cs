using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using MyApp.Domain.Core.Notifications;
using MyApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace MyApp.Web.Controllers
{
    [Authorize(Roles = "Admin")]
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
            var viewModel = userAppService.GetRegisterNewUserData();
            return View(viewModel);
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
            var customer = userAppService.GetUpdateUserData(id);
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
