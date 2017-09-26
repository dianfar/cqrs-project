using System;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Interfaces;
using MyApp.Application.ViewModels;
using System.Collections.Generic;

namespace MyApp.WebApi.Controllers
{
    [Route("api/projects")]
    public class ProjectController : Controller
    {
        private readonly IProjectAppService projectAppService;

        public ProjectController(IProjectAppService productAppService)
        {
            this.projectAppService = productAppService;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<ProjectViewModel> GetProjects()
        {
            var projects = projectAppService.GetAll();
            return projects;
        }

        [HttpPost]
        [Route("")]
        public IActionResult Add([FromBody] ProjectViewModel projectViewModel)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            projectAppService.Create(projectViewModel);

            return Ok();
        }

        [HttpPut]
        [Route("")]
        public IActionResult Edit([FromBody] UpdateProjectViewModel updateProjectViewModel)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            projectAppService.Update(updateProjectViewModel);

            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(Guid id)
        {
            projectAppService.Remove(id);
            return Ok();
        }
    }
}
