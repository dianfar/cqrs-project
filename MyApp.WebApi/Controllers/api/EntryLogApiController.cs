using System;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Interfaces;
using MyApp.Application.ViewModels;
using System.Threading.Tasks;

namespace MyApp.WebApi.Controllers
{
    [Route("api/entries")]
    public class EntryLogApiController : Controller
    {
        private readonly IEntryLogAppService entryLogAppService;

        public EntryLogApiController(IEntryLogAppService entryLogAppService)
        {
            this.entryLogAppService = entryLogAppService;
        }

        [HttpGet]
        [Route("{userId}")]
        public async Task<CreateUpdateEntryLogViewModel> GetEntries(Guid userId)
        {
            var entryLogs = await entryLogAppService.GetByUser(userId);
            entryLogs.EditMode = false;
            return entryLogs;
        }
        
        [HttpPost]
        [Route("{userId}")]
        public IActionResult Add(Guid userId, [FromBody] CreateUpdateEntryLogViewModel viewModel)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            viewModel.UserId = userId;
            entryLogAppService.Create(viewModel);

            return Ok();
        }

        [HttpPut]
        [Route("{userId}")]
        public IActionResult Edit(Guid userId, [FromBody] CreateUpdateEntryLogViewModel viewModel)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            viewModel.UserId = userId;
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
