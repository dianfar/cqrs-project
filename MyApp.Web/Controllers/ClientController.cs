using System;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Interfaces;
using MediatR;
using MyApp.Domain.Core.Notifications;
using MyApp.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace MyApp.Web.Controllers
{
    [Authorize]
    public class ClientController : BaseController
    {
        private readonly IClientAppService clientAppService;

        public ClientController(IClientAppService clientAppService,
                                  INotificationHandler<DomainNotification> notifications) : base(notifications)
        {
            this.clientAppService = clientAppService;
        }

        public async Task<IActionResult> Index()
        {
            var clients = await clientAppService.GetAll();
            return View(clients);
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
        public async Task<IActionResult> Edit(Guid id)
        {
            var client = await clientAppService.GetById(id);
            return View(client);
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
    }
}
