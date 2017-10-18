using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.WebApi.Controllers
{
    [Authorize]
    [Route("users")]
    public class UserController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult List()
        {
            return View("List");
        }

        [HttpGet]
        [Route("{userId}/edit")]
        public IActionResult Edit(string userId)
        {
            ViewBag.UserId = userId;
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
