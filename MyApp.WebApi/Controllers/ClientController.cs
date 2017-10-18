using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.WebApi.Controllers
{
    [Authorize]
    [Route("clients")]
    public class ClientController : Controller
    {
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
