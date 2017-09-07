using System;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Interfaces;
using MediatR;
using MyApp.Domain.Core.Notifications;
using MyApp.Application.ViewModels;

namespace MyApp.Web.Controllers
{
    public class ClientController : BaseController
    {
        private readonly IClientAppService clientAppService;

        public ClientController(IClientAppService clientAppService,
                                  INotificationHandler<DomainNotification> notifications) : base(notifications)
        {
            this.clientAppService = clientAppService;
        }

        public IActionResult Index()
        {
            var customers = clientAppService.GetAll();
            return View(customers);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(ClientViewModel clientViewModel)
        {
            if (!ModelState.IsValid) return View(clientViewModel);
            clientAppService.Register(clientViewModel);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var customer = clientAppService.GetById(id);
            return View(customer);
        }

        [HttpPost]
        public IActionResult Edit(ClientViewModel clientViewModel)
        {
            if (!ModelState.IsValid) return View(clientViewModel);
            clientAppService.Update(clientViewModel);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete([FromQuery]Guid id)
        {
            clientAppService.Remove(id);
            return RedirectToAction("Index");
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
