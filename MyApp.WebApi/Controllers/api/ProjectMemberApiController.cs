﻿using System;
using MyApp.Application.Interfaces;
using MyApp.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using MyApp.WebApi.Controllers.api;
using MediatR;
using MyApp.Domain.Core.Notifications;

namespace MyApp.Web.Controllers
{
    [Route("api/projectmembers")]
    public class ProjectMemberApiController : BaseApiController
    {
        private readonly IProjectMemberAppService projectMemberAppService;

        public ProjectMemberApiController(IProjectMemberAppService projectMemberAppService, INotificationHandler<DomainNotification> notifications) : base(notifications)
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
