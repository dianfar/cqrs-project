using System;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Interfaces;
using MediatR;
using MyApp.Domain.Core.Notifications;
using MyApp.Application.ViewModels;

namespace MyApp.Web.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProjectAppService productAppService;

        public ProductController(
            IProjectAppService productAppService, 
            INotificationHandler<DomainNotification> notifications) : base(notifications)
        {
            this.productAppService = productAppService;
        }

        public IActionResult Index()
        {
            var products = productAppService.GetAll();
            return View(products);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(ProjectViewModel product)
        {
            if (!ModelState.IsValid) return View(product);
            productAppService.Create(product);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var customer = productAppService.GetById(id);
            return View(customer);
        }

        [HttpPost]
        public IActionResult Edit(ProjectViewModel productViewModel)
        {
            if (!ModelState.IsValid) return View(productViewModel);
            productAppService.Update(productViewModel);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete([FromQuery]Guid id)
        {
            productAppService.Remove(id);
            return RedirectToAction("Index");
        }
    }
}
