﻿using System;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Interfaces;
using MediatR;
using MyApp.Domain.Core.Notifications;
using MyApp.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace MyApp.Web.Controllers
{
    //[Authorize]
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
            var entryLogs = entryLogAppService.GetByUser();
            entryLogs.EditMode = false;
            return View(entryLogs);
        }

        [HttpPost]
        public IActionResult Add(CreateUpdateEntryLogViewModel viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);
            viewModel.UserId = UserId;
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
            viewModel.UserId = UserId;
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