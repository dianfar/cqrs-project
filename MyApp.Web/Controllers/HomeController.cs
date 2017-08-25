using System;
using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using MediatR;
using Domain.Core.Notifications;
using Application.ViewModels;

namespace MyApp.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ICustomerAppService _customerAppService;

        public HomeController(ICustomerAppService customerAppService,
                                  INotificationHandler<DomainNotification> notifications) : base(notifications)
        {
            _customerAppService = customerAppService;
        }

        public IActionResult Index()
        {
            var customers = _customerAppService.GetAll();
            return View(customers);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(CustomerViewModel customerViewModel)
        {
            if (!ModelState.IsValid) return View(customerViewModel);
            _customerAppService.Register(customerViewModel);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var customer = _customerAppService.GetById(id);
            return View(customer);
        }

        [HttpPost]
        public IActionResult Edit(CustomerViewModel customerViewModel)
        {
            if (!ModelState.IsValid) return View(customerViewModel);
            _customerAppService.Update(customerViewModel);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete([FromQuery]Guid id)
        {
            _customerAppService.Remove(id);
            return RedirectToAction("Index");
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
