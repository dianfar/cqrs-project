using System;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Interfaces;
using MyApp.Application.ViewModels;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using MyApp.WebApi.Controllers.api;
using MediatR;
using MyApp.Domain.Core.Notifications;

namespace MyApp.WebApi.Controllers
{
    [Authorize]
    [Route("api/entries")]
    public class EntryLogApiController : BaseApiController
    {
        private readonly IEntryLogAppService entryLogAppService;

        public EntryLogApiController(IEntryLogAppService entryLogAppService, INotificationHandler<DomainNotification> notifications) : base(notifications)
        {
            this.entryLogAppService = entryLogAppService;
        }

        [HttpGet]
        [Route("")]
        public async Task<CreateUpdateEntryLogViewModel> GetEntries()
        {
            var entryLogs = await entryLogAppService.GetByUser(this.UserId);
            entryLogs.EditMode = false;
            return entryLogs;
        }
        
        [HttpPost]
        [Route("")]
        public IActionResult Add([FromBody] CreateUpdateEntryLogViewModel viewModel)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            viewModel.UserId = this.UserId;
            entryLogAppService.Create(viewModel);

            return Ok();
        }

        [HttpPut]
        [Route("")]
        public IActionResult Edit([FromBody] CreateUpdateEntryLogViewModel viewModel)
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
