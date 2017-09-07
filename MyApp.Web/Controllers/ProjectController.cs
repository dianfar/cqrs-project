using System;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Interfaces;
using MediatR;
using MyApp.Domain.Core.Notifications;
using MyApp.Application.ViewModels;

namespace MyApp.Web.Controllers
{
    public class ProjectController : BaseController
    {
        private readonly IProjectAppService projectAppService;

        public ProjectController(
            IProjectAppService productAppService, 
            INotificationHandler<DomainNotification> notifications) : base(notifications)
        {
            this.projectAppService = productAppService;
        }

        public IActionResult Index()
        {
            var projects = projectAppService.GetAll();
            return View(projects);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var createNewProjectViewModel = projectAppService.GetCreateNewProjectData();
            return View(createNewProjectViewModel);
        }

        [HttpPost]
        public IActionResult Add(ProjectViewModel projectViewModel)
        {
            if (!ModelState.IsValid) return View(projectViewModel);
            projectAppService.Create(projectViewModel);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var project = projectAppService.GetById(id);
            return View(project);
        }

        [HttpPost]
        public IActionResult Edit(ProjectViewModel projectViewModel)
        {
            if (!ModelState.IsValid) return View(projectViewModel);
            projectAppService.Update(projectViewModel);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete([FromQuery]Guid id)
        {
            projectAppService.Remove(id);
            return RedirectToAction("Index");
        }
    }
}
