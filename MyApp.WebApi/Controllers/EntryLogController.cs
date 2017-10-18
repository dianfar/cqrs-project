using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.WebApi.Controllers
{
    [Authorize]
    [Route("entryLogs")]
    public class EntryLogController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult List()
        {
            return View("EntryLog");
        }
    }
}
