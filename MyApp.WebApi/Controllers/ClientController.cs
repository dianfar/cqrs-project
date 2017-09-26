using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Interfaces;
using MyApp.Application.ViewModels;

namespace MyApp.WebApi.Controllers
{
    [Route("api/clients")]
    public class ClientController : Controller
    {
        private readonly IClientAppService clientAppService;

        public ClientController(IClientAppService clientAppService)
        {
            this.clientAppService = clientAppService;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<ClientViewModel> GetClients()
        {
            var clients = clientAppService.GetAll();
            return clients;
        }

        [HttpGet]
        [Route("{id}")]
        public ClientViewModel GetClient(Guid id)
        {
            var clients = clientAppService.GetById(id);
            return clients;
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
