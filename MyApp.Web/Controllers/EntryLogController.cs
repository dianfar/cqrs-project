using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Interfaces;
using MediatR;
using MyApp.Domain.Core.Notifications;
using MyApp.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace MyApp.Web.Controllers
{
    [Authorize]
    public class EntryLogController : BaseController
    {
        private readonly IEntryLogAppService entryLogAppService;

        public EntryLogController(
            IEntryLogAppService entryLogAppService, 
            INotificationHandler<DomainNotification> notifications) : base(notifications)
        {
            this.entryLogAppService = entryLogAppService;
        }

        public IActionResult Index()
        {
            var entryLogs = entryLogAppService.GetByUser(Guid.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value));
            entryLogs.EditMode = false;
            return View(entryLogs);
        }

        [HttpPost]
        public IActionResult Add(CreateUpdateEntryLogViewModel viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);
            viewModel.UserId = Guid.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
            entryLogAppService.Create(viewModel);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var updateEntryLogData = entryLogAppService.GetUpdatedData(id);
            updateEntryLogData.EditMode = true;
            return View("Index", updateEntryLogData);
        }

        [HttpPost]
        public IActionResult Edit(CreateUpdateEntryLogViewModel viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);
            viewModel.UserId = Guid.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
            entryLogAppService.Update(viewModel);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete([FromQuery]Guid id)
        {
            entryLogAppService.Remove(id);
            return RedirectToAction("Index");
        }
    }
}
