using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Interfaces;
using MediatR;
using MyApp.Domain.Core.Notifications;
using MyApp.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Threading.Tasks;

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

        public async Task<IActionResult> Index()
        {
            var entryLogs = await entryLogAppService.GetByUser(Guid.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value));
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
        public async Task<IActionResult> Edit(Guid id)
        {
            var userId = Guid.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
            var updateEntryLogData = await entryLogAppService.GetUpdatedData(userId, id);
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
