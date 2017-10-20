using System;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Interfaces;
using MyApp.Application.ViewModels;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using MyApp.WebApi.Controllers.api;
using MediatR;
using MyApp.Domain.Core.Notifications;
using System.Collections.Generic;

namespace MyApp.WebApi.Controllers
{
    [Authorize]
    [Route("api/entryLogs")]
    public class EntryLogApiController : BaseApiController
    {
        private readonly IEntryLogAppService entryLogAppService;

        public EntryLogApiController(IEntryLogAppService entryLogAppService, INotificationHandler<DomainNotification> notifications) : base(notifications)
        {
            this.entryLogAppService = entryLogAppService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<EntryLogViewModel>> GetEntries()
        {
            var entryLogs = await entryLogAppService.GetEntryLogsByUser(this.UserId);
            return entryLogs;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<EntryLogViewModel> GetEntry(Guid id)
        {
            var entryLog = await entryLogAppService.GetById(id);
            return entryLog;
        }

        [HttpPost]
        [Route("")]
        public IActionResult Add([FromBody] EntryLogViewModel viewModel)
        {
            viewModel.UserId = this.UserId;
            if (!ModelState.IsValid) return BadRequest(ModelState);
            entryLogAppService.Create(viewModel);

            return Ok();
        }

        [HttpPut]
        [Route("")]
        public IActionResult Edit([FromBody] EntryLogViewModel viewModel)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            viewModel.UserId = this.UserId;
            entryLogAppService.Update(viewModel);

            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(Guid id)
        {
            entryLogAppService.Remove(id);
            return Ok();
        }
    }
}
