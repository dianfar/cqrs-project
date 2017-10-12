using Microsoft.AspNetCore.Mvc;

namespace MyApp.WebApi.Controllers
{
    [Route("projects")]
    public class ProjectController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult List()
        {
            return View("List");
        }

        [HttpGet]
        [Route("{projectId}/edit")]
        public IActionResult Edit(string projectId)
        {
            ViewBag.ProjectId = projectId;
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
