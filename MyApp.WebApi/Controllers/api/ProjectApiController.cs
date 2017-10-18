using System;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Interfaces;
using MyApp.Application.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyApp.WebApi.Controllers.api;
using MediatR;
using MyApp.Domain.Core.Notifications;

namespace MyApp.WebApi.Controllers
{
    [Route("api/projects")]
    public class ProjectApiController : BaseApiController
    {
        private readonly IProjectAppService projectAppService;

        public ProjectApiController(IProjectAppService productAppService, INotificationHandler<DomainNotification> notifications) : base(notifications)
        {
            this.projectAppService = productAppService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<ProjectViewModel>> GetProjects()
        {
            var projects = await projectAppService.GetAll();
            return projects;
        }

        [HttpGet]
        [Route("add")]
        public async Task<CreateNewProjectViewModel> GetAddProject()
        {
            var createNewProjectViewModel = await projectAppService.GetCreateNewProjectData();
            return createNewProjectViewModel;
        }

        [HttpGet]
        [Route("{id}/edit")]
        public async Task<UpdateProjectViewModel> GetUpdateProject(Guid id)
        {
            var updateProjectViewModel = await projectAppService.GetUpdateProjectData(id);
            return updateProjectViewModel;
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
