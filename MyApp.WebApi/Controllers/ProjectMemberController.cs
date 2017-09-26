using System;
using MyApp.Application.Interfaces;
using MyApp.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Web.Controllers
{
    [Route("api/projectmembers")]
    public class ProjectMemberController : Controller
    {
        private readonly IProjectMemberAppService projectMemberAppService;

        public ProjectMemberController(IProjectMemberAppService projectMemberAppService)
        {
            this.projectMemberAppService = projectMemberAppService;
        }

        [HttpPost]
        [Route("")]
        public IActionResult Add([FromBody] ProjectMemberViewModel viewModel)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            projectMemberAppService.Add(viewModel);

            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Remove(Guid id)
        {
            projectMemberAppService.Remove(id);
            return Ok();
        }
    }
}
