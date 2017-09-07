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
        private readonly IClientAppService customerAppService;

        public ClientController(IClientAppService customerAppService,
                                  INotificationHandler<DomainNotification> notifications) : base(notifications)
        {
            this.customerAppService = customerAppService;
        }

        public IActionResult Index()
        {
            var customers = customerAppService.GetAll();
            return View(customers);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(ClientViewModel customerViewModel)
        {
            if (!ModelState.IsValid) return View(customerViewModel);
            customerAppService.Register(customerViewModel);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var customer = customerAppService.GetById(id);
            return View(customer);
        }

        [HttpPost]
        public IActionResult Edit(ClientViewModel customerViewModel)
        {
            if (!ModelState.IsValid) return View(customerViewModel);
            customerAppService.Update(customerViewModel);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete([FromQuery]Guid id)
        {
            customerAppService.Remove(id);
            return RedirectToAction("Index");
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
