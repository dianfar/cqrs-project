using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Interfaces;

namespace MyApp.WebApi.Controllers
{
    [Route("clients")]
    public class ClientController : Controller
    {
        private readonly IClientAppService clientAppService;

        public ClientController(IClientAppService clientAppService)
        {
            this.clientAppService = clientAppService;
        }

        [HttpGet]
        [Route("")]
        public IActionResult List()
        {
            return View("List");
        }

        [HttpGet]
        [Route("{clientId}/edit")]
        public IActionResult Edit(string clientId)
        {
            ViewBag.ClientId = clientId;
            return View("Edit");
        }

        [HttpGet]
        [Route("add")]
        public IActionResult Add()
        {
            return View("Add");
        }
    }
}
