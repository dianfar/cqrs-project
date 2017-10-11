using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Interfaces;
using MyApp.Application.ViewModels;
using System.Threading.Tasks;

namespace MyApp.WebApi.Controllers
{
    [Route("api/clients")]
    public class ClientApiController : Controller
    {
        private readonly IClientAppService clientAppService;

        public ClientApiController(IClientAppService clientAppService)
        {
            this.clientAppService = clientAppService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<ClientViewModel>> GetClients()
        {
            var clients = await clientAppService.GetAll();
            return clients;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ClientViewModel> GetClient(Guid id)
        {
            var client = await clientAppService.GetById(id);
            return client;
        }

        [HttpPost]
        [Route("")]
        public IActionResult Add([FromBody] ClientViewModel clientViewModel)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            clientAppService.Register(clientViewModel);

            return Ok();
        }

        [HttpPut]
        [Route("")]
        public IActionResult Edit([FromBody] ClientViewModel clientViewModel)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            clientAppService.Update(clientViewModel);

            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(Guid id)
        {
            clientAppService.Remove(id);
            return Ok();
        }
    }
}
